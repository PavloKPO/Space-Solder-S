using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedMove;    
    private Animator _animator;
    private CharacterController _characterController;
    private Vector3 _moveVector;
    


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    
    private void Update()
    {
        //MovementPlayer();
        CharacterMove();
    }

    private void MovementPlayer()
    {
        float horMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horMovement, 0, verMovement);
        movement = Vector3.ClampMagnitude(movement, 1.0f);

        transform.position += movement * _speedMove * Time.deltaTime;

        _animator.SetFloat("ForAndBack", verMovement);
        _animator.SetFloat("RightAndLeft", horMovement);
    }

    private void CharacterMove()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = Input.GetAxis("Horizontal") * _speedMove;
        _moveVector.z = Input.GetAxis("Vertical") * _speedMove;

        if(Vector3.Angle(Vector3.forward, _moveVector) > 1f || Vector3.Angle(Vector3.forward, _moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, _moveVector, _speedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        _characterController.Move(_moveVector * Time.deltaTime);

        _animator.SetFloat("ForAndBack", _moveVector.z);
        _animator.SetFloat("RightAndLeft", _moveVector.x);
    }


}
