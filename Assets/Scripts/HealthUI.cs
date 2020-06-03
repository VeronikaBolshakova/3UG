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
        if (transparency < maxValue)
        {
            if (transparency < 2.0f)
            {
                health.color = new Color(0.6f, 0.6f, 0.6f, 2.0f / maxValue);
            }
            else
            {
                health.color = new Color(0.6f, 0.6f, 0.6f, transparency / maxValue);
            }
        }
        else
        {
            health.color = new Color(1f, 1f, 1f, transparency / maxValue);
        }
    }
}
