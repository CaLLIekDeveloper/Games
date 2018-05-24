using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

public class LeftPanel : MonoBehaviour {

    private Text text;
    private Button btnExit;
	void Start () {
        
        text = GameObject.Find("Hello").GetComponent<Text>();
        text.text = "Привіт, "+MainStatic.Main.player.login+".";

        btnExit = GameObject.Find("Button").GetComponent<Button>();
        btnExit.onClick.AddListener(delegate { _ExitFromAccount(); });
    }

    public void _ExitFromAccount()
    {
        MySceneManager.SetLoginScene();
    }
}
