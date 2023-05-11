from sqlalchemy import Boolean, Column, Date, String

from .Database import Base


class User(Base):
    __tablename__ = "users"

    created_at = Column(Date)
    description = Column(String(255), nullable=True)
    email = Column(String(255), unique=True)
    first_name = Column(String(255))
    id = Column(String(255), primary_key=True)
    is_tutor = Column(Boolean, default=False)
    last_name = Column(String(255))
    profile_pic = Column(String(255), nullable=True)
    updated_at = Column(Date)
