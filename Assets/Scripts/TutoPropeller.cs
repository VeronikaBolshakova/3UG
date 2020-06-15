using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutoPropeller : MonoBehaviour
{
    public GameObject player;
    public movement playerScript;
    public TextMeshProUGUI text_Tuto;
    private float transparency = 0.0f;
    private bool done = false;
    void Update()
    {
        text_Tuto.alpha = transparency;
        if (playerScript.GetPropellerState() == true && done == false)
        {
            transparency += 0.1f;
            if (transparency > 1.0f)
            {
                done = true;
            }
        }
        if (player.transform.position.x > 4 && done == true)
        {
            transparency -= 0.1f;
        }
    }
}
