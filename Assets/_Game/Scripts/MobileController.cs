using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobileController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Image _touchMarker;
    [SerializeField] private Image _joystic;
    private Vector2 _inputVector;

    private void Start()
    {
        _joystic = GetComponent<Image>();
        _touchMarker = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        _inputVector = Vector2.zero;
        _touchMarker.rectTransform.anchoredPosition = Vector2.zero;
    }
    
        

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystic.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x/_touchMarker.rectTransform.sizeDelta.x);
            pos.y = (pos.y/_touchMarker.rectTransform.sizeDelta.y);

            _inputVector = new Vector2(pos.x * 2 - 1, pos.y * 2 - 1);
            _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;

            _touchMarker.rectTransform.anchoredPosition = new Vector2(_inputVector.x * (_joystic.rectTransform.sizeDelta.x/2), _inputVector.y * (_joystic.rectTransform.sizeDelta.y/2));
        }
    }
}
