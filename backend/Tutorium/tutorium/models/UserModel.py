from datetime import date

from pydantic import BaseModel


class UserBase(BaseModel):
    created_at: date
    email: str
    first_name: str
    id: str
    last_name: str
    profile_pic: str
    updated_at: date


class User(UserBase):
    class Config:
        orm_mode = True


class UserCreate(UserBase):
    pass


class UserUpdate(UserBase):
    description: str | None
    is_tutor: bool
