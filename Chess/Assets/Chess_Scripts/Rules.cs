using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using MainStatic;
using MyGame;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//todo Добавить проверку на шах и на мат.+-
//Добавить проверки на возможность рокировки и на взятие на проходе ++
//Выбор: Игра против компьютера или против человека ++
//Добавить сцену входа в приложение(как онлайн так и офлайн режимы или как гость) +-
//Добавить сцену главного меню Новая игра() -> Настройки игры   Продолжить игр; +-
//Добавить сохранение результатов ваши предыдущие игры придумать систему рейтинга сцену статистики игр -- 
//UPD 06.06.2018
//Add user greeting
//Доделать меню настройек (sound on or off, select resolution)
//Добавить в генерацию ФЕН информацию о рокировке и о взятии на проходе ++
//Добавить в настройки выбор игры по времени
//Добавить название полей в шахматное поле ++
//

public class Rules : MonoBehaviour
{
    AI ai = new AI();
    public static AudioClip soundStep;
    public static AudioSource audio;

    static InputField log;


    private bool IsWhitePlayerTemp;

    private void Init()
    {
        Main.dragAndDrop = new DragAndDrop();
        Main.chess = new Chess();
        Main.scriptBoard = new ScriptBoard();
        Main.CountSteps = 0;
        Main.previousMove = null;
        Castling.Default();
        Main.chess.FindAllMoves();
        Main.scriptBoard.ShowFigures(Main.chess);
        log.text = "";
        IsWhitePlayerTemp = Main.player.isWhite;
    }

    private void Awake()
    {
        log = GameObject.Find("log").GetComponent<InputField>();
        Main.stockFish = new StockFish();
    }

    public void _ContinueGame(string fen)
    {
        Main.chess = new Chess(fen);
        Main.chess.FindAllMoves();
        Main.scriptBoard.ShowFigures(Main.chess);
        IsWhitePlayerTemp = bool.Parse(PlayerPrefs.GetString("PlayerIsWhite"));


        Debug.Log("FEN: " + fen);
        Debug.Log("IsWhitePlayerTemp: " + IsWhitePlayerTemp);
        Debug.Log("Main.chess.isWhiteStep() : " + Main.chess.isWhiteStep());
    }

    void Start()
    {
        
        Init();
        Debug.Log("Start()IsWhitePlayerTemp: " + IsWhitePlayerTemp);
        if (MainMenuController.IsContinue)
        {
            _ContinueGame(PlayerPrefs.GetString("SaveGame"));
            MainMenuController.IsContinue = false;
        }
        else
            FirstStemComputer();
        audio = GetComponent<AudioSource>();
        
    }

    void FirstStemComputer()
    {
        if (Main.player.typeGame == 1)
        {
            if (IsWhitePlayerTemp != Main.chess.isWhiteStep())
            {
                string stockFishMove = Main.stockFish.GetBestMove();
                Main.chess = Main.chess.Move("" + (Char)Main.chess.GetFigureAt(stockFishMove[0].ToString() + stockFishMove[1].ToString()) + stockFishMove);
                Main.scriptBoard.ShowFigures(Main.chess);
                Main.chess.FindAllMoves();
                log.text = log.text + "Хід суперника: " + stockFishMove + "\r\n";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Main.dragAndDrop.Action())
        {
            audio.Play();
            string from = GetSquare(Main.dragAndDrop.pickPosition);
            string to = GetSquare(Main.dragAndDrop.dropPosition);
            string figure = Main.chess.GetFigureAt(from).ToString();
            string move = figure + from + to;

            if (Main.previousMove == null) Main.previousMove = move;
            Main.chess = Main.chess.Move(move);


            AddMoveInLog(from, to);
            if (from != to && Main.previousMove != move)
            {
                Main.previousMove = move;
            }

            Main.scriptBoard.ShowFigures(Main.chess);
            ComputerMove(from,to);
            SheckEndGame();

        }
    }

    private void AddMoveInLog(string from, string to)
    {
        if (from != to)
        {
            if (Main.player.typeGame == 1)
                log.text = log.text + "Ваш хід:            " + from + to + "\r\n";
            else
            {
                string temp = "";
                if (!Main.chess.isWhiteStep()) temp += "Хід білих:    ";
                else
                    temp += "Хід чорних: ";
                log.text = log.text + temp + from + to + "\r\n";
            }
        }

    }

    private void ComputerMove(string from, string to)
    {
        if (Main.player.typeGame == 1 && (IsWhitePlayerTemp == !Main.chess.isWhiteStep()))// blackIsAI && !Main.chess.isWhiteStep())
        {
            Main.chess.FindAllMoves();
            if (SheckEndGame()) return;
            Debug.Log(Main.chess.fen);
            Main.stockFish.sendPlayerMove(Main.chess.fen, from + to);
            string stockFishMove = Main.stockFish.GetBestMove();
            if (stockFishMove != null)
            {
                log.text = log.text + "Хід суперника: " + stockFishMove + "\r\n";
                //Main.chess.FindAllMoves();
                Main.stockFish.sendMessage("setoption name Skill Level value 0");
                //Main.stockFish.sendPlayerMove(stockFishMove);
                Main.chess = Main.chess.Move("" + (Char)Main.chess.GetFigureAt(stockFishMove[0].ToString() + stockFishMove[1].ToString()) + stockFishMove);
                Main.scriptBoard.ShowFigures(Main.chess);
            }
            else
            {
                Debug.Log("Ошибка StockFish: ");
            }
        }
        Main.chess.FindAllMoves();
        if (Main.chess.IsCheck() && Main.chess.GetAllMoves().Capacity > 0)
        {
            Main.scriptBoard.MarkValidFigures(Main.chess);
        }
    }

    bool SheckEndGame()
    {
        if (Main.chess.IsCheck() && Main.chess.GetAllMoves().Capacity == 0)
        {
            Debug.Log("isWhite: "+ IsWhitePlayerTemp);
            Debug.Log("Main.chess.isWhiteStep(): " + Main.chess.isWhiteStep());

            if (IsWhitePlayerTemp)
            {
                if (Main.chess.isWhiteStep())
                {
                    Invoke("LoseWhite", 2);
                }
                else
                {
                    Invoke("WinWhite", 2);
                }
            }
            else
            //if (!Main.player.isWhite)
            {
                if (Main.chess.isWhiteStep())
                {
                    Invoke("WinBlack", 2);
                }
                else
                {
                    Invoke("LoseWhite", 2);
                }
            }
            return true;
        }
        
        if (Main.chess.GetAllMoves().Capacity == 0 || Main.CountSteps>100)
        {
            Invoke("Pat", 2);
            return true;
        }
        return false;
        
    }

    string GetSquare(Vector2 position)
    {
        int x = Convert.ToInt32(position.x / 2.0);
        int y = Convert.ToInt32(position.y / 2.0);
        return ((char)('a' + x)).ToString() + (y + 1).ToString();
    }

    public void RestartGame()
    {
        Init();
    }



    private void LoseWhite()
    {
        MySceneManager.SetLoseScene();
    }
    private void LoseBlack()
    {
        MySceneManager.SetLoseScene();
    }


    private void WinWhite()
    {
        MySceneManager.SetWinScene();
    }
    private void WinBlack()
    {
        MySceneManager.SetLoseScene();
    }


    private void Pat()
    {
        MySceneManager.SetLoseScene();
    }
}