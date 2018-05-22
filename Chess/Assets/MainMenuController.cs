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
        SaveLoadManager.Load();
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

    /*
    static public void _Continue()
    {
        IsContinue = true;
        shess = new MyGame.Chess(PlayerPrefs.GetString("SaveGame"));
        MySceneManager.SetGameScene();
        Debug.Log("PlayerPrefs.GetString: " + PlayerPrefs.GetString("TypeGame"));
        Debug.Log("PlayerPrefs.GetString(\"SaveGame\") : " + PlayerPrefs.GetString("SaveGame"));
        MainStatic.Main.player.typeGame = PlayerPrefs.GetInt("TypeGame");
        //MainStatic.Main.scriptBoard.ShowFigures(MainStatic.Main.chess);
    }
    */
}
