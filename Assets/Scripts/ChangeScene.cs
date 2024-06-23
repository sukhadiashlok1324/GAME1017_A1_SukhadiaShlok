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
    public string SceneName1;

    public void ChangeScene1()
    {
        SceneManager.LoadScene(SceneName);
    }
    
    public void ChangeScene2()
    {
        SceneManager.LoadScene(SceneName1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public GameObject panel;  
    public void TogglePanel()
    {
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);

            if (isActive)
            {
                Time.timeScale = 1f; // Resume time when the panel is hidden
            }
            else
            {
                Time.timeScale = 0f; // Pause time when the panel is shown
            }
        }
    }
}
