// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainStatic;
using System;
using MyGame;
public class AI {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    int maxDepth = 1;

    Stack<String> moveStack = new Stack<String>();
    List<FigureOnSquare> _tilesWithPieces = new List<FigureOnSquare>();
    List<FigureOnSquare> _blackMoving = new List<FigureOnSquare>();
    List<FigureOnSquare> _whiteMoving = new List<FigureOnSquare>();



    int _whiteScore = 0;
    int _blackScore = 0;
    String bestMove;
    Chess _localChess;

    MoveScore bestMov;

    public MoveScore GetComputerMove()
    {
        //_localChess = new Chess(Main.chess.fen);
        Debug.Log("Зашел в Ai");
        bestMov = new MoveScore("pe6e4");
        Debug.Log("Создал лучший ход: " + bestMov.move);
        MiniMax(1, -100000000, 1000000000, true);
        Debug.Log("Лучший ход после МинМакса: " + bestMov.move);
        return this.bestMov;
    }


    public int MiniMax(int depth, int alpha, int beta, bool isMaximisingPlayer)
    {
        _GetBoardState();
        //positionCount++;
        if (depth == 0)
        {
            return _Evaluate();
        }

        if (isMaximisingPlayer)
        {
            int score = -10000000;
            List<MoveScore> allMoves = _GetMoves(_localChess.isWhiteStep());
            Debug.Log("Количество ходов" + allMoves.Count);
            foreach (MoveScore move in allMoves)
            {
                Debug.Log("Ход: " + move.move);
                moveStack.Push(move.move);

                move.figure = (Figure)_localChess.GetFigureAt((move.move[3].ToString() + move.move[4].ToString()));
                _localChess = _localChess.Move(move.move);
                score = MiniMax(depth - 1, alpha, beta, false);
                Debug.Log("#####   SCORE: " + score);

                if (score > alpha)
                {
                    move.score = score;
                    if (move.score > bestMov.score && depth == maxDepth)
                    {
                        bestMov = move;
                    }
                    alpha = score;
                }
                if (score >= beta)
                {
                    break;
                }
            }
            return alpha;
        }
        else
        {
            int score = 10000000;
            List<MoveScore> allMoves = _GetMoves(_localChess.isWhiteStep());
            Debug.Log("Количество ходов" + allMoves.Count);
            foreach (MoveScore move in allMoves)
            {
                Debug.Log("Ход: " + move.move);
                moveStack.Push(move.move);
                move.figure = (Figure)_localChess.GetFigureAt((move.move[3].ToString() + move.move[4].ToString()));
                _localChess = _localChess.Move(move.move);
                score = MiniMax(depth - 1, alpha, beta, true);

                Debug.Log("#####   SCORE: " + score);

                if (score < beta)
                {
                    move.score = score;
                    beta = score;
                }
                if (score <= alpha)
                {
                    break;
                }
            }
            return beta;
        }
    }



    void _GetBoardState()
    {
        Debug.Log("_GetBoardState: ");
        _blackMoving.Clear();
        _whiteMoving.Clear();
        _blackScore = 0;
        _whiteScore = 0;
        _tilesWithPieces.Clear();

        _localChess = Main.chess;

        Square temp;
        FigureOnSquare tempF;
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                temp = new Square(x, y);
                tempF = new FigureOnSquare(_localChess.GetFigureAt(temp), temp);
                if (tempF.figure != Figure.none)
                {
                    _tilesWithPieces.Add(tempF);
                }
            }
        }

        Debug.Log("_tilesWithPieces.size: " + _tilesWithPieces.Count);

        foreach (FigureOnSquare tile in _tilesWithPieces)
        {
            if (tile.figure.GetColor()==MyGame.Color.black)
            {
                _blackScore += Weights.GetPieceWeight(tile.figure);
                _blackMoving.Add(tile);
            }
            else
            {
                _whiteScore += Weights.GetPieceWeight(tile.figure);
                _whiteMoving.Add(tile);
            }
        }

        Debug.Log("!!!!!!!!!!!!!!!!!!!_blackMoving.size: " + _blackMoving.Count);
        Debug.Log("!!!!!!!!!!!!!!!!!!!_whiteMoving.size: " + _whiteMoving.Count);
    }

    int _Evaluate()
    {
        Debug.Log("_Evaluate(): ");
        float pieceDifference = 0;
        float whiteWeight = 0;
        float blackWeight = 0;

        foreach (FigureOnSquare tile in _whiteMoving)
        {
            whiteWeight += Weights.GetBoardWeight(tile.figure, tile.square, !_localChess.isWhiteStep());
        }
        foreach (FigureOnSquare tile in _blackMoving)
        {
            blackWeight += Weights.GetBoardWeight(tile.figure, tile.square, !_localChess.isWhiteStep());
        }
        Debug.Log("whiteWeight: "+ whiteWeight);
        Debug.Log("blackWeight: " + blackWeight);
        pieceDifference = (_blackScore + (blackWeight / 100)) - (_whiteScore + (whiteWeight / 100));
        return Mathf.RoundToInt(pieceDifference * 100);
    }

    List<MoveScore> _GetMoves(bool isWhite)
    {
        Debug.Log("_GetMoves       isWhite: " + isWhite);
        List<MoveScore> turnMove = new List<MoveScore>();
        List<FigureOnSquare> pieces = new List<FigureOnSquare>();

        if (!isWhite)
            pieces = _blackMoving;
        else pieces = _whiteMoving;

        foreach (String tile in _localChess.GetAllMoves())
        {
            //Debug.Log("MOVE: "+tile);
            foreach (FigureOnSquare move in pieces)
            {
                if ((Figure)tile[0] == (Figure)move.figure
                    && tile[1].Equals((Char)(move.square.x + 'a'))
                    && tile[2].Equals(Char.Parse((move.square.y + 1).ToString())))
                {
                    //Debug.Log("LOL PU#DEC &&&&&&&&&&&&&");
                    turnMove.Add(new MoveScore(tile));
                }
            }
        }
        return turnMove;
    }
}
