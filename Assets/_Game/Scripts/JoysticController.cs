
using UnityEngine;

public class JoysticController : MonoBehaviour
{
    [SerializeField] private Transform _touchMarker;
    private Vector3 _tàrgetVector;

    private void Start()
    {
        _touchMarker.position = transform.position;
    }

    private void Update()
    {
        Joystic();
    }

    private void Joystic()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = Input.mousePosition;
            _tàrgetVector = touchPos - transform.position;

            if (_tàrgetVector.magnitude < 100)
            {
                _touchMarker.position = touchPos;
            }            
                
            
        }
        else
        {
            _touchMarker.position = transform.position;
        }       
            

        
    }
}
