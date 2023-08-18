using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    [SerializeField] private float _power;
    [SerializeField] public float _jumpForce;
    
    [SerializeField] public bool _isJumpReady;

    private const float _firstLevelJumpForce = 0.05f;
    private const float _secondLevelJumpForce = 0.07f;
    private const float _thirdLevelJumpForce = 0.09f;
    private const float _forthLevelJumpForce = 0.1f;

    private void Update()
    {
        _power = Mathf.Clamp(_power, 0, 1);
        TouchChecker(); 
        JumpForceIdentifier();
    }
    private void TouchChecker()
    {
        float forcePlus = 0.001f;
        
        if(Input.GetMouseButton(0) && !_isJumpReady)
        {
            _power += forcePlus;
            _animator.SetFloat("Blend", _power);           
        }
        if(Input.GetMouseButtonUp(0))
        {
            _isJumpReady = true;
        }
    }
    public void JumpForceIdentifier()
    {
        if (_power < 0.3) _jumpForce = _firstLevelJumpForce;
        if (_power >= 0.3) _jumpForce = _secondLevelJumpForce;
        if (_power >= 0.7) _jumpForce = _thirdLevelJumpForce;
        if (_power >= 0.9) _jumpForce = _forthLevelJumpForce;
    }
}