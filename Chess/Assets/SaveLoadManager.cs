using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public class SaveLoadManager
{
    static string json;
    static string playerDataPath = Application.dataPath + "/Data/PlayerData.json";
    static data data = new data();

    static void GetData()
    {
        data.playerDifficulty = MainStatic.Main.player.difficulty.skill;
        data.playerIsWhite = MainStatic.Main.player.isWhite;
    }
    static void SetData()
    {
        MainStatic.Main.player.difficulty.skill = data.playerDifficulty;
        MainStatic.Main.player.isWhite = data.playerIsWhite;
    }

    public static bool Load()
    {
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
        GetData();
        if (!File.Exists(playerDataPath))
        {
            FileInfo fi = new FileInfo(playerDataPath);
            fi.Create();
        }
        byte[] bytes = Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
        string hex = BitConverter.ToString(bytes);
        File.WriteAllText(playerDataPath, hex.Replace("-",""));
        return true;
    }
}
[System.Serializable]
public class data
{
    public bool playerIsWhite;
    public int playerDifficulty;
}
