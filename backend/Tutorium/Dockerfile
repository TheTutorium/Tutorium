FROM python:3.11

WORKDIR /app

COPY . .

RUN pip install poetry
RUN poetry config virtualenvs.create false
RUN poetry install -v

CMD ["sh", "-c", "uvicorn tutorium.main:app --host 0.0.0.0 --port $PORT"]
