using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject descriptionText;

    public void Start()
    {
        descriptionText.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionText.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionText.SetActive(false); 
    }
}
