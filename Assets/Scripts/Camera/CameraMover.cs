using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void FixedUpdate()
    {
        transform.position = _target.transform.position;
    }

}
