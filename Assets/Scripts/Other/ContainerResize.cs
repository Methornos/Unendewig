using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ContainerResize : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform _container = default;
    [SerializeField]
    private RectTransform _limitLine = default;
    [SerializeField]
    private GameObject _commandObjects = default;

    private RectTransform _self = default;
    private Animation _containerAnimation = default;

    private Vector2 _screenSize = default;

    private float _pressedPosition = 0;

    private int _screenOffset = 0;

    private void Awake()
    {
        _self = GetComponent<RectTransform>();
        _containerAnimation = _container.GetComponent<Animation>();

        _screenSize = new Vector2(Screen.width, Screen.height);
        _screenOffset = (int)((_screenSize.y - 1920) / 2);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _pressedPosition = eventData.position.y;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_self.sizeDelta.y <= 370) _commandObjects.SetActive(false);
        else _commandObjects.SetActive(true);

        _self.sizeDelta = new Vector2(0, eventData.position.y);
        _container.sizeDelta = new Vector2(0, _screenSize.y - (_screenOffset * 2) - _self.sizeDelta.y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.position.y >= _limitLine.anchoredPosition.y / 2 + _screenOffset)
        {
            _container.sizeDelta = new Vector2(0, 1520);
            _container.localScale = new Vector3(1, 1, 1);
            _container.gameObject.SetActive(true);
            _self.sizeDelta = new Vector2(0, 400);
            _commandObjects.SetActive(true);
        }
        else
        {
            _containerAnimation.Play();
            _self.sizeDelta = new Vector2(0, 80);
            _commandObjects.SetActive(false);
        }
    }
}
