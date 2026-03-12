import cv2
from cvzone.HandTrackingModule import HandDetector
import socket

#Parameters
width , height = 1280, 720

#Webcam
cap = cv2.VideoCapture(0)
cap.set(3, width)
cap.set(4, height)

#Hand Detector
detector = HandDetector(maxHands=1, detectionCon=0.8)

#Communication 
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddr = ('127.0.0.1', 5516)

while True:
    #Get frame from webcam
    success, img = cap.read()

    #Hands
    hands, img = detector.findHands(img)

    data = []
    #Landmarks values - (x,y,z) * 21
    if hands:
        hand = hands[0]
        lmList = hand['lmList']

        for landmark in lmList:
            data.extend([landmark[0], height - landmark[1], landmark[2]])
        
        sock.sendto(str.encode(str(data)), serverAddr)

    img = cv2.resize(img, (0, 0), None, 0.5, 0.5)
    cv2.imshow("Hand Tracking", img)
    cv2.waitKey(1)

