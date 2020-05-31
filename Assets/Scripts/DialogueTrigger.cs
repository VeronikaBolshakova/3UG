using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject player;

    void Update()
    {
        player = GameObject.Find("Player");
        if (this.transform.position.x - player.transform.position.x <= 4)
        {
            TriggerDialogue();
        }


    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue);
    }
}
