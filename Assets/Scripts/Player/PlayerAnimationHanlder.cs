using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHanlder : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private Movement _movement;

    private int _isMovingParameterHash = Animator.StringToHash("IsMoving");

    private void Update()
    {
        TryPlayWalkAnimation();
    }

    private void TryPlayWalkAnimation()
    {
        _animator.SetBool(_isMovingParameterHash, _movement.IsMoving);
    }
}

