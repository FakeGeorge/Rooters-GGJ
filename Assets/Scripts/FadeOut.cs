using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{

    public Image fadeImage;

    public CanvasGroup myUI;


    [Range(0.1f, 1f)]
    public float fadespeed;
    public int drawDepth = -1000;

    public float alpha = 1f;
    private float fadeDir = -1f;

    public bool activarFade = false;
    public bool fadeIn = true;

    private void Update()
    {
        if (fadeIn == false && activarFade == true)
        {
            alpha += fadeDir * fadespeed * Time.unscaledDeltaTime;
            alpha = Mathf.Clamp01(alpha);

            myUI.alpha = alpha;
        }
    }
}
