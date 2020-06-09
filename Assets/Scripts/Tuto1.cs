using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tuto1 : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI text_Tuto;
    private float transparency = 1f;
    void Update()
    {
        if(player.transform.position.x >= -10) { 
            text_Tuto.alpha = transparency;
            transparency -= 0.1f;
        }
    }
}
