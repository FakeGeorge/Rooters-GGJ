using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    [SerializeField] GameObject pause;
    Settings settings;

    [SerializeField] AudioClip Click;
    private void Start()
    {
        settings = GameObject.Find("Settings").GetComponent<Settings>();
    }
    public void PlaySound(AudioClip clip)
    {
        settings.PlaySFX(clip);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settings.gameObject.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                settings.CloseMenu();
            }
            else if (pause.activeInHierarchy)
            {
                ClosePause();
            }
            else
            {
                OpenPause();
            }
        }
    }

    public void OpenPause()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
    }

    public void ClosePause()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

    public void OpenSettings()
    {
        settings.OpenMenu();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu"); //MainMenu = escena de inicio
    }
}
