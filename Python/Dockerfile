FROM python:3.10-alpine

WORKDIR /app

COPY requirements/backend.txt ./requirements/

RUN pip install --no-cache-dir -r requirements/backend.txt

COPY . .

EXPOSE 8080

CMD ["uvicorn", "spaceship.main:app", "--host=0.0.0.0", "--port=8080"]
