from flask import Flask
from flask import render_template
from random import randint

app = Flask(__name__)


@app.route('/')
def say_hello():
    contex = {
        'title': 'Тестовая страница',
        'name': 'Том',
        'number': randint(1, 6),
        'temp_list': ['Боб', 'Анна', 'Том']
    }
    return render_template('index.html', **contex)


@app.route('/test/')
def say_name():
    return render_template('name.html')


if __name__ == '__main__':
    app.run(debug=True)
