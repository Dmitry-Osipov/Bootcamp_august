from turtle import *
from time import *
from random import randint


def markup():  # Функция рисует разметку поля.
    turtle = Turtle()  # Условная черепашка, которая занимается отрисовкой поля.
    turtle.speed(0)

    for i in range(1, 21):
        turtle.penup()
        turtle.goto(-200 + i * 20, 50)
        turtle.pendown()
        turtle.goto(-200 + i * 20, -100)
    
    turtle.hideturtle()


def first_turtle_catch(x_coord, y_coord):  # Это обработчик события нажатия.
    first_turtle.write('Ouch!', font=('Arial', 14, 'normal'))  # Пишем на экране Ауч.
    first_turtle.fd(randint(10, 15))  # Первая черепаха делает случайный шаг от 10 до 15.


def second_turtle_catch(x_coord, y_coord):  # Это обработчик события нажатия.
    second_turtle.write('Ouch!', font=('Arial', 14, 'normal'))  # Пишем на экране Ауч.
    second_turtle.fd(randint(10, 15))  # Первая черепаха делает случайный шаг от 10 до 15.


first_turtle = Turtle()  # Тут рождается черепашка из класса черепах.
first_turtle.shape('turtle')
first_turtle.color('red')
first_turtle.penup()
first_turtle.goto(-200, 20)
first_turtle.pendown()
first_turtle.speed(2)
# В коде выше мы присваиваем объекту форму, цвет, далее поднимаем, двигаем, опускаем, добавляем скорость отрисовки. Поднимаем и опускаем
# для того, чтобы не оставалось следа от её перемещения.
first_turtle.onclick(first_turtle_catch)  # Добавляем возможность ускорить черепаху с помощью функции выше.

second_turtle = Turtle()
second_turtle.shape('turtle')
second_turtle.color('blue')
second_turtle.penup()
second_turtle.goto(-200, -20)
second_turtle.pendown()
second_turtle.speed(2)

second_turtle.onclick(second_turtle_catch)

markup()  # Отрисовываем поле.

x_finish = 200

while first_turtle.xcor() < x_finish and second_turtle.xcor() < x_finish:
    first_turtle.fd(randint(2, 7))
    second_turtle.fd(randint(2, 7))
    sleep(0.005)
    # В коде выше черепахи будут двигаться со случайной скоростью каждую итерацию цикла. Добавляем sleep, чтобы чуть замедлить отрисовку

if first_turtle.xcor() >= x_finish:
    first_turtle.write('     I am winner')
else:
    second_turtle.write('     I am winner')

exitonclick()
