import redis

with redis.Redis() as redis_client:
    value = redis_client.brpop("queue")  # Вытаскиваем из очереди, вторым аргументом можно указать кол-во элементов. Если данных в очереди нет, то ждёт

print(value[1])  # Возвращается кортеж с названием очереди и значением
