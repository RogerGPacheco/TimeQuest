using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class HangmanController : MonoBehaviour
{

    public GameObject wordContainer;
    [SerializeField] GameObject keyboardContainer;
    [SerializeField] GameObject letterContainer;
    [SerializeField] GameObject letterButton;
    [SerializeField] TextAsset possibleWord;
    [SerializeField] GameObject[] hangmanStage;
    public TMPro.TextMeshPro textMeshPro;

    private string word;
    private int incorrectGuess, correctGuess;
   

    // Start is called before the first frame update
    void Start()
    {
        InitialiseButtons();
        initialiseGame(); 
    }

    private void InitialiseButtons()
    {
        for (int i = 65; i <= 90; i++)
        {
            CreateButton(i);
        }
    }

    private void initialiseGame() 
    {
        //reset data to original state
        incorrectGuess = 0;
        correctGuess = 0;
        

        foreach(Button child in keyboardContainer.GetComponentsInChildren<Button>())
        {
            child.interactable = true;
            
        }
        


        foreach (GameObject stage in hangmanStage)
        {
            stage.SetActive(false);
            
        }

        //generate new word

        word = generateWord().ToUpper();
        foreach(char letter in word)
        {
            var tempo = Instantiate(letterContainer, wordContainer.transform);
        }

    }

    private void CreateButton(int i)
    {
        GameObject temp = Instantiate(letterButton, keyboardContainer.transform);
        temp.GetComponentInChildren<TextMeshProUGUI>().text = ((char)i).ToString();
        temp.GetComponent<Button>().onClick.AddListener(delegate { checkLetter(((char)i).ToString()); } );
    }

    private string generateWord()
    {
        string[] wordList = possibleWord.text.Split("\n");
        string line = wordList[Random.Range(0, wordList.Length - 1)];
        return line.Substring(0, line.Length - 1);
    }

    private void checkLetter(string inputLetter)
    {
        bool letterInWord = false;
        for (int i = 0; i < word.Length; i++)
        {
            if (inputLetter == word[i].ToString())
            {
                letterInWord = true;
                correctGuess++;
                wordContainer.GetComponentsInChildren<TextMeshProUGUI>()[i].text = inputLetter;
            }
        }
        if (letterInWord == false) 
        {
            incorrectGuess++;
            hangmanStage[incorrectGuess - 1].SetActive(true);
        }
        CheckOutcome();
    }
    

    public void CheckOutcome()
    {
        if(correctGuess == word.Length) //win
        {
            for (int i = 0; i < word.Length; i++)
            {
                wordContainer.GetComponentsInChildren<TextMeshProUGUI>()[i].color = Color.green;
            }
            Invoke(nameof(initialiseGame), 3.0f);
        }

        if(incorrectGuess == hangmanStage.Length) //lose
        {
            for (int i = 0; i < word.Length; i++)
            {
                Debug.Log($"Letra exibida: {word[i]}");
                wordContainer.GetComponentsInChildren<TextMeshProUGUI>()[i].color = Color.red;
                wordContainer.GetComponentsInChildren<TextMeshProUGUI>()[i].text = word[i].ToString();
            }
            Invoke(nameof(initialiseGame), 3.0f);
        }
    }
}
