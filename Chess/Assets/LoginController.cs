using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LoginController : MonoBehaviour {

    private InputField loginField;
    private InputField passwordField;
    private Button bGuest;
    private Button bEnter;
    private Button bR;
    private Button bR2;

    private Text WrongLogin;
    private Text WrongPassword;


    // Use this for initialization

    void Start () {
        //Screen.SetResolution(876,532,false);
        Debug.Log("Панелька количество дочерних элементов: " + transform.childCount);
        loginField = GameObject.Find("login").GetComponent<InputField>();
        passwordField = GameObject.Find("password").GetComponent<InputField>();
        bGuest = GameObject.Find("bGuest").GetComponent<Button>();
        bEnter = GameObject.Find("bEnter").GetComponent<Button>();
        bR = GameObject.Find("bR").GetComponent<Button>();
        bR2 = GameObject.Find("bR2").GetComponent<Button>();
        WrongLogin = GameObject.Find("WrongLogin").GetComponent<Text>();
        WrongPassword= GameObject.Find("WrongPassword").GetComponent<Text>();
        showButton(bR2, false);
        MainStatic.Main.player = new Player();
        Account.Save();

        Account.Load();
    }


    void showButton(Button buttonToShow, bool show)
    {
        Image bImage = buttonToShow.GetComponent<Image>();
        Text bText = buttonToShow.GetComponentInChildren<Text>(); //Text is a child of the Button

        if (bImage != null)
        {
            bImage.enabled = show;
        }

        if (bText != null)
        {
            bText.enabled = show;
        }
    }


    // Update is called once per frame
    void Update () {
		
	}
    private void Awake()
    {
        
    }


    public void _GetPlayer()
    {
        MainStatic.Main.player.isGuest = false;
        if (IsNoNull()) MySceneManager.SetMainMenuScene();
    }

    public void _GetGuest()
    {
        MainStatic.Main.player.login = "Гість";
        MainStatic.Main.player.password = "1";
        MainStatic.Main.player.isGuest = true;
        MySceneManager.SetMainMenuScene();
        // Application.LoadLevel("temp.scene");
    }

    public void _GetNewUser()
    {
        showButton(bGuest, false);
        showButton(bEnter, false);
        showButton(bR, false);
        showButton(bR2, true);
    }

    public void _GetNewUser2()
    {
        MainStatic.Main.player.isGuest = false;
        if(IsNoNull())MySceneManager.SetMainMenuScene();
    }

    public void _SaveSetings()
    {
        ///todo
    }
    public void _AddUser()
    {
        ///todo
    }

    public bool IsNoNull()
    {
        Debug.Log(loginField.text);
        Debug.Log(passwordField.text);
        string temp = loginField.text;
        string temp1 = passwordField.text;
        if(temp.Length>0&&temp1.Length>0)
        {

            MainStatic.Main.player.login = temp;
            MainStatic.Main.player.password = temp1;
            return true;
        }else
        if(temp.Length==0)
        {
            WrongLogin.text = "Введіть логін";
        }
        if(temp1.Length==0)
        {
            WrongPassword.text = "Введіть пароль";
        }
        return false;
    }

}
public class Account
{
    static string json;
    static string playerDataPath = Application.dataPath + "/Data/Players.json";
    static acc data = new acc();

    public static bool Load()
    {
        Debug.Log("JSON LOAD: " + JsonUtility.ToJson(data,true));
        json = File.ReadAllText(playerDataPath);
        int charsCount = json.Length;
        byte[] bytes = new byte[charsCount / 2];
        for (int i = 0; i < charsCount; i += 2) bytes[i / 2] = Convert.ToByte(json.Substring(i, 2), 16);
        string loadedData = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

        data = JsonUtility.FromJson<acc>(loadedData);
        return true;
    }

    public static bool Save()
    {
        if (data.login == null)
        {
            data.login = new List<string>();
            data.password = new List<string>();
            data.login.Add("CaLLIek");
            data.password.Add("9530");
        }

        Debug.Log("JSON SAVE: " + JsonUtility.ToJson(data,true));
        if (!File.Exists(playerDataPath))
        {
            FileInfo fi = new FileInfo(playerDataPath);
            fi.Create();
        }
        byte[] bytes = Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
        string hex = BitConverter.ToString(bytes);
        File.WriteAllText(playerDataPath, hex.Replace("-", ""));
        return true;
    }
}
[System.Serializable]
public class acc
{
    public List<string> login;
    public List<string> password;
}
