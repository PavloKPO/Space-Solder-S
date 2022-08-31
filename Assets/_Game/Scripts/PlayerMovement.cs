using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedPlayer;    
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

        transform.position += movement * _speedPlayer * Time.deltaTime;

        _animator.SetFloat("ForAndBack", verMovement);
        _animator.SetFloat("RightAndLeft", horMovement);
    }
}
