using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayObject : MonoBehaviour
{
    public void SetDataForFrame(ReplayData data)
    {
        transform.position = data.Position;
        transform.rotation = data.Rotation;
    }
}
