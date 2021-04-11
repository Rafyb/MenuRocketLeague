using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedMenu : MonoBehaviour
{
    public int index;
    public GameObject arrow;

    public void OnClick()
    {
        SettingsManager.Instance.ClickOn(index);
        gameObject.GetComponent<ButtonMainMenu>().OnPointerEnter();
        gameObject.GetComponent<ButtonMainMenu>().clicked = true;
        arrow.SetActive(true);
    }

    public void UnSelected()
    {
        gameObject.GetComponent<ButtonMainMenu>().clicked = false;
        gameObject.GetComponent<ButtonMainMenu>().OnPointerExit();
        arrow.SetActive(false);
    }

}
