using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedPlayer;

    private Animator _myAnimator;
    private float _horMovement;
    private float _verMovement;
    void Start()
    {
        _myAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        _horMovement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(_horMovement, 0, 0) * _speedPlayer * Time.deltaTime;

        _verMovement = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, 0, _verMovement) * _speedPlayer * Time.deltaTime;

        _myAnimator.SetFloat("ForAndBack", _verMovement);
        _myAnimator.SetFloat("RightAndLeft", _horMovement);
    }
}
