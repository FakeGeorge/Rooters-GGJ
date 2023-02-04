using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] float timeforStart; //por si animación
    public void StartGame()
    {
        StartCoroutine("StartAnim");
    }

    IEnumerator StartAnim()
    {
        yield return new WaitForSeconds(timeforStart);
        SceneManager.LoadScene("Juego"); //Juego = nombre de la escena del juego
    }

    public void Exit()
    {
        Application.Quit();
    }

}
