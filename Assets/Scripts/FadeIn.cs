using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public CanvasGroup myUI;

    public FadeOut fadeOut_script;

    [Range(0.1f, 1f)]
    public float fadespeed;
    public int drawDepth = -1000;

    public static float alpha = 0f;
    private float fadeDir;

    private void Update()
    {
        if (fadeOut_script.fadeIn == true && fadeOut_script.activarFade == true)
        {
            fadeDir = 1f;
            alpha += fadeDir * fadespeed * Time.unscaledDeltaTime;
            alpha = Mathf.Clamp01(alpha);

            myUI.alpha = alpha;
        }
    }
    
}
