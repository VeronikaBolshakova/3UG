using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextDoor : MonoBehaviour
{
    public GameObject player;
    public movement playerScript;
    public TextMeshProUGUI text;
    private float transparency = 0;
    void Update()
    {
        player = GameObject.Find("Player");
        if (this.transform.position.x - player.transform.position.x <= 4 && playerScript.key == false)
        {
            text.alpha = transparency;
            transparency += 0.1f;
        }
        if (playerScript.key == true)
        {
            text.alpha = transparency;
            transparency -= 0.1f;
        }

    }
}
