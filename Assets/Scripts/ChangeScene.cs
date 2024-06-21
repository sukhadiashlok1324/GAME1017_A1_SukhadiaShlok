using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;


public class ChangeScene : MonoBehaviour
{

    void Start()
    {
        
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    public string SceneName;

    public void ChangeScene1()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public GameObject panel;  // Reference to the Panel GameObject

    // Method to toggle the panel's visibility
    public void TogglePanel()
    {
        Time.timeScale = 0f;
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
}
