using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum Epocas { prehistoria, medievo, actual, futuro};
    public static Epocas miEpoca;

    // Start is called before the first frame update
    void Start()
    {
        miEpoca = Epocas.prehistoria;
    }

}
