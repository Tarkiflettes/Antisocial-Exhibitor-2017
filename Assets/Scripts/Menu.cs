using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public Button PlayButton;
    public Button QuitButton;

    // Use this for initialization
    void Start()
    {
        PlayButton.onClick.AddListener(() => Play());
        QuitButton.onClick.AddListener(() => Quit());
    }

    private void Play()
    {
        Application.LoadLevel("TenteScene");
    }

    private void Quit()
    {
        Application.Quit();
    }
}
