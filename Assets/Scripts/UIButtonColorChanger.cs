using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//버튼 위에 마우스가 호버 상태이거나 클릭시 색을 변하게 하는 코드
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