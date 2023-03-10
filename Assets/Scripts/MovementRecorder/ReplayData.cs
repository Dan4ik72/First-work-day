using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ReplayData
{
    public Vector3 Position { get; private set; }
    public Quaternion Rotation { get; private set; }

    public ReplayData(Vector3 position, Quaternion rotation)
    {
        Position = position;
        Rotation = rotation;
    }
}
