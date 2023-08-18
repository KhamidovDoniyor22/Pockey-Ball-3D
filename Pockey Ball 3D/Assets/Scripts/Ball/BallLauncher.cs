using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class BallLauncher : MonoBehaviour
{
    [SerializeField] private Stick _stick;
    private Rigidbody _rigidbody;      

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
      
    }
    private void Update()
    {
        if (/*Input.GetMouseButtonDown(0) && */_stick._isJumpReady)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(Vector3.up * _stick._jumpForce, ForceMode.Impulse);
        }
        if (Input.GetMouseButton(0))
        {
            Ray ray = new Ray(transform.position, Vector3.forward);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.TryGetComponent(out Block block))
                {
                    //_rigidbody.isKinematic = false;
                }
                else if (hitInfo.collider.TryGetComponent(out Segment segment))
                {
                    _rigidbody.isKinematic = true;
                    _rigidbody.velocity = Vector3.zero;
                    
                }
                else if (hitInfo.collider.TryGetComponent(out Finish finish))
                {
                    Time.timeScale = 0;
                }
            }
        }
    }
}
