using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalText : MonoBehaviour
{
    public Boss boss;
    public TextMeshProUGUI finalText;
    private float transparency = 0.0f;

    void Update()
    {
        finalText.alpha = transparency;
        if (boss.death == true)
        {
            transparency += 0.1f;
        }

    }
}
