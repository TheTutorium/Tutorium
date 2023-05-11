from datetime import datetime
from typing import Any, Dict

from fastapi import APIRouter, Depends, HTTPException, Request
from jose import JWTError, jwk, jwt
from jose.utils import base64url_decode
from pydantic import BaseModel
from sqlalchemy.orm import Session

from ..database.Database import get_db
from ..managers import UserManager
from ..models import UserModel

user_api_router = APIRouter(prefix="/users")


class WebhookUser(BaseModel):
    object: str
    type: str
    data: Dict[str, Any]


@user_api_router.get("/is-tutor")
async def is_tutor(request: Request, db: Session = Depends(get_db)):
    auth_header = request.headers.get("Authorization")
    if not auth_header or "Bearer" not in auth_header:
        raise HTTPException(status_code=403, detail="No or bad Authorization header.")

    token = auth_header.split(" ")[1]
    jwks_json = {
        "keys": [
            {
                "use": "sig",
                "kty": "RSA",
                "kid": "ins_2PPaXNxTm0wHzWn7a6i2pvqv2zb",
                "alg": "RS256",
                "n": "taknl1HbKQCfX2j3bM7l84ONSjaQp2Z3lZ9Cj9nnAkMYfMJL1N5rt0pQtEx4h1Fauujr2_oeQwiyRZ6LfH9qU7Jsq95Ay5M-uW01GwduWRebL64LJu4rWVKpa79dBuIV9gZVsDxc-khXKBrblZLhYonSrMmdCl2wdBhC5Un9RQIH21FL-nujVk1HO6dVUGKmAGUTmvHdY-9SZ46PkLI2i9b8LjfUKt9QgGrlLUJL31PKCYf6oRb8J4DT_ED9QhtmbcTWL0qrGTG-yX7uh1gFSHAgsXSVceOFge0PwL1SR1EoAmMt47Tm3wJkydQbshXztZ-OKf5FCbxxt41KZzAvGQ",
                "e": "AQAB",
            }
        ]
    }

    try:
        rsa_key = next(
            (
                key
                for key in jwks_json["keys"]
                if key["kid"] == jwt.get_unverified_header(token)["kid"]
            ),
            None,
        )
        if rsa_key:
            public_key = jwk.construct(rsa_key)
            message, encoded_sig = token.rsplit(".", 1)
            decoded_sig = base64url_decode(encoded_sig.encode())
            if not public_key.verify(message.encode(), decoded_sig):
                raise JWTError("Signature verification failed.")
            claims = jwt.get_unverified_claims(token)
            id = claims["sub"]
            user = UserManager.get_user(db, user_id=id)
            return {
                "isTutor": user.is_tutor,
            }
    except JWTError as e:
        raise HTTPException(status_code=401, detail=str(e))


@user_api_router.get("/{user_id}", response_model=UserModel.User)
def read_user(user_id: int, db: Session = Depends(get_db)):
    db_user = UserManager.get_user(db, user_id=user_id)
    if db_user is None:
        raise HTTPException(status_code=404, detail="User not found")
    return db_user


@user_api_router.get("/", response_model=list[UserModel.User])
def read_users(db: Session = Depends(get_db)):
    users = UserManager.get_users(db)
    return users


@user_api_router.post("/webhook")
async def webhook(weebhook_user: WebhookUser, db: Session = Depends(get_db)):
    if weebhook_user.type == "user.created":
        return UserManager.create_user(
            db,
            user=UserModel.UserCreate(
                created_at=datetime.utcnow(),
                email=weebhook_user.data["email_addresses"][0]["email_address"],
                first_name=weebhook_user.data["first_name"],
                id=weebhook_user.data["id"],
                last_name=weebhook_user.data["last_name"],
                profile_pic=weebhook_user.data["profile_image_url"],
                updated_at=datetime.utcnow(),
            ),
        )
    if weebhook_user.type == "user.updated":
        pass
    if weebhook_user.type == "user.deleted":
        pass
