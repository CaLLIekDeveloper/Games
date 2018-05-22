using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame;
public class MoveScore {
    public string move;
    public int score = -100000000;
    public Figure figure = Figure.none;
    public MoveScore(string move)
    {
        this.move = move;
    }
}
