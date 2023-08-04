from flask import Flask

app = Flask(__name__)

@app.route('/')
def hello():
    return f"<h1>Hello, World!</h1><br><a href='/index'>перейти на вторую страницу</a>" 
"""<h1>...</h1> - заголовки первого уровня
<br> - переводит код на новую строку
<a>...</a> - название страницы, куда мы будем переходить
<href=...> = путь, гиперссылка"""


@app.route('/index/<x>/<y>')
def index(x, y):
    return f"Результат: {int(x) + int(y)}"
"""Прописали функцию: в декораторе передали путь для страницы с надписью (надпись возвращает сама функция)
Данный способ показывает передачу аргументов через адрессную строку.
Если просто прописать путь: http://127.0.0.1:5000/index - то выдаст ошибку.
Пример написания: http://127.0.0.1:5000/index/2/6"""

if __name__ == '__main__':
    app.run()