using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{

    public TMP_InputField txtLogin;
    // Start is called before the first frame update
    void Start()
    {
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("name")))
            SceneManager.LoadScene("TitleScene");
    }

    public void Login()
    {
        PlayerPrefs.SetString("name", txtLogin.text);
        SceneManager.LoadScene("TitleScene");
    }
}