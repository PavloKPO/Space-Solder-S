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
       float _horMovement = Input.GetAxis("Horizontal");
       float _verMovement = Input.GetAxis("Vertical");
        transform.position += new Vector3(_horMovement, 0, _verMovement).normalized * _speedPlayer * Time.deltaTime;       
        
        _animator.SetFloat("ForAndBack", _verMovement);
        _animator.SetFloat("RightAndLeft", _horMovement);
    }
}
