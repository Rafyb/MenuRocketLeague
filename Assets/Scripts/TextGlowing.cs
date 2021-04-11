using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGlowing : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Text;

    public Color color1;
    public Color color2;

    bool swap;

    // Start is called before the first frame update
    void Start()
    {
        Text.color = color1;
        swap = false;
        SwapColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwapColor()
    {
        Text.DOKill();
        swap = !swap;
        if (swap) Text.DOColor(color2, 0.5f).OnComplete(SwapColor);
        else Text.DOColor(color1, 0.5f).OnComplete(SwapColor);

    }
}
