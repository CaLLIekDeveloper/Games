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

    public Text WrongAccount;

    void Start () {

        MainStatic.Main.player = new Player();
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

        Account.Save();

        Account.Load();


        loginField.onValueChanged.AddListener(delegate { ValueChangeLogin(); });
        passwordField.onValueChanged.AddListener(delegate { ValueChangePassword(); });
        WrongAccount.enabled = false;
        WrongLogin.enabled = false;
        WrongPassword.enabled = false;
    }
    public void ValueChangePassword()
    {
        WrongAccount.enabled = false;
        WrongPassword.enabled = false;
    }
    public void ValueChangeLogin()
    {
        WrongAccount.enabled = false;
        WrongLogin.enabled = false;
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

    public void _GetPlayer()
    {
        MainStatic.Main.player.isGuest = false;
        if (IsNoNull())
        {
            if(HaveAccount())MySceneManager.SetMainMenuScene();
        }
    }

    public void _GetGuest()
    {
        MainStatic.Main.player.login = "Гість";
        MainStatic.Main.player.password = "1";
        MainStatic.Main.player.isGuest = true;
        MySceneManager.SetMainMenuScene();
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

    private void _SaveSetings()
    {
        ///todo
    }
    private void _AddUser()
    {
        ///todo
    }

    private bool IsNoNull()
    {
        if(loginField.text.Length>0&& passwordField.text.Length>0)
        {
            return true;
        }else
        if(loginField.text.Length==0)
        {
            WrongLogin.enabled = true;
        }
        if(passwordField.text.Length==0)
        {
            WrongPassword.enabled = true;
        }
        return false;
    }

    private bool HaveAccount()
    {
        if (Account.HaveAccount(loginField.text, passwordField.text))
        {
            MainStatic.Main.player.login = loginField.text;
            MainStatic.Main.player.password = passwordField.text;
            
            return true;
        }
        WrongAccount.enabled = true;
        return false;
    }

}

