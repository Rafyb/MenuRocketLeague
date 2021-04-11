using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public CanvasGroup startMenu;
    public CanvasGroup mainMenu;
    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;
    public GameObject quitterMenu;

    public Image logoFade;
    public Image imageFade;

    public AudioClip[] clips;
    public AudioSource audioSource;

    public int state = -1;


    private void Start()
    {
        startMenu.alpha = 1;
        mainMenu.alpha = 0;

        logoFade.DOFade(0, 1.5f).OnComplete( ()=>
        {
            imageFade.DOFade(0, 1f).OnComplete(() =>
            {
                state = 0;
            });
        });

        optionGroup.gameObject.SetActive(false);
    }

    public void PlaySound(int idx)
    {
        audioSource.Pause();
        audioSource.volume = SettingsManager.Instance.VolumeUI * SettingsManager.Instance.VolumeG;
        audioSource.clip = clips[idx];
        audioSource.Play();
    }

    public void OpenMenu()
    {
        optionGroup.gameObject.SetActive(true);
        optionGroup.DOFade(1, 1f);
        SettingsManager.Instance.ClickOn(0);


        mainGroup.DOFade(0, 1f).OnComplete(()=> { mainGroup.gameObject.SetActive(false); });

        Camera.Instance.SwitchCam(2);
        Camera.Instance.LockCam(true);
    }

    public void CloseMenu()
    {
        mainGroup.gameObject.SetActive(true);
        mainGroup.DOFade(1, 1f);

        optionGroup.DOFade(0, 1f).OnComplete(() => { optionGroup.gameObject.SetActive(false); });

        Camera.Instance.SwitchCam(1);
        Camera.Instance.LockCam(false);
    }


    public void OnCLickPlay()
    {
        imageFade.DOFade(1, 0.8f).OnComplete(FadeComplete);

    }

    private void FadeComplete()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quitter()
    {
        quitterMenu.SetActive(true);
        Camera.Instance.LockCam(true);
    }

    public void QuitterNon()
    {
        quitterMenu.SetActive(false);
        Camera.Instance.LockCam(false);
    }

    public void QuitterOui()
    {
        Application.Quit();
    }




    private void Update()
    {
        if(state == 0)
        {
            if (Input.anyKey)
            {
                state = 1;
                audioSource.clip = clips[0];
                audioSource.Play();
                Camera.Instance.SwitchCam(1);
                Camera.Instance.LockCam(false);
            }
        }
        if (state == 1)
        {
            startMenu.alpha = Mathf.Lerp(startMenu.alpha, 0, 5f * Time.deltaTime);
            mainMenu.alpha = Mathf.Lerp(mainMenu.alpha, 1, 5f * Time.deltaTime);
            if(startMenu.alpha <= 0.05f)
            {
                startMenu.alpha = 0f;
                mainMenu.alpha = 1f;
                state = 2;
            }
        }
    }
}
