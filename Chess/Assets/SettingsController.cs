// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

    Toggle toggle;
    Dropdown dropDown;
    Button imageColor;
    Button imageColor1;
    Image imageDifficulty;

    public Sprite d1;
    public Sprite d2;
    public Sprite d3;
    public Sprite d4;
    SpriteRenderer tempSprite;
    bool isChange = false;

	void Start () {
        Debug.Log("LOL");
        toggle = GameObject.Find("Toggle").GetComponent<Toggle>();
        dropDown = GameObject.Find("Dropdown").GetComponent<Dropdown>();
        imageColor = GameObject.Find("Color").GetComponent<Button>();
        imageColor1 = GameObject.Find("Color1").GetComponent<Button>();
        imageDifficulty = GameObject.Find("Difficulty").GetComponent<Image>();

        toggle.onValueChanged.AddListener(delegate {
            Toggle_Changed(toggle);
        });

        dropDown.onValueChanged.AddListener(delegate { DropdownOnValueChange(dropDown); });
        LoadFunction();
    }

    void LoadFunction()
    {
        toggle.isOn = MainStatic.Main.player.isWhite;
        dropDown.value = MainStatic.Main.player.difficulty.skill - 1;
    }


    public void Toggle_Changed(bool newValue)
    {
        if(toggle.isOn)
        {
            MainStatic.Main.player.isWhite = true;
            showButton(imageColor, false);
            showButton(imageColor1, true);
        }
        else
        {
            MainStatic.Main.player.isWhite = false;
            showButton(imageColor, true);
            showButton(imageColor1, false);
        }
        DataManager.Save();
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



    public void DropdownOnValueChange(Dropdown target)
    {
        switch(target.value)
        {
            case 0:
                MainStatic.Main.player.difficulty.skill = 1;
                imageDifficulty.sprite = d1;
                break;
            case 1:
                MainStatic.Main.player.difficulty.skill = 2;
                imageDifficulty.sprite = d2;
                break;
            case 2:
                MainStatic.Main.player.difficulty.skill = 3;
                imageDifficulty.sprite = d3;
                break;
            case 3:
                MainStatic.Main.player.difficulty.skill = 4;
                imageDifficulty.sprite = d4;
                
                break;
        }
        DataManager.Save();
    }

    public void SetStandartSettings()
    {
        dropDown.value = 0;
        toggle.isOn = true;
        DataManager.Save();
    }
}
