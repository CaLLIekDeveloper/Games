// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

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
