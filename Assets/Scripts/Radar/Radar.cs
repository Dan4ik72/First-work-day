using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radar : MonoBehaviour
{
    [SerializeField] private GameObject _radarPointerPrefab;
    [SerializeField] private Canvas _uiCanvas;
    [SerializeField] private Player _player;
    [SerializeField] private Sprite _radarIcon;

    private RadarPointer _radarPointer;

    private void Start()
    {
        if (_radarPointer != null)
            return;

        _radarPointer = Instantiate(_radarPointerPrefab).GetComponent<RadarPointer>();
        //_radarPointer.transform.parent = _uiCanvas.transform;
        _radarPointer.transform.SetParent(_uiCanvas.transform);
        _radarPointer.Init(transform, _player.transform, _radarIcon);
    }
}
