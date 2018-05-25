using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinSceneController : MonoBehaviour {

    public Text text;
	// Use this for initialization
	void Start () {
        text.text = "Вітаю, "+MainStatic.Main.player.login+" ви перемогли у цій партії за "+MainStatic.Main.CountSteps+" ходів.";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
