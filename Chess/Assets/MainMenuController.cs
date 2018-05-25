// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using MyGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
    private static Button bContinue;

    public static bool IsContinue = false;
    public static Chess shess;
    void Start()
    {
        bContinue = GameObject.Find("bContinue").GetComponent<Button>();
        Show();
        
    }

    static public void Show()
    {
        if (PlayerPrefs.GetInt("isSave") == 1)
        {
            showButton(bContinue, true);
        }
        else
            showButton(bContinue, false);
    }

    static void showButton(Button buttonToShow, bool show)
    {
        Image bImage = buttonToShow.GetComponent<Image>();
        Text bText = buttonToShow.GetComponentInChildren<Text>();

        if (bImage != null)
        {
            bImage.enabled = show;
        }

        if (bText != null)
        {
            bText.enabled = show;
        }
    }

    
    public void _Continue()
    {
        IsContinue = true;
        MySceneManager.SetGameScene();
    }
}
