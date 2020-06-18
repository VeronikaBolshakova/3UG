using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Aguita : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public Boss boss;
    private float transparency = 0.0f;
    private bool done = false;
    private bool done2 = false;
    void Update()
    {

        if (player.transform.position.x > 56 && done == false)
        {
            transparency += 0.1f;
            text1.alpha = transparency;
            if (transparency > 1.0f)
            {
                done = true;
            }
        }
        if (player.transform.position.x > 70 && done == true)
        {
            if (transparency > 0.0f)
            {
                transparency -= 0.1f;
                text1.alpha = transparency;
            }

        }
        if (player.transform.position.x < 70 && boss.death == true && player.transform.position.y < 0 && done2 == false)
        {
            text2.alpha = transparency;
            transparency += 0.1f;
            if (transparency > 1.0f)
            {
                done2 = true;
            }
        }
    }
}

