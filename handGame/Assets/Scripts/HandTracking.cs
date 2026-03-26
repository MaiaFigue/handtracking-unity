using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    public HandTrackingUDP udpReceive;
    public GameObject[] handPoints;

    void Update()
    {
        string data = udpReceive.receivedData;

        if (string.IsNullOrEmpty(data))
            return;

        // Remove brackets if present
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);

        string[] points = data.Split(',');

        if (points.Length < 63) // 21 points * 3 coordinates
            return;

        for (int i = 0; i < 21; i++)
        {
            float x = 5-float.Parse(points[i * 3]) / 100f;
            float y = float.Parse(points[i * 3 + 1]) / 100f;
            float z = float.Parse(points[i * 3 + 2]) / 100f;

            handPoints[i].transform.localPosition = new Vector3(x, y, z);
        }
    }
}