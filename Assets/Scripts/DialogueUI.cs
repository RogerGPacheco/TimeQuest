using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{

    TextMeshProUGUI nameText;
    TextMeshProUGUI talktext;

    public float speed = 10f;

    private void Awake()
    {
        nameText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        talktext = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {

    }

    public void Setname(string name)
    {
        nameText.text = name;
    }


}
