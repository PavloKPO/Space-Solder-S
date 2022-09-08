using UnityEngine;
using UnityEngine.EventSystems;

public class MobileController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform _touchMarker;
    [SerializeField] private RectTransform _joystick;
    private Vector2 _inputVector;
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _inputVector = Vector2.zero;
        _touchMarker.anchoredPosition = Vector2.zero;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystick, eventData.position, eventData.pressEventCamera, out _inputVector))
        {
            _inputVector /=_touchMarker.sizeDelta;
            _inputVector = Vector2.ClampMagnitude(_inputVector, 1f);
            _touchMarker.anchoredPosition = Vector2.Scale(_inputVector, _joystick.sizeDelta) / 2f;
        }
    }
    public float GetHorizontal()
    {
        if (_inputVector.x != 0)
            return _inputVector.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float GetVertical()
    {
        if (_inputVector.y != 0)
            return _inputVector.y;
        else
            return Input.GetAxis("Vertical");
    }
}
    
