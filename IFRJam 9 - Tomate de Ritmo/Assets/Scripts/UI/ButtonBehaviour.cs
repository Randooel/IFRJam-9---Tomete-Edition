using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _img;
    [SerializeField] private Sprite _default, _pressed, _highlighted;
    [SerializeField] private AudioClip _compressClip, _uncompressClip;
    [SerializeField] private AudioSource _source;
    private bool _isHovered = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _img.sprite = _highlighted;
        _isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _img.sprite = _default;
        _isHovered = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _img.sprite = _pressed;
        _source.PlayOneShot(_compressClip);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _img.sprite = _default;
        _source.PlayOneShot(_uncompressClip);
    }
    
    
}
