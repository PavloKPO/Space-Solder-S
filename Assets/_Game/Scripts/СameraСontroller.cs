using UnityEngine;

public class СameraСontroller : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _trackingSpeed;

    private Vector3 _target;           
       
    void Update()
    {
        Vector3 currentPosition = Vector3.Lerp(transform.position, _target, _trackingSpeed *Time.deltaTime);
        transform.position = currentPosition;

        _target = new Vector3(_player.position.x, transform.position.y, transform.position.z);
    }
}
