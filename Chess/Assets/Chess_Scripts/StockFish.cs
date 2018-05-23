using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using MainStatic;
using System.Reflection;
using UnityEngine;

public class StockFish {


    public Process stockFish;
    public StockFish()
    {
        //UnityEngine.Debug.Log("StartStockFish(): ");
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "stockfish_9_x64.exe");
        //UnityEngine.Debug.Log("StartStockFish(): "+Environment.CurrentDirectory);
#if UNITY_EDITOR
        filePath = Environment.CurrentDirectory+@"\Assets\StreamingAssets\stockfish_9_x64.exe";
#endif
        stockFish = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = filePath,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            }
        };
        stockFish.StartInfo.CreateNoWindow = true;
        stockFish.Start();
        stockFish.StandardInput.WriteLine("null");
        StartNewGame();
    }
    public void StartNewGame()
    {
        sendMessage("ucinewgame");
        sendMessage("setoption name Skill Level value 0");
    }

    public void sendMessage(String msg)
    {
        stockFish.StandardInput.WriteLine(msg);
    }
    public void sendPlayerMove(String fen, String move)
    {
        //UnityEngine.Debug.Log("Отправляю сообщение: " + move);
        string Message = "position fen "+fen+" moves " + move;
        sendMessage(Message);
        System.Threading.Thread.Sleep(150);
        
    }
    public string GetBestMove()
    {
        sendMessage(GetSkillLevel());
        while(true)
        {
            string temp = stockFish.StandardOutput.ReadLine();
            //UnityEngine.Debug.Log("stockFish.StandardOutput.ReadLine(): " + temp);
            string[] tempLine = temp.Split();
            if(tempLine[0]=="bestmove")
            {
                string needMove = tempLine[1];
                //UnityEngine.Debug.Log("needMove: " + needMove);
                return needMove;
            }
            if (temp == null) return null;
        }
    }

    string GetSkillLevel()
    {
        return "go depth "+Main.player.difficulty.CastSkill()+" nodes "+Main.player.difficulty.CastSkill() + " movetime "+Main.player.difficulty.CastSkill();
    }
}
