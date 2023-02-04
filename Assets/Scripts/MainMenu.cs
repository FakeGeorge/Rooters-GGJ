using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Settings settings;
    [SerializeField] AudioClip BGMIngame;
    [SerializeField] float timeforStart; //por si animaci�n
    public void StartGame()
    {
        StartCoroutine("StartAnim");
    }

    IEnumerator StartAnim()
    {
        yield return new WaitForSeconds(timeforStart);
        settings.changeBGM(BGMIngame);
        SceneManager.LoadScene("Juego"); //Juego = nombre de la escena del juego
    }

    public void Exit()
    {
        Application.Quit();
    }

}
