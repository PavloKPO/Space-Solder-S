using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedMove;    
    [SerializeField] private Animator _animator;
    [SerializeField] private MobileController _mobileController;
    [SerializeField] private float _turning—ircle;
    private Vector3 _movement;
        
    private void Update()
    {
         MovementPlayer();        
    }
    private void MovementPlayer()
    {        
        float horMovement = _mobileController.GetHorizontal();
        float verMovement = _mobileController.GetVertical();
        _movement = new Vector3(horMovement, 0, verMovement);
        _movement = Vector3.ClampMagnitude(_movement, 1.0f);

        if (_movement.magnitude > _turning—ircle)
        {                      
            RotationPlayer();            

            transform.position += _movement * _speedMove * Time.deltaTime;            
            _animator.SetBool("Move", true);          
        }
        else
        {
            _animator.SetBool("Move", false);
            RotationPlayer();
        }
    } 
    
    private void RotationPlayer()
    {
        Vector3 dir = Vector3.RotateTowards(transform.forward, _movement, _speedMove, 0.0f);
        transform.rotation = Quaternion.LookRotation(dir);
    }

}
