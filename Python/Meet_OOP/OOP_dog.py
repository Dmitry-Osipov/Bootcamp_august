class Dog:
    # name = None
    # color = None

    def __init__(self, name, color):
        self.name = name
        self.color = color

    def fas(self):
        print('Гав-гав')


first_dog = Dog('Бобик', 'Чёрный')
# first_dog.name = 'Шарик'
# first_dog.color = 'Рыжий'

print(first_dog.color, first_dog.name)
print(first_dog.__dict__)
first_dog.fas()