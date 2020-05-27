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
        Color color = trident.color;
        color.a = transparency/maxValue;
        trident.color = color;
    }
}
