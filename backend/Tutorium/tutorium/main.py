import uvicorn
from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware

from tutorium.apis.UserApi import user_api_router
from tutorium.database import Database, Schemas

app = FastAPI()
app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)
app.include_router(user_api_router)

Schemas.Base.metadata.create_all(bind=Database.engine)


def start():
    uvicorn.run("tutorium.main:app", host="0.0.0.0", port=8000, reload=True)
