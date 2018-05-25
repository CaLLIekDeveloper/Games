// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MainStatic;
using MyGame;
public class ScriptBoard {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public ScriptBoard()
    {
    }


    public void ShowFigures(Chess chess)
    {
        int nr = 0;
        for (int y = 0; y < 8; y++)
            for (int x = 0; x < 8; x++)
            {
                MarkSquare(x, y, false);
                string figure = chess.GetFigureAt(x, y).ToString();
                if (figure == ".") continue;
                PlaceFigure("box" + nr, figure, x, y);
                nr++;
            }
        for (; nr < 32; nr++)
            PlaceFigure("box" + nr, "q", 9, 9);

    }
    /// <summary>
    /// Устанавливает фигуру 
    /// </summary>
    /// <param name="box"></param>
    /// <param name="figure"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    void PlaceFigure(string box, string figure, int x, int y)
    {
        GameObject goBox = GameObject.Find(box);
        GameObject goFigure = GameObject.Find(figure);
        GameObject goSquare = GameObject.Find("" + y + x);

        var spriteFigure = goFigure.GetComponent<SpriteRenderer>();
        var spriteBox = goBox.GetComponent<SpriteRenderer>();
        spriteBox.sprite = spriteFigure.sprite;

        goBox.transform.position = goSquare.transform.position;
    }
    /// <summary>
    /// Метод который помечает все фигуры которыми можно пойти
    /// </summary>
    public void MarkValidFigures(Chess chess)
    {
        for (int y = 0; y < 8; y++)
            for (int x = 0; x < 8; x++)
                MarkSquare(x, y, false);
        foreach (string moves in chess.GetAllMoves())
        {
            int x, y;
            GetCoord(moves.Substring(1, 2), out x, out y);
            MarkSquare(x, y, true);
        }
    }

    public void DefaultMark()
    {
        for (int y = 0; y < 8; y++)
            for (int x = 0; x < 8; x++)
                MarkSquare(x, y, false);
    }
    /// <summary>
    /// Метод который помечает все клетки на которые можно пойти
    /// </summary>
    public void MarkValidMoves(Chess chess,String figure,String from)
    {
        for (int y = 0; y < 8; y++)
            for (int x = 0; x < 8; x++)
                MarkSquare(x, y, false);

        foreach (string moves in chess.GetAllMoves())
        {
            if (moves[0]==figure[0] && moves[1]==from[0] && moves[2]==from[1])
                {
                int x, y;
                GetCoord(moves.Substring(3, 2), out x, out y);
                MarkSquare(x, y, true);
            }
        }
    }

    public void GetCoord(string e2, out int x, out int y)
    {
        x = 9;
        y = 9;
        if (e2.Length == 2 &&
        e2[0] >= 'a' && e2[0] <= 'h' &&
        e2[1] >= '1' && e2[1] <= '8')
        {
            x = e2[0] - 'a';
            y = e2[1] - '1';
        }
    }
    /// <summary>
    /// Метод который меняет спрайт клетки к которой обращается
    /// </summary>
    /// <param name="x">Координаты от 0 до 7(a-h на шахматной доске)</param>
    /// <param name="y">Координаты от 0 до 7(1-8 на шахматной доске)</param>
    /// <param name="isMarked"></param>
    void MarkSquare(int x, int y, bool isMarked)
    {
        GameObject goSquare = GameObject.Find("" + y + x);
        GameObject goCell;
        string color = (x + y) % 2 == 0 ? "Black" : "White";
        if (isMarked)
        {
            goCell = GameObject.Find(color + "SquareMarked");
        }
        else
            goCell = GameObject.Find(color + "Square");

        var spriteSquare = goSquare.GetComponent<SpriteRenderer>();
        var spriteCell = goCell.GetComponent<SpriteRenderer>();
        spriteSquare.sprite = spriteCell.sprite;
    }
}
