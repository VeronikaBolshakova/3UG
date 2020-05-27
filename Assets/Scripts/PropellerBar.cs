using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropellerBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public GameObject propellerBar;

    public void Activate()
    {
        propellerBar.SetActive(true);
    }



    public void SetPropellerSlider(float power)
    {
        slider.value = power;

        fill.color = gradient.Evaluate(slider.value);
    }
}
