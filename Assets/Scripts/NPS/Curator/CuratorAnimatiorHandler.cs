using UnityEngine;

public class CuratorAnimatiorHandler : MonoBehaviour
{
    [SerializeField] private CuratorMoveState _moveState;

    [SerializeField] private Animator _animator;

    private int _isMovingParameterHash = Animator.StringToHash("IsMoving");

    private void Update()
    {
        TryPlayWalkAnimation();
    }

    private void TryPlayWalkAnimation()
    {
        _animator.SetBool(_isMovingParameterHash, _moveState.IsMoving);
    }
}
