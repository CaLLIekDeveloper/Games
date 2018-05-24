package com.example.parsh;

import android.app.Application;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.ActivityInfo;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;
import android.widget.TextView;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;

// TODO: 16.04.2018 Добавить таблицу рекордов с временем (Новое активити для ввода имени для рекордсмена)
// TODO: 16.04.2018 Активити с рекордами
// TODO: 14.05.2018 Найти как заменить иконку когда сворачивается приложение на андроиде
// TODO: 14.05.2018
public class MainActivity extends AppCompatActivity implements View.OnClickListener  {

    Question game;
    boolean music = true;
    boolean continueGame = false;
    ImageButton bMusic;

    ImageButton btnNewGame;
    TextView tNewGame;
    ImageButton bSettings;
    TextView tSettings;
    ImageButton bExit;
    TextView tExit;
    final String FILEPROPERTIES = "Properties.txt";

    boolean isGame = false;

    public static SharedPreferences settings;
    public static final String  PREF_NAME = "strings.xml";
    public static final String APP_TITLE ="Заголовок";
    public static final String APP_LANG ="Язык";
    public static final String APP_NEW_GAME ="Новая игра";
    public static final String APP_SETTINGS ="Настройки";
    public static final String APP_EXIT ="Выход";
    public static final String APP_MUSIC ="MUSIC";


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        this.setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);
        btnNewGame = (ImageButton)findViewById(R.id.bNewGame);
        bMusic = (ImageButton)findViewById(R.id.bMusic);
        tNewGame = (TextView)findViewById(R.id.tNewGame);
        bSettings = (ImageButton)findViewById(R.id.bSettings);
        tSettings = (TextView)findViewById(R.id.tSettings);
        bExit = (ImageButton)findViewById(R.id.bExit);
        tExit= (TextView)findViewById(R.id.tExit);
        settings = getSharedPreferences("prefs.xml", MODE_PRIVATE);
        SetLanguage();

        game = new Question();
        writeFile();
        //readFile();

        //writeProperties();
        readProperties();
        sheck();
    }
    void SetLanguage()
    {
        setTitle(settings.getString(APP_TITLE,"Кто хочет стать миллионером"));
        tNewGame.setText(settings.getString(APP_NEW_GAME,"Новая игра"));
        tSettings.setText(settings.getString(APP_SETTINGS,"Настройки"));
        tExit.setText(settings.getString(APP_EXIT,"Выход"));
    }

    void sheck()
    {
        if(settings.getBoolean(APP_MUSIC,true))bMusic.setImageResource(R.drawable.music);
        else
            bMusic.setImageResource(R.drawable.no_music);
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.bExit:
                this.finish();
                System.exit(0);
                break;
            case R.id.bMusic:
                SharedPreferences.Editor prefEditor = MainActivity.settings.edit();
                prefEditor.putBoolean(MainActivity.APP_MUSIC,!settings.getBoolean(APP_MUSIC,true));
                prefEditor.apply();
                sheck();
                break;
            case R.id.bNewGame:
                if(!isGame) {
                    isGame = true;
                    Questions.ANSWERS.clear();
                    readFile();
                    Intent intent = new Intent(this, Game.class);
                    startActivityForResult(intent, 1);
                }

                break;
            case R.id.bSettings:
                Intent intent = new Intent(this, Settings.class);
                startActivityForResult(intent, 1);
                break;
            default:
                break;
        }
    }
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        if (data == null) {isGame = false; return;}
        sheck();
        isGame = false;
    }
    public void readProperties() {
        FileInputStream stream = null;
        StringBuilder sb = new StringBuilder();
        String line;
        Question temp = new Question();
        try {
            stream = openFileInput(FILEPROPERTIES);
            try {
                BufferedReader reader = new BufferedReader(new InputStreamReader(stream, "UTF-8"));

                int t=0;
                int number = 0;
                while ((line = reader.readLine()) != null) {
                    if(t==0){if(line=="1")music = true;else music=false;}
                    if(t==1){if(line=="1")continueGame= true; else continueGame=false;}
                    t++;
                }
            } finally {
                stream.close();
            }

        } catch (Exception e) {
        }
    }
    void writeProperties() {
        String text = "";
        if(music)text+="1\n";else text+="0\n";
        if(continueGame)text+="1\n"; else text+="0\n";
        try {
            // отрываем поток для записи
            BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(openFileOutput(game.fileName, MODE_PRIVATE)));
            // пишем данные
            bw.write(text);
            // закрываем поток
            bw.close();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }


    void writeFile() {
        String text ="За допомогою якої директиви відбувається підключення інших модулів програми?\n"+
                "#define\n"+
                "#ifndef\n"+
                "#pragma\n"+
                "#include\n";
        text+="Знайдіть правильний тип дійсного числа:\n"+
                "Flaot\n"+
                "long int\n"+
                "char\n"+
                "double\n";
        text+="У програмі на мові С++ обов’язково є функція\n"+
                "finish\n"+
                "head\n"+
                "start\n"+
                "main\n";
        text+="Яке з наведених імен є неприпустимим в С++?\n"+
                "oOOP\n"+
                "ox03488erJJJ___\n"+
                "or13\n"+
                "xb_@\n";
        text+="Чому дорівнює результат обчислення виразу x + 3 * b + x при x = 12 і b = 8?\n"+
                "132\n"+
                "300\n"+
                "50\n"+
                "48\n";
        text+="З якого символу починається запис директиви?\n"+
                "!\n"+
                "<\n"+
                "@\n"+
                "#\n";
        text+="Значення, яке поверне функція rand()%15, буде знаходитися:\n"+
                "між 0 і 15\n"+
                "рівно 15\n"+
                "від 0 до 15 включно\n"+
                "від 0 до 14 включно\n";
        text+="Яке слово зі списку не відноситься до зарезервованих слів С++?\n"+
                "class\n"+
                "inline\n"+
                "for\n"+
                "cout\n";
        text+="Де наведено правильний опис масиву c++\n"+
                "int a[];\n"+
                "b[10];\n"+
                "double b(n);\n"+
                "bool a[10];\n";
        text+="Опишіть мовою C++ одновимірний масив D, який містить 18 елементів одинарного дійсного типу.\n"+
                "double D[18]\n"+
                "float D[17]\n"+
                "double D[17]\n"+
                "float D[18]\n";
//10 вопросов есть
        text+="Що з перерахованого є оголошенням вказівника в С++?\n"+
                "int &a;\n"+
                "int a&;\n"+
                "int* &a;\n"+
                "int* a;\n";
        text+="Чим є ім’я масиву у мові програмування С++?\n"+
                "Простою змінною\n"+
                "Окремо не розглядається\n"+
                "Вказівником на його будь-який елемент\n"+
                "Вказівником на його перший елемент\n";
        text+="Сукупність типів формальних параметрів, їх порядку і імені функції визначає:\n"+
                "Послідовність описів функції\n"+
                "Ідентифікатор функції\n"+
                "Тип функції\n"+
                "Сигнатуру функції\n";
        text+="Скільки функцій може бути в програмі С++?\n"+
                "не більш 100\n"+
                "жодної\n"+
                "невизначено\n"+
                "мінімум одна\n";
        text+="Де вказується заголовок функції?\n"+
                "Першим рядком у файлі\n"+
                "У функції main()\n"+
                "Після функції main()\n"+
                "Перед функцією main()\n";
        text+="Сітка з горизонтальних та вертикальних стовпців, яку на екрані утворюють пікселі, називається:\n"+
                "видеопамять;\n"+
                "видеоадаптер;\n"+
                "дисплейный процессор;\n"+
                "растр;\n";
        text+="Графіка з представленням зображення у вигляді сукупності об'єктів називається:\n"+
                "фрактальною;\n"+
                "растровою;\n"+
                "прямолінійною;\n"+
                "векторною; \n";
        text+="Найменшим елементом поверхні екрану, для якого можуть бути задані адреса, колір та інтенсивність, є:\n"+
                "символ;\n"+
                "зерно люмінофора;\n"+
                "растр;\n"+
                "піксель;\n";
        text+="Що таке IP-адреса?\n"+
                "Вхідний пакет.\n"+
                "Інформаційний захист.\n"+
                "Інтерфейсне перетворення.\n"+
                "Інтернет протокол.\n";
        text+="Який кабель в основному використовується для з'єднання комп'ютерів в локальній мережі?\n"+
                "Оптоволокно\n"+
                "Телефонний\n"+
                "Коаксіальний\n"+
                "Вита пара\n";
//19 питань

        try {
            // отрываем поток для записи
            BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(openFileOutput(game.fileName, MODE_PRIVATE)));
            // пишем данные
            bw.write(text);
            // закрываем поток
            bw.close();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }


    public void readFile() {
        //Questions.ANSWERS.clear();
        FileInputStream stream = null;
        StringBuilder sb = new StringBuilder();
        String line;
        Question temp = new Question();

        try {
            stream = openFileInput(game.fileName);

            try {
                BufferedReader reader = new BufferedReader(new InputStreamReader(stream, "UTF-8"));

                int t=0;
                int number = 0;
                while ((line = reader.readLine()) != null) {
                    //sb.append(line);
                    if(t==0)temp.question = line;
                    else
                    {temp.answers.add(line); if (t==4){temp.correctAnswer=line; Questions.ANSWERS.add(temp); temp= new Question(); t=-1;}}
                    t++;
                }
            } finally {
                stream.close();
            }

        } catch (Exception e) {
        }
    }


    @Override
    protected void onStart() {
        super.onStart();
        SetLanguage();
        sheck();
    }
}
