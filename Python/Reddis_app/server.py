import redis
from random import randint

with redis.Redis() as redis_server:  # Создаём сервер из нашего подключения к Redis
    redis_server.lpush("queue", randint(0, 10))  # Проталкиваем в начало очереди (первый элемент списка)