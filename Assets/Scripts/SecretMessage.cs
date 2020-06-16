using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SecretMessage : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI text_Tuto;
    private float transparency = 0.0f;
    private bool done = false;
    void Update()
    {
        text_Tuto.alpha = transparency;
        if (player.transform.position.x < -15 && done == false && player.transform.position.y > 5)
        {
            transparency += 0.1f;
            if (transparency > 1.0f)
            {
                done = true;
            }
        }
        if (player.transform.position.x > -15 && done == true)
        {
            transparency -= 0.1f;
        }
    }
}
