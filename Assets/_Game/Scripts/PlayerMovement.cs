using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedMove;    
    [SerializeField] private Animator _animator;
    [SerializeField] private MobileController _mobileController;
    [SerializeField] private CharacterController _characterController;
    private float _graviryForce = - 9.8f;
    private Vector3 _movement;   

    private void Update()
    {
        MovementPlayer();
        AnimatorPlayer();        
    }
    private void MovementPlayer()
    {      
        _movement = new Vector3(_mobileController.GetHorizontalInput(), 0, _mobileController.GetVerticalInput());
        _movement = Vector3.ClampMagnitude(_movement, 1f);
        Vector3 dir = Vector3.RotateTowards(transform.forward, _movement, _speedMove, 0.0f);
        transform.rotation = Quaternion.LookRotation(dir);
        _movement.y = _graviryForce;
        _characterController.Move(_movement * _speedMove * Time.deltaTime);
    }   
    private void AnimatorPlayer()
    {
        _animator.SetBool("Move", _movement.x != 0 || _movement.z != 0);
    }           
}
