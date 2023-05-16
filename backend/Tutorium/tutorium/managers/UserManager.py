from sqlalchemy.orm import Session

from ..database import Schemas
from ..models import UserModel


def get_user(db: Session, user_id: int):
    return db.query(Schemas.User).filter(Schemas.User.id == user_id).first()  # type: ignore


def get_users(db: Session):
    return db.query(Schemas.User).all()


def create_user(db: Session, user: UserModel.UserCreate):
    db_user = Schemas.User(
        created_at=user.created_at,
        email=user.email,
        first_name=user.first_name,
        id=user.id,
        last_name=user.last_name,
        profile_pic=user.profile_pic,
        updated_at=user.updated_at,
    )
    db.add(db_user)
    db.commit()
    db.refresh(db_user)
    return db_user
