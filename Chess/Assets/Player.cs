using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    public string login;
    public string password;
    public bool isGuest;
    public bool isWhite;
    public Difficulty difficulty;
    public int typeGame;
    public Player()
    {
        typeGame = 0;
        login = "temp";
        password = "temp";
        isGuest = false;
        isWhite = true;
        difficulty = new Difficulty();
    }
}