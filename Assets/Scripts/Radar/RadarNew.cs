using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarNew : MonoBehaviour
{
    [SerializeField] private GameObject _radarPointerPrefab;
    [SerializeField] private Canvas _uiCanvas;
    [SerializeField] private Sprite _radarIcon;
    [SerializeField] private List<Transform> _targets;

    private List<RadarPointer> _radarPointers;

    public Transform TargetsTransform => _targets[0];

    private void Start()
    {
        if (_radarPointers != null)
            return;

        _radarPointers = new List<RadarPointer>();
        StartRadarPpointer();
    }

    public void StartRadarPpointer()
    {
        _radarPointers.Add(Instantiate(_radarPointerPrefab).GetComponent<RadarPointer>());
        _radarPointers[^1].transform.SetParent(_uiCanvas.transform);
        _radarPointers[^1].Init(_targets[_radarPointers.Count - 1].transform, transform, _radarIcon);
    }

    public void AddTarget(Transform target)
    {
        _targets.Add(target);
        StartRadarPpointer();
    }

    public void DeletePointersAndClearTargets()
    {
        foreach (var radarPointer in _radarPointers)
        {
            Destroy(radarPointer.gameObject);
        }

        _radarPointers.Clear();
        _targets.Clear();
    }
}
