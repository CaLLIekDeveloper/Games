package com.example.yoga.Classes;

import android.content.SharedPreferences;


//Глобальный класс для получения данных из разных частей программы
public class Globals {
    //переменная для настроек приложения
    public static SharedPreferences sPref;
    public static final String SAVED_TIME = "Time";
    public static final String SAVED_LANGUAGE = "Language";

    public  static int TimeOfGame;
    public  static int Language;

    static public DataBaseHelper sqlHelper;
}
