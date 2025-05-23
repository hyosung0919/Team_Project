using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Î≤ÑÌäº ?ÑÏóê ÎßàÏö∞?§Í? ?∏Î≤Ñ ?ÅÌÉú?¥Í±∞???¥Î¶≠???âÏùÑ Î≥Ä?òÍ≤å ?òÎäî ÏΩîÎìú
public class UIButtonColorChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Color normalColor = Color.white;
    public Color hoverColor = new Color(0.9f, 0.9f, 0.9f);
    public Color clickColor = new Color(0.7f, 0.7f, 0.7f);

    private Image buttonImage;

    private void Awake()
    {
        buttonImage = GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.color = normalColor;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonImage != null)
        {
            buttonImage.color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonImage != null)
        {
            buttonImage.color = normalColor;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (buttonImage != null)
        {
            buttonImage.color = clickColor;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (buttonImage != null)
        {
            buttonImage.color = hoverColor;
        }
    }
}