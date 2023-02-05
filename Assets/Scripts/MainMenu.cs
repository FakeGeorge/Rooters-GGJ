using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Settings settings;
    [SerializeField] AudioClip BGMIngame, BGMMenu;
    [SerializeField] AudioClip Click;
    [SerializeField] float timeforStart; //por si animación
    [SerializeField] GameObject creditos;

    [SerializeField] Button start, options, credits, exit;

    private void Start()
    {
        settings = GameObject.Find("Settings").GetComponent<Settings>();
    }

    public void PlaySound(AudioClip clip)
    {
        Debug.Log("1");
        settings.PlaySFX(clip);
    }

    public void StartGame()
    {
        StopButtons();
        Invoke("ChangeSceneToGame", 2f);
    }

    void StopButtons()
    {
        start.interactable = false;
        options.interactable = false;
        credits.interactable = false;
        exit.interactable = false;
    }
    void ChangeSceneToGame()
    {
        settings.changeBGM(BGMIngame);
        SceneManager.LoadScene("Game"); //Juego = nombre de la escena del juego
    }

    public void Settings()
    {
        Invoke("SettingsNow", 1);
    }

    void SettingsNow()
    {
        settings.transform.GetChild(0).gameObject.SetActive(true);
    }
  
    public void Creditos()
    {
        Invoke("CreditosNow", 1);
    }

    void CreditosNow()
    {
        creditos.SetActive(true);
    }

    public void CreditosFuera()
    {
        creditos.SetActive(false);
    }
    public void Exit()
    {
        Invoke("ExitNow", 1);
    }

    void ExitNow()
    {
        Application.Quit();
    }
}
