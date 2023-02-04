using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Settings settings;
    [SerializeField] AudioClip BGMIngame;
    [SerializeField] float timeforStart; //por si animación
    [SerializeField] GameObject creditos;
    public void StartGame()
    {
        StartCoroutine("StartAnim");
        Invoke("ChangeSceneToGame", 2f);
    }

    IEnumerator StartAnim()
    {
        yield return new WaitForSeconds(timeforStart);
        settings.changeBGM(BGMIngame);

    }

    void ChangeSceneToGame()
    {
        SceneManager.LoadScene("Juego"); //Juego = nombre de la escena del juego
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Creditos()
    {
        creditos.SetActive(true);
    }

    public void CreditosFuera()
    {
        creditos.SetActive(false);
    }

}
