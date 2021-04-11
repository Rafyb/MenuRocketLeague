using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSwapImg : MonoBehaviour
{
    public Sprite baseImg;
    public Sprite overImg;

    public Image imageButton;

    public void ImageOver()
    {
        imageButton.sprite = overImg;
    }

    public void ImageBase()
    {

        imageButton.sprite = baseImg;
    }
}
