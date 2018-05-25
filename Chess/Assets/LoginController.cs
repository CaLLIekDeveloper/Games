// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{


    private Button bGuest;
    private Button bEnter;
    private Button bR;
    private Button bR2;

    public Button ButtonGoToLoginFromRegistation;

    private Text TextWrongLogin;
    private Text TextWrongPassword;

    public Text TextWrongAccount;
    public Text TextHaveLogin;
    public Text TextSecondWrongPassword;


    [SerializeField]
    private InputField InputSecondPassword;
    [SerializeField]
    private InputField InputLogin;
    [SerializeField]
    private InputField InputPassword;

    void Start()
    {
        MainStatic.Main.player = new Player();
        //Screen.SetResolution(876,532,false);

        bGuest = GameObject.Find("bGuest").GetComponent<Button>();
        bEnter = GameObject.Find("bEnter").GetComponent<Button>();
        bR = GameObject.Find("bR").GetComponent<Button>();
        bR2 = GameObject.Find("bR2").GetComponent<Button>();
        TextWrongLogin = GameObject.Find("WrongLogin").GetComponent<Text>();
        TextWrongPassword = GameObject.Find("WrongPassword").GetComponent<Text>();

        Hide();

        InputLogin.onValueChanged.AddListener(delegate { ValueChangeLogin(); });
        InputPassword.onValueChanged.AddListener(delegate { ValueChangePassword(); });
        InputSecondPassword.onValueChanged.AddListener(delegate { ValueChangeSecondPassword(); });

        Account.Load();
    }

    private void Hide()
    {
        showButton(bR2, false);
        showButton(ButtonGoToLoginFromRegistation, false);

        TextWrongAccount.enabled = false;
        TextWrongLogin.enabled = false;
        TextWrongPassword.enabled = false;
        TextHaveLogin.enabled = false;
        TextSecondWrongPassword.enabled = false;

        showInput(InputSecondPassword, false);
    }



    public void ValueChangePassword()
    {
        TextWrongPassword.enabled = false;
        TextHaveLogin.enabled = false;
    }
    public void ValueChangeLogin()
    {
        TextWrongLogin.enabled = false;
        TextHaveLogin.enabled = false;
    }
    public void ValueChangeSecondPassword()
    {
        TextHaveLogin.enabled = false;
        if (InputPassword.text.Equals(InputSecondPassword.text))
            TextSecondWrongPassword.enabled = false;
    }

    void showButton(Button buttonToShow, bool show)
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

    void showInput(InputField inputToShow, bool show)
    {
        Image bImage = inputToShow.GetComponent<Image>();
        Text bText = inputToShow.GetComponentInChildren<Text>();

        if (bImage != null)
        {
            bImage.enabled = show;
        }

        if (bText != null)
        {
            bText.enabled = show;
        }

        inputToShow.enabled = show;
    }

    public void _GetPlayer()
    {
        MainStatic.Main.player.isGuest = false;
        if (IsNoNull())
        {
            if (HaveAccount())
            {
                SetPlayer();
                MySceneManager.SetMainMenuScene();
            }
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
        ShowHide(false);
        TextHaveLogin.enabled = false;
    }

    private void ShowHide(bool temp)
    {
        showButton(bGuest, temp);
        showButton(bEnter, temp);
        showButton(bR, temp);
        showButton(bR2, !temp);
        showInput(InputSecondPassword, !temp);
        showButton(ButtonGoToLoginFromRegistation, !temp);
    }

    public void _GetNewUser2()
    {
        MainStatic.Main.player.isGuest = false;
        IsNoNull();
        if (InputPassword.text.Length == 0)
        {
            TextSecondWrongPassword.enabled = true;
        }
        else
        {
            if (IsNoNull())
            {
                if (InputPassword.text.Equals(InputSecondPassword.text))
                {
                    if (AddAccount())
                    {
                        SetPlayer();
                        MySceneManager.SetMainMenuScene();
                    }
                    else
                    {
                        TextHaveLogin.enabled = true;
                    }
                }
                else
                {
                    TextSecondWrongPassword.enabled = true;
                }
            }
        }
    }

    public void _Back()
    {
        InputSecondPassword.text = "";
        showButton(ButtonGoToLoginFromRegistation, false);
        TextHaveLogin.enabled = false;
        ShowHide(true);
    }

    private bool IsNoNull()
    {
        if (InputLogin.text.Length > 0 && InputPassword.text.Length > 0)
        {
            return true;
        }

        if (InputLogin.text.Length == 0)
        {
            TextWrongLogin.enabled = true;
        }
        if (InputPassword.text.Length == 0)
        {
            TextWrongPassword.enabled = true;
        }
        return false;
    }


    private bool HaveAccount()
    {
        if (Account.HaveAccount(InputLogin.text, InputPassword.text))
        {
            SetPlayer();
            return true;
        }
        TextWrongAccount.enabled = true;
        return false;
    }

    private bool AddAccount()
    {
        if (Account.AddAccount(InputLogin.text, InputPassword.text)) return true;
        TextHaveLogin.enabled = true;
        return false;
    }

    private void SetPlayer()
    {
        MainStatic.Main.player.login = InputLogin.text;
        MainStatic.Main.player.password = InputPassword.text;
        DataManager.Load();
    }
}

