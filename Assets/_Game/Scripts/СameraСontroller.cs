using UnityEngine;

public class СameraСontroller : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _camera;
    private Vector3 _offSet;

    private void Start()
    {
        _offSet = _camera.position - _player.position;
    }
    private void LateUpdate()
    {
        Vector3 desiredPosition = _player.position + _offSet;
        _camera.position = desiredPosition;
    }


    
       
    
}
