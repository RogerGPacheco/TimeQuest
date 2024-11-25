using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum STATE
{
    DISABLED,
    WAITING,
    TYPING
}

public class DialogueSystem : MonoBehaviour
{

    public string SceneName;

    public DialogueData dialogueData;

    int currentText = 0;
    bool finished = false;

    TypeTextAnimation typeText;
    DialogueUI dialogueUI;
 

    STATE state;

     void Awake()
    {
        typeText = FindObjectOfType<TypeTextAnimation>();
        dialogueUI = FindObjectOfType<DialogueUI>();


        typeText.TypeFinished = OnTypeFinishe;
    }

     void Start()
    {
        state = STATE.DISABLED;
        Next();
    }

     void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {

            state = STATE.WAITING;
        }

        if (state == STATE.DISABLED) return;

        switch (state)
        {
            case STATE.WAITING:
                Waiting();
                break;
            case STATE.TYPING:
                Typing();
                break;

        }

        if (finished) 
        {
            
            StartCoroutine(LoadLevelAfterDelay(5));
        }
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneName);
        Debug.Log("Carregando cena");
    }

    public void Next()
    {


        dialogueUI.Setname(dialogueData.talkScript[currentText].name);

        typeText.fullText = dialogueData.talkScript[currentText++].text;

        if(currentText == dialogueData.talkScript.Count) 
        { 
            finished = true; 
        }

        typeText.StartTyping();
        state = STATE.TYPING;
    }

    void OnTypeFinishe()
    {
        state = STATE.WAITING;
    }
    void Waiting()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!finished)
            {
                Next();
            }
            else
            {
                
                state = STATE.DISABLED;
                currentText = 0;
                finished = true;
            }

        }
    }


    void Typing()
    {
      
    }

}

