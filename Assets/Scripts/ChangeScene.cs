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
