using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    public SelectedMenu[] buttons;
    public GameObject[] pages;

    //Music
    public float VolumeG = 1f;
    public float VolumeM = 0.5f;
    public float VolumeUI = 0.5f;
    public Slider volumeGSlider;
    public Slider volumeMSlider;
    public Slider volumeUISlider;
    public TMPro.TextMeshProUGUI volumeGText;
    public TMPro.TextMeshProUGUI volumeMText;
    public TMPro.TextMeshProUGUI volumeUIText;

    SelectedMenu clicked;
    [HideInInspector] public static SettingsManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        int idx = 0;
        foreach(SelectedMenu btn in buttons)
        {
            btn.index = idx;
            idx++;
        }

        ResetValue();

    }

    private void ChangePage(int idx)
    {
        for(int i = 0; i < pages.Length; i++)
        {
            if (i == idx) pages[i].SetActive(true);
            else pages[i].SetActive(false);
        }
    }

    public void ClickOn(int idx)
    {
        clicked?.UnSelected();
        clicked = buttons[idx];
        ChangePage(idx);
    }

    public void ChangedSlider(int idx)
    {
        if(idx == 0)
        {
            VolumeG = volumeGSlider.value;
        }
        if (idx == 1)
        {
            VolumeM = volumeMSlider.value;
        }
        if (idx == 2)
        {
            VolumeUI = volumeUISlider.value;
        }

        Print();
    }


    public void ResetValue()
    {
        volumeGSlider.value = 1f;
        volumeMSlider.value = 0.5f;
        volumeUISlider.value = 0.5f;

        ChangedSlider(0);
        ChangedSlider(1);
        ChangedSlider(2);
    }

    private void Print()
    {
        volumeGText.text = Mathf.Round(VolumeG * 100) + "%";
        volumeMText.text = Mathf.Round(VolumeM * 100) + "%";
        volumeUIText.text = Mathf.Round(VolumeUI * 100) + "%";
    }


}
