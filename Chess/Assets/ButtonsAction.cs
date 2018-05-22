using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsAction : MonoBehaviour
{
    public void _Restart()
    {
        MySceneManager.SetGameScene();
    }
    public void _NewGame()
    {
        SavePrefs(false);
        MainStatic.Main.player.typeGame = 2;
        MySceneManager.SetGameScene();
    }
    public void _NewGameAi()
    {
        SavePrefs(false);
        MainStatic.Main.player.typeGame = 1;
        MySceneManager.SetGameScene();
    }
    public void _Exit()
    {
        Application.Quit();
    }
    public void _Settings()
    {
        MySceneManager.SetSettingsScene();
    }
    public void _GoToMainMenu()
    {
        MySceneManager.SetMainMenuScene();
    }
    public void _GoToLoseScene()
    {
        MySceneManager.SetLoseScene();
        SavePrefs(false);
    }
    public void _GoToWinScene()
    {
        MySceneManager.SetWinScene();
        SavePrefs(false);
    }
    public void _SaveGame()
    {
        SavePrefs(true);
        MySceneManager.SetMainMenuScene();
    }

    private void SavePrefs(bool flag)
    {
        if (flag)
        {
            PlayerPrefs.SetInt("isSave", 1);
            PlayerPrefs.SetString("SaveGame", MainStatic.Main.chess.fen);
            PlayerPrefs.SetInt("TypeGame", MainStatic.Main.player.typeGame);
            PlayerPrefs.Save();
        }else
        {
            PlayerPrefs.SetInt("isSave", 0);
            PlayerPrefs.SetString("SaveGame", "");
            PlayerPrefs.SetInt("TypeGame", 0);
            PlayerPrefs.Save();
        }
    }

    public void _Continue()
    {
        MainMenuController._Continue();
    }
}
