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
        if (other.gameObject.tag == "Player")
            _isOpen = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            _isOpen = false;
    }
    private void Update()
    {
        OpenDoor();
        CloseDoor();
    }
    private void OpenDoor()
    {
        if (_isOpen == true)
        {
            _door.Translate(_doorSpeed * Time.deltaTime, 0, 0);
            if (_door.position.x > _doorEndPosition.x)
                _door.position = _doorEndPosition;
        }
    }
    private void CloseDoor()
    {
        if (_isOpen == false && _door.position != _doorStartPosition)
        {
            _door.Translate(-_doorSpeed * Time.deltaTime, 0, 0);
            if (_door.position.x < _doorStartPosition.x)
                _door.position = _doorStartPosition;
        }
    }
}
