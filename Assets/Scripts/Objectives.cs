using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Objectives : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI obj1;
    public TextMeshProUGUI obj2;
    public TextMeshProUGUI obj3;
    public TextMeshProUGUI obj4;
    public TextMeshProUGUI obj5;
    public TextMeshProUGUI obj6;
    public TextDoor textDoor;
    public Boss boss;
    private int obj;

    void start()
    {
        obj = 0;
    }

    void Update()
    {
        switch (obj)
        {
            case 0:
                if (player.GetComponent<movement>().propeller)
                {
                    obj = 1;
                }
                break;
            case 1:
                if(textDoor.notKey == true)
                {
                    obj = 2;
                }
                if (player.GetComponent<movement>().key == true)
                {
                    obj = 3;
                }
                break;
            case 2:
                if(player.GetComponent<movement>().key == true)
                {
                    obj = 3;
                }
                break;
            case 3:
                if (player.transform.position.x > 56)
                {
                    obj = 4;
                }
                break;
            case 4:
                if(boss.death == true)
                {
                    obj = 5;
                }
                break;
        }
        if(obj == 0)
        {
            obj1.alpha = 1.0f;
            obj2.alpha = 0.0f;
            obj3.alpha = 0.0f;
            obj4.alpha = 0.0f;
            obj5.alpha = 0.0f;
            obj6.alpha = 0.0f;
        }
        if (obj == 1)
        {
            obj1.alpha = 0.0f;
            obj2.alpha = 1.0f;
            obj3.alpha = 0.0f;
            obj4.alpha = 0.0f;
            obj5.alpha = 0.0f;
            obj6.alpha = 0.0f;
        }
        if (obj == 2)
        {
            obj1.alpha = 0.0f;
            obj2.alpha = 0.0f;
            obj3.alpha = 1.0f;
            obj4.alpha = 0.0f;
            obj5.alpha = 0.0f;
            obj6.alpha = 0.0f;
        }
        if (obj == 3)
        {
            obj1.alpha = 0.0f;
            obj2.alpha = 0.0f;
            obj3.alpha = 0.0f;
            obj4.alpha = 1.0f;
            obj5.alpha = 0.0f;
            obj6.alpha = 0.0f;
        }
        if (obj == 4)
        {
            obj1.alpha = 0.0f;
            obj2.alpha = 0.0f;
            obj3.alpha = 0.0f;
            obj4.alpha = 0.0f;
            obj5.alpha = 1.0f;
            obj6.alpha = 0.0f;
        }
        if (obj == 5)
        {
            obj1.alpha = 0.0f;
            obj2.alpha = 0.0f;
            obj3.alpha = 0.0f;
            obj4.alpha = 0.0f;
            obj5.alpha = 0.0f;
            obj6.alpha = 1.0f;
        }

    }



}
