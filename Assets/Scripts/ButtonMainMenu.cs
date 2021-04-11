using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMainMenu : MonoBehaviour
{
    public Image ImageOutline;
    public TMPro.TextMeshProUGUI Text;
    public TMPro.TextMeshProUGUI textSub;

    public Color ColorInitial;
    public Color ColorInitialText;

    public Color ColorSelected;
    public Color ColorSelectedText;

    public float decal = 12f;
    public bool clicked = false;


    private bool _hidden = false;

    public void Start()
    {
        ImageOutline.DOColor(ColorInitial, 0.2f);
        Text.DOColor(ColorInitialText, 0.2f);

    }

    public void OnPointerEnter()
    {
        if (_hidden || clicked) return;

        ImageOutline.DOKill();
        ImageOutline.DOColor(ColorSelected, 0.2f);

        Text.rectTransform.DOLocalMove(new Vector3(0f, decal, 0f), 0.2f);
        Text.DOColor(ColorSelectedText, 0.2f);

        textSub?.DOKill();
        textSub?.DOFade(1, 0.2f);
    }

    public void OnPointerExit()
    {
        if (_hidden || clicked) return;

        ImageOutline.DOKill();
        ImageOutline.DOColor(ColorInitial, 0.2f);

        Text.rectTransform.DOLocalMove(Vector3.zero, 0.2f);
        Text.DOColor(ColorInitialText, 0.2f);

        textSub?.DOKill();
        textSub?.DOFade(0, 0.2f);
    }



}
