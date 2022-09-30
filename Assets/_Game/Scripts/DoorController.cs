using UnityEngine;
public class DoorController : MonoBehaviour
{
    [SerializeField] private Transform _door;
    [SerializeField] private Vector3 _doorEndPosition;
    [SerializeField] private Vector3 _doorStartPosition;
    [SerializeField] private float _doorSpeed;
    private bool _isOpen = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
            _isOpen = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
            _isOpen = false;
    }
    private void Update()
    {
        OpenDoor();
        CloseDoor();
    }
    private void OpenDoor()
    {
        if (_isOpen)
        {
            _door.Translate(_doorSpeed * Time.deltaTime, 0, 0);
            if (_door.position.x > _doorEndPosition.x)
                _door.position = _doorEndPosition;
        }
    }
    private void CloseDoor()
    {
        if (!_isOpen  && _door.position != _doorStartPosition)
        {
            _door.Translate(-_doorSpeed * Time.deltaTime, 0, 0);
            if (_door.position.x < _doorStartPosition.x)
                _door.position = _doorStartPosition;
        }
    }
}
