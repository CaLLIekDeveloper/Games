using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainStatic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MySceneManager : MonoBehaviour {

    static MySceneManager Instance;
    private static Button bR;
    void Start () {
		if(Instance != null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        bR = GameObject.Find("bRestart").GetComponent<Button>();
    }
    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        Main.stockFish.stockFish.Close();
    }

    void OnEnable()
    {
    }
    void OnDisable()
    {
    }
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 2)
        {

        }
    }


    // Update is called once per frame
    void Update () {
		
	}

    public static void SetGameScene()
    {
        SceneManager.LoadScene("Game_Scene");
    }
    public static void SetMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public static void SetSettingsScene()
    {
        SceneManager.LoadScene("SettingsScene");
    }
    public static void SetLoseScene()
    {
        SceneManager.LoadScene("LoseScene");
    }
    public static void SetWinScene()
    {
        SceneManager.LoadScene("WinScene");
    }
    public static void SetPatScene()
    {
        //Application.LoadLevel("WinScene");
    }
    public static void SetMainScene()
    {
        SceneManager.LoadScene("Login_Scene");
    }
}
