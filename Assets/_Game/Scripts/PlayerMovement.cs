using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedMove;    
    private Animator _animator;      

    private void Start()
    {
        _animator = GetComponent<Animator>();        
    }

    
    private void Update()
    {
         MovementPlayer();        
    }

    private void MovementPlayer()
    {
        float horMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horMovement, 0, verMovement);
        movement = Vector3.ClampMagnitude(movement, 1.0f);

        if(Vector3.Angle(Vector3.forward, movement) > 1f || Vector3.Angle(Vector3.forward, movement) == 0)
        {
            Vector3 dir = Vector3.RotateTowards(transform.forward, movement, _speedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(dir);
        }

        transform.position += movement * _speedMove * Time.deltaTime;

        _animator.SetFloat("ForAndBack", verMovement);
        _animator.SetFloat("RightAndLeft", horMovement);
    }   

}
