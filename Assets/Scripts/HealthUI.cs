using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthUI : MonoBehaviour
{
    public Image health;
    private float maxValue = 10.0f;

    public void SetTransparency(float transparency)
    {
        Color color = health.color;
        color.a = transparency / maxValue;
        health.color = color;
    }
}
