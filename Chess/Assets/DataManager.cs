// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public class DataManager
{
    static string json;
    static string playerDataPath;
    static data data = new data();

    public static void SetPlayerDataPath()
    {
        playerDataPath = Application.dataPath + "/Resources/" + MainStatic.Main.player.login + ".json";
    }

    static void GetData()
    {
        data.playerDifficulty = MainStatic.Main.player.difficulty.skill;
        data.playerIsWhite = MainStatic.Main.player.isWhite;
    }
    static void SetData()
    {
        Debug.Log("Какого хуя" + data.playerDifficulty);
        MainStatic.Main.player.difficulty.skill 
            = data.playerDifficulty;
        MainStatic.Main.player.isWhite = data.playerIsWhite;
    }

    public static bool Load()
    {
        if (playerDataPath == null) SetPlayerDataPath();
        if(!CreateFile(playerDataPath))
        {
            Save();
        }

        json = File.ReadAllText(playerDataPath);
        int charsCount = json.Length;
        byte[] bytes = new byte[charsCount / 2];
        for (int i = 0; i < charsCount; i += 2) bytes[i / 2] = Convert.ToByte(json.Substring(i, 2), 16);
        string loadedData = Encoding.UTF8.GetString(bytes,0,bytes.Length);

        data = JsonUtility.FromJson<data>(loadedData);
        SetData();
        return true;
    }

    public static bool Save()
    {
        if (playerDataPath == null) SetPlayerDataPath();
        GetData();
        CreateFile(playerDataPath);
        byte[] bytes = Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
        string hex = BitConverter.ToString(bytes);
        File.WriteAllText(playerDataPath, hex.Replace("-",""));
        return true;
    }

    public static bool CreateFile(string path)
    {
        if (File.Exists(path))
        {
            Debug.Log("Файл создан:  " + path);
            return true;
        }
        else
        {
            System.IO.FileStream oFileStream = null;
            oFileStream = new System.IO.FileStream(path, System.IO.FileMode.Create);
            oFileStream.Close();
            return false;
        }
    }
}


[System.Serializable]
public class data
{
    public bool playerIsWhite;
    public int playerDifficulty;
}


public class Account
{
    static string json;
    public static string playerDataPath = Application.dataPath + "/Resources/Players.json";
    static acc data = new acc();

    public static bool Load()
    {
        if(!DataManager.CreateFile(playerDataPath))
        {
            Save();
        }
        json = File.ReadAllText(playerDataPath);
        Debug.Log("JSON LOAD: " + JsonUtility.ToJson(data, true));

        int charsCount = json.Length;
        byte[] bytes = new byte[charsCount / 2];
        for (int i = 0; i < charsCount; i += 2) bytes[i / 2] = Convert.ToByte(json.Substring(i, 2), 16);
        string loadedData = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

        data = JsonUtility.FromJson<acc>(loadedData);
        return true;
    }

    public static bool Save()
    {
        if (data.login == null)
        {
            data.login = new List<string>();
            data.password = new List<string>();
            data.login.Add("admin");
            data.password.Add("admin");
        }
        DataManager.CreateFile(playerDataPath);
        Debug.Log("JSON SAVE: " + JsonUtility.ToJson(data, true));
        byte[] bytes = Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
        string hex = BitConverter.ToString(bytes);
        File.WriteAllText(playerDataPath, hex.Replace("-", ""));
        return true;
    }

    public static bool HaveAccount(string login, string password)
    {
        if (data.login.Contains(login))
        {
            if (data.password[data.login.IndexOf(login)].Equals(password))
                return true;
        }
        return false;
    }

    public static bool AddAccount(string login, string password)
    {
        if (!data.login.Contains(login))
        {
            data.login.Add(login);
            data.password.Add(password);
            Save();
            return true;
        }
        return false;
    }
}
[System.Serializable]
public class acc
{
    public List<string> login;
    public List<string> password;
}
