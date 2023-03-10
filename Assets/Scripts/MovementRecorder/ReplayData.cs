using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ReplayData
{
    public Vector3 Position { get; private set; }
    public Quaternion Rotation { get; private set; }

    public bool Up;
    public bool Right;
    public bool Down;
    public bool Left;

    public ReplayData(Vector3 position, Quaternion rotation, bool up, bool right, bool down, bool left)
    {
        Position = position;
        Rotation = rotation;
        Up = up;
        Right = right;
        Down = down;
        Left = left;
    }
}
