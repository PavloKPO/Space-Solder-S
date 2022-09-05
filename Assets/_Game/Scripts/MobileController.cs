using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobileController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform _touchMarker;
    [SerializeField] private RectTransform _joystic;        
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _touchMarker.anchoredPosition = Vector2.zero;
    }         
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 inputVector;        
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystic, eventData.position, eventData.pressEventCamera, out inputVector))
        {
            inputVector.x = (inputVector.x/_touchMarker.sizeDelta.x);
            inputVector.y = (inputVector.y/_touchMarker.sizeDelta.y);

            inputVector = new Vector2(inputVector.x, inputVector.y);
            inputVector = Vector2.ClampMagnitude(inputVector, 1f);

            _touchMarker.anchoredPosition = Vector2.Scale(inputVector, _joystic.sizeDelta) / 2f;
        }
    }
}
