package com.example.yoga.Activities;

import android.content.Intent;
import android.content.res.Configuration;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import com.example.yoga.Classes.DataBaseHelper;
import com.example.yoga.Classes.Globals;
import com.example.yoga.R;

import java.util.Locale;


public class MainActivity extends AppCompatActivity {
    Button btnExit,btnNewGame,btnSettings,btnHighscores;

    @Override
    protected  void onStart()
    {
        super.onStart();
        if(Globals.Language==0)ChangeLanguage(true);
        else
            ChangeLanguage(false);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        Globals.sPref = getPreferences(MODE_PRIVATE);
        //загружаю из предпочтений сохраненные настройки
        loadText();
        if(Globals.Language==0)ChangeLanguage(true);
        else
            ChangeLanguage(false);


        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);


        //нахожу по айди елементы с макета
        btnExit = findViewById(R.id.btnExit);
        btnNewGame = findViewById(R.id.btnNewGame);
        btnHighscores = findViewById(R.id.btnHighscores);
        btnSettings = findViewById(R.id.btnSettings);

        //устанавливаю кнопкам событие на клик
        btnNewGame.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                OpenActivityGame();
            }
        });

        btnHighscores.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                OpenActivityHighscores();
            }
        });

        btnSettings.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                OpenActivitySettings();
            }
        });

        btnExit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Exit();
            }
        });


        //устанавливаю глобальные переменные


        Globals.sqlHelper = new DataBaseHelper(this);
        Globals.sqlHelper.create_db();
        Globals.sqlHelper.createTableYoga();


    }
    private void Exit()
    {
        Intent intent = new Intent(Intent.ACTION_MAIN);
        intent.addCategory(Intent.CATEGORY_HOME);
        intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        startActivity(intent);
    }

    // Загружаю данные из предпочтений
    void loadText() {
        Globals.TimeOfGame = Integer.parseInt(Globals.sPref.getString(Globals.SAVED_TIME, "5"));
        Globals.Language = Globals.sPref.getInt(Globals.SAVED_LANGUAGE,0);
    }


    private void ChangeLanguage(boolean flag) {
        Locale locale;
        if(flag) {
            locale = new Locale("ru");

        }else
        {
            locale = new Locale("en");
        }
        Locale.setDefault(locale);
        Configuration config = new Configuration();
        config.locale = locale;
        getBaseContext().getResources().updateConfiguration(config, null);
    }





    private void OpenActivityGame()
    {
        Intent intent_fac = new Intent(this, GameActivity.class);
        startActivity(intent_fac);
    }

    private void OpenActivityHighscores()
    {
        Intent intent_fac = new Intent(this, HighscoresActivity.class);
        startActivity(intent_fac);
    }

    private void OpenActivitySettings()
    {
        Intent intent_fac = new Intent(this, SettingsActivity.class);
        startActivity(intent_fac);
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            OpenActivitySettings();
        }

        if (id == R.id.mmNew_Game) {
            OpenActivityGame();
        }

        if (id == R.id.mmHighscores) {
            OpenActivityHighscores();
        }
        return super.onOptionsItemSelected(item);
    }
}
