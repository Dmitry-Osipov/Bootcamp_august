import cv2

face_cascades = cv2.CascadeClassifier(cv2.data.haarcascades + 'haarcascade_frontalface_default.xml')  
# файл выше уже есть в библиотеке, так что скачивать его не надо

img = cv2.imread('image1.jpeg')
img = cv2.resize(img, (500, 500))
img_gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)  # с серым фото нейронка работает лучше

faces = face_cascades.detectMultiScale(img_gray)
print(faces)  # выводит предполагаемое место лица на фото

for (x, y, w, h) in faces:  # перебираем отдельно x, y, высоту и ширину
    cv2.rectangle(img_gray, (x, y), (x + w, y + h), (0, 0, 255), 2) 
    # выводим красный прямоугольник по лицу
    # в функцию передаём изначальное фото, координаты начала, координаты рамки, цвет рамки по коду, толщину рамки


cv2.imshow('Result', img_gray) 
cv2.waitKey(0)

cap = cv2.VideoCapture(0)  # для взаимодействия с веб-камерой (если она одна) пишем 0, 
# если нет камеры, то указываем название видео по аналогии с картинкой

while True:
    success, frame = cap.read()  # в переменную frame записывается картинка, которуюмы считываем, success - это булева-переменная, 
    # которая сообщает, получили ли мы следующий кадр

    cv2.imshow('Camera', frame)

    img_gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    faces = face_cascades.detectMultiScale(img_gray)
    for (x, y, w, h) in faces:
        cv2.rectangle(frame, (x, y), (x + w, y + h), (0, 0, 255), 2)
    cv2.imshow('Result', frame)

    # принцип кода выше такой же, как и с фото

    if cv2.waitKey(1) & 0xff == ord('q'):  # кадр обновляется через 1 миллисекунду
        break  # строка выше позволит выйти при нажатии кнопки q

