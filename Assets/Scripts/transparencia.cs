using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transparencia : MonoBehaviour
{
    
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var color = gameObject.GetComponent<Renderer>().material.color;
        gameObject.GetComponent<Renderer>().material.color = new Color(color.r,color.g,color.b,0.5f);

        Debug.Log("a");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var color = gameObject.GetComponent<Renderer>().material.color;
        gameObject.GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 1f);
    }
}
