import os
import ssl

from dotenv import load_dotenv
from sqlalchemy import create_engine
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import sessionmaker

load_dotenv()

DATABASE = os.getenv("DATABASE")
DATABASE_USERNAME = os.getenv("DATABASE_USERNAME")
HOST = os.getenv("HOST")
PASSWORD = os.getenv("PASSWORD")
SQLALCHEMY_DATABASE_URL = f"mysql://{DATABASE_USERNAME}:{PASSWORD}@{HOST}/{DATABASE}"

ssl_context = ssl.create_default_context()
engine = create_engine(SQLALCHEMY_DATABASE_URL, connect_args={"ssl": ssl_context})
SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)

Base = declarative_base()


def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()
