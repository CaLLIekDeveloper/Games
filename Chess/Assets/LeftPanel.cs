﻿// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

public class LeftPanel : MonoBehaviour {

    private Text text;
	void Start () {
        
        text = GameObject.Find("Hello").GetComponent<Text>();
        text.text = "Привіт, "+MainStatic.Main.player.login+".";
	}
}
