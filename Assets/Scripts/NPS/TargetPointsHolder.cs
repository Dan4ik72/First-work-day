using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetPointsHolder : MonoBehaviour
{
    private List<TargetPoint> _targetPoints = new List<TargetPoint>();

    private List<Transform> _targetPointsTransform = new List<Transform>();

    public IReadOnlyList<Transform> TargetPointsTransform => _targetPointsTransform;

    private void Awake()
    {
        _targetPoints = GetComponentsInChildren<TargetPoint>().ToList();

        _targetPointsTransform = GetTargetPointsTransform();
    }

    private List<Transform> GetTargetPointsTransform()
    {
        var targetPointsTransorm = new List<Transform>();

        foreach (var targetPoint in _targetPoints)
            targetPointsTransorm.Add(targetPoint.GetComponent<Transform>());

        return targetPointsTransorm;
    }
}
