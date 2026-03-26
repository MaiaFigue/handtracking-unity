# handtracking-unity

A tech demo that uses real-time hand tracking to control a Unity game. A Python script captures hand landmark data from a webcam and streams it to Unity over UDP, where it drives in-game interactions.

---

## How it works

```
Webcam → Python (MediaPipe / cvzone) → UDP socket → Unity (C#)
```

1. Python captures your hand via webcam using **cvzone** and **OpenCV**
2. It detects 21 hand landmarks (x, y, z coordinates each)
3. Those 63 values are sent as a UDP packet to `localhost:5516`
4. The Unity script `UDPReceive.cs` listens on that port and feeds the data into the game

---

## Requirements

### Python side
- Python 3.8+
- A webcam

Install dependencies:
```bash
pip install -r requirements.txt
```

`requirements.txt` should include:
```
opencv-python
cvzone
mediapipe
```

### Unity side
- Unity 2021.3+ (URP)
- No extra packages needed — TextMesh Pro is bundled via Package Manager

---

## Running the demo

1. Open the `handGame/` folder as a Unity project
2. Open the `Game` scene in `Assets/Scenes/`
3. Press **Play** in Unity
4. In a separate terminal, run the Python script:

```bash
python main.py
```

5. Hold your hand in front of the webcam — Unity will receive the landmark data in real time

> Press any key to quit the Python window.

---

## Project structure

```
handtracking-unity/
├── main.py                  # Python hand tracking + UDP sender
├── requirements.txt         # Python dependencies
└── handGame/
    └── Assets/
        ├── Scripts/
        │   ├── HandTracking.cs   # Processes incoming landmark data
        │   ├── UDPReceive.cs     # Listens for UDP packets from Python
        │   ├── GrabObject.cs     # Hand interaction logic
        │   ├── Lines.cs          # Visual feedback
        │   ├── MainMenu.cs       # Menu logic
        │   └── PauseMenu.cs      # Pause logic
        ├── Scenes/
        │   ├── Game.unity
        │   └── MainMenu.unity
        └── Material/             # Custom materials
```
---

## Demo

<!-- Add a GIF or screenshot here -->
![video_unityhand-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/a5a26f83-4be1-48e5-8709-ce2faa5e5427)

---

## Tech stack

| Layer  | Technology |
|--------|-----------|
| Hand tracking | [cvzone](https://github.com/cvzone/cvzone) + MediaPipe |
| Computer vision | OpenCV |
| Game engine | Unity (URP) |
| Communication | UDP sockets |
| Language | Python + C# |
