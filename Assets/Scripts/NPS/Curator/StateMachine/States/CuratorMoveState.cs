using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[RequireComponent(typeof(NPCMover))]
public class CuratorMoveState : MonoBehaviour
{
    public event UnityAction PathCompleted;

    [SerializeField] private List<TargetPointsHolder> _pathSequence = new List<TargetPointsHolder>();

    private CuratorDialogueState _dialogueState;
    private NPCMover _mover;

    private int _currentPathIndex = -1;
    private int _currentTargetPointIndex = 0;

    public bool IsMoving { get; private set; }

    private void Awake()
    {
        _mover = GetComponent<NPCMover>();
        _dialogueState = GetComponent<CuratorDialogueState>();

        _mover.TargetPointReached += SetNextTargetPoint;
    }

    private void OnDestroy()
    {
        _mover.TargetPointReached -= SetNextTargetPoint;
    }

    private void Start()
    {
        SetNextPath();
    }

    public void SetNextPath()
    {
        if (_currentPathIndex + 1 >= _pathSequence.Count)
        {
            return;
        }

        IsMoving = true;

        _dialogueState.enabled = false;

        _currentPathIndex++;
        _currentTargetPointIndex = 0;

        SetNextTargetPoint();
    }

    private void ResetToDefalut()
    {
        _currentPathIndex = 0;
    }

    private void SetNextTargetPoint()
    {
        if (_currentTargetPointIndex >= _pathSequence[_currentPathIndex].TargetPointsTransform.Count)
        {
            PathCompleted?.Invoke();
            IsMoving = false;
            _dialogueState.enabled = true;
            return;
        }

        var currentTargetPoint = _pathSequence[_currentPathIndex].TargetPointsTransform[_currentTargetPointIndex];

        _mover.SetTargetPoint(currentTargetPoint);

        _currentTargetPointIndex++;
    }
}
