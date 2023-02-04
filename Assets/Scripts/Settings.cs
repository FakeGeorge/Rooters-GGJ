using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;

    [SerializeField] AudioMixer AM;
    [SerializeField] AudioSource BGM, SFX;
    //[SerializeField] AudioClip BGM_Menu, BGM_Game;

    public void PlaySFX(AudioClip clip)
    {
        SFX.clip = clip;
        SFX.pitch = Random.Range(0.8f, 1.2f);
        SFX.Play();
    }

    public void changeBGM(AudioClip clip)
    {
        BGM.clip = clip;
        BGM.Stop();
        BGM.Play();
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject); //esto o poner otro en la otra escena
        ChangeVolumeBGM(-30f);
        ChangeVolumeSFX(-30f);
    }

    public void OpenMenu()
    {
        settingsMenu.SetActive(true);
    }

    public void CloseMenu() 
    {
        settingsMenu.SetActive(false);
    }

    public void FullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void ChangeVolumeSFX(float volume)
    {
        AM.SetFloat("volSFX", volume);
    }

    public void ChangeVolumeBGM(float volume)
    {
        AM.SetFloat("volBGM", volume);
    }

    public void ChangeQuality(float index)
    {
        QualitySettings.SetQualityLevel((int) index);
    }
}
