using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    DialogueSystem dialogueSystem;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {

            //dialogueSystem.Next();
        }
    }

    private void Awake()
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();  
    }
}


