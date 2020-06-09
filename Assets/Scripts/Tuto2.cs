using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Tuto2 : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI text_Tuto;
    private float transparency = 0.0f;
    private bool done = false;
    void Update()
    {
        text_Tuto.alpha = transparency;
        if (player.transform.position.x >= -10 && done == false)
        {
            transparency += 0.1f;
            text_Tuto.alpha = transparency;
            if (transparency > 1.0f)
            {
                done = true;
            }
        }
        if (player.transform.position.x >= -4 && done == true)
        {
            transparency -= 0.1f;
            text_Tuto.alpha = transparency;
        }
    }
}
