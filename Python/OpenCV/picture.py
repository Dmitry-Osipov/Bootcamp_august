import cv2

image = cv2.imread('test2.jpg')
print(image)
image = cv2.resize(image, (500, 500))
print(image.shape)

cv2.imshow('Result', image)
cv2.waitKey(0)  # время показа в милисекундах, если 0, то показывается постоянно