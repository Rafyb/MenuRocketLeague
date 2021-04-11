using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JukeBox : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource audioSource;

    public Sprite play;
    public Sprite pause;
    public Image image;

    public TMPro.TextMeshProUGUI Text;

    int _idx;
    bool playmode;

    void Start()
    {
        _idx = Random.Range(0, clips.Length);
        Play();
    }

    private void Update()
    {
        if (audioSource.time >= audioSource.clip.length) Next();

        audioSource.volume = SettingsManager.Instance.VolumeM * SettingsManager.Instance.VolumeG;
    }

    public void Next()
    {
        if (_idx == clips.Length - 1) _idx = 0;
        else _idx++;
        Play();
    }

    public void Back()
    {
        if (_idx == 0) _idx = clips.Length - 1;
        else _idx--;
        Play();
    }

    public void Switch()
    {
        if (playmode)
        {
            audioSource.Pause();
            image.sprite = play;
        }
        else
        {
            audioSource.Play();
            image.sprite = pause;
        }
        playmode = !playmode;


    }

    private void Play()
    {
        audioSource.Pause();

        Text.text = clips[_idx].name;
        audioSource.clip = clips[_idx];

        if (!playmode)
        {
            image.sprite = pause;
            playmode = true;
        }
        audioSource.Play();
    }
}
