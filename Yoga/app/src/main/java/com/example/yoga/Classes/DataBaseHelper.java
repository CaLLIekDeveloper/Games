package com.example.yoga.Classes;

import android.content.Context;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;

//Клас для работы с Базой данных SqLite
public class DataBaseHelper extends SQLiteOpenHelper {

    public static String DB_NAME = "HighscoreDB.db";
    private static final int SCHEMA = 1;
    private static String DB_PATH;
    public SQLiteDatabase database;
    private Context myContext;

    public DataBaseHelper(Context context) {
        super(context, DB_NAME, null, SCHEMA);
        this.myContext = context;
        DB_PATH = "/data/data/com.example.yoga/databases/";
    }
    public void create_db() {

        //обьявляю переменные для входного и выходного потоков
        InputStream myInput = null;
        OutputStream myOutput = null;
        try {
            //создаю файл
            File file = new File(DB_PATH + DB_NAME);
            //если файл не существует
            if (!file.exists()) {
                //получаю БД
                this.getWritableDatabase();
                //открываю поток для чтения
                myInput = myContext.getAssets().open(DB_NAME);
                String outFileName = DB_PATH + DB_NAME;
                //открываю поток для записи
                myOutput = new FileOutputStream(outFileName);
                byte[] buffer = new byte[1024];
                int length;
                //записываю данные в БД в цикле пока буфер не будет пустым
                while ((length = myInput.read(buffer)) > 0) {
                    myOutput.write(buffer, 0, length);
                }

                myOutput.flush();
                myOutput.close();
                myInput.close();
            }
        } catch (IOException ex) {

        }
    }

    public void createTableYoga(){
        open();
        // создаем таблицу с полями
        try {
        database.execSQL("create table Yoga ("
                + "id integer primary key autoincrement,"
                + "name text,"
                + "date text,"
                + "fullTime integer,"
                + "gameTime integer,"
                + "chips integer" + ");");
        } catch (Exception ex) {

        }
        close();
    }
    public void open() throws SQLException {
        String path = DB_PATH + DB_NAME;
        database = SQLiteDatabase.openDatabase(path, null, SQLiteDatabase.OPEN_READWRITE);
    }
    @Override
    public synchronized void close() {
        if (database != null) {
            database.close();
        }
        super.close();
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
    }
}
