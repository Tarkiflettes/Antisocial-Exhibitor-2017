using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    public Button PauseButton;
    public Button ResumeButton;
    public Button RestartButton;
    public Button QuitButton;
    public Transform PausePanel;

    // Use this for initialization
    void Start()
    {
        PauseButton.onClick.AddListener(() => SetPause(true));
        ResumeButton.onClick.AddListener(() => Resume());
        RestartButton.onClick.AddListener(() => Restart());
        QuitButton.onClick.AddListener(() => Quit());
        PausePanel.gameObject.SetActive(false);
    }

    private void SetPause(bool state)
    {
        SetRealPause(state == false ? 1 : 0);
        PausePanel.gameObject.SetActive(state);
    }

    private void SetRealPause(int i)
    {
        Time.timeScale = i;
    }

    private void Resume()
    {
        Debug.Log(Time.timeScale);
        SetPause(false);
    }

    private void Restart()
    {
        SetRealPause(1);
        Application.LoadLevel("TenteScene");
    }

    private void Quit()
    {
        SetRealPause(1);
        Application.LoadLevel("Menu");
    }
}
