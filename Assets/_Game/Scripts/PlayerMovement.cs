using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedMove;    
    private Animator _animator;
    private MobileController _mobileController;
    private Vector3 _movement;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _mobileController = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileController>();
    }    
    private void Update()
    {
         MovementPlayer();        
    }
    private void MovementPlayer()
    {        
        float horMovement = _mobileController.Horizontal();
        float verMovement = _mobileController.Vertical();
        _movement = new Vector3(horMovement, 0, verMovement);
        _movement = Vector3.ClampMagnitude(_movement, 1.0f);

        if (horMovement > 0.25f || horMovement < -0.25f || verMovement > 0.25f || verMovement < -0.25f)
        {                       
            if (Vector3.Angle(Vector3.forward, _movement) > 1f || Vector3.Angle(Vector3.forward, _movement) == 0)
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
