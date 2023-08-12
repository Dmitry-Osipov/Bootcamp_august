from flask import Flask
from flask import render_template

app = Flask(__name__)


@app.route('/')
def say_hello():
    return render_template('index.html')


@app.route('/test/')
def say_name():
    return render_template('name.html')


if __name__ == '__main__':
    app.run(debug=True)
