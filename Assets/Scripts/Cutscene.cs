using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public string sceneName;
    FadeInOut fade;

    private void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(LoadLevelAfterDelay(2));
        }
    }
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        fade.FadeIn();
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
