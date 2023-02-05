using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Texture2D fadeTexture;
    public FadeOut fadeOut_script;

    [Range(0.1f, 1f)]
    public float fadespeed;
    public int drawDepth = -1000;

    private float alpha = 0f;
    private float fadeDir;

    private void OnGUI()
    {
        if (fadeOut_script.fadeIn == true && fadeOut_script.activarFade == true)
        {
            Debug.Log("a");
            fadeDir = 1f;
            alpha += fadeDir * fadespeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);

            Color newColor = GUI.color;
            newColor.a = alpha;

            GUI.color = newColor;

            GUI.depth = drawDepth;

            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
        }

    }
    
}
