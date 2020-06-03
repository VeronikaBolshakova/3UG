using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TridentUI : MonoBehaviour
{
    public Image trident;
    private float maxValue = 5.0f;

    public void SetTransparency(float transparency)
    { 
        if(transparency < maxValue)
        {
           if(transparency < 2.0f) {
                trident.color = new Color(0.6f, 0.6f, 0.6f, 2.0f / maxValue);
           }
            else {
                trident.color = new Color(0.6f, 0.6f, 0.6f, transparency / maxValue);
            }
        }
        else
        {
            trident.color = new Color(1f, 1f, 1f, transparency / maxValue);
        }
    }
}
