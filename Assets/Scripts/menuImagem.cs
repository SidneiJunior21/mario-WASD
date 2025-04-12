using UnityEngine;
using UnityEngine.UI;

public class menuImagem : MonoBehaviour
{
    void Start()
    {
        Image bgImage = GetComponent<Image>();
        RectTransform rt = bgImage.rectTransform;
        
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;
        
        rt.SetAsFirstSibling();
    }
}