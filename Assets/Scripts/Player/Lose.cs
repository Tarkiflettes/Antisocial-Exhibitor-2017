using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{

    public Button RestartButton;
    public Button QuitButton;
    
    void Start()
    {
        RestartButton.onClick.AddListener(() => Restart());
        QuitButton.onClick.AddListener(() => Quit());
    }

    private void Restart()
    {
        Application.LoadLevel("TenteScene");
    }

    private void Quit()
    {
        Application.LoadLevel("Menu");
    }

}
