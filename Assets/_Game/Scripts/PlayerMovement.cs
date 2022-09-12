using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedMove;    
    [SerializeField] private Animator _animator;
    [SerializeField] private MobileController _mobileController;
    [SerializeField] private float _turningCircle;    
        
    private void Update()
    {
         MovementPlayer();        
    }
    private void MovementPlayer()
    {        
        float horMovement = _mobileController.GetHorizontalInput();
        float verMovement = _mobileController.GetVerticalInput();

        Vector3 movement = new Vector3(horMovement, 0, verMovement);
        movement = Vector3.ClampMagnitude(movement, 1.0f);

        Vector3 dir = Vector3.RotateTowards(transform.forward, movement, _speedMove, 0.0f);
        transform.rotation = Quaternion.LookRotation(dir);

        if (movement.magnitude > _turningCircle)
        {              
            transform.position += movement * _speedMove * Time.deltaTime;            
            _animator.SetBool("Move", true);          
        }
        else        
            _animator.SetBool("Move", false);        
    }    
}
