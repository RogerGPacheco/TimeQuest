using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string sceneName;
    public TMP_Text textMeshPro;

    private void Start()
    {
        //textMeshPro.text = PlayerPrefs.GetString("name");
    }
    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
        PlayerPrefs.SetInt("Vitorias", 0);
    }
    public void logOff()
    {
        PlayerPrefs.SetString("name", null);
        SceneManager.LoadScene("LoginScene");

    }
}