package com.example.yoga.Activities;

import android.content.Context;
import android.content.Intent;
import android.content.res.Configuration;
import android.database.Cursor;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import com.example.yoga.Classes.Globals;
import com.example.yoga.Classes.StructDB;
import com.example.yoga.R;

import java.util.Locale;

public class HighscoresActivity extends AppCompatActivity {

    private LinearLayout mainLayout;

    private Cursor userCursor;

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
        if(Globals.Language==0)ChangeLanguage(true);
        else
            ChangeLanguage(false);

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_highscores);
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        mainLayout = findViewById(R.id.container_highscores);
        addFragment();
    }

    //метод добавляющий фрагменты на главный макет
    void addFragment()
    {
        //удаляю все виды из главного макета
        mainLayout.removeAllViews();
        //открываю доступ к бд
        Globals.sqlHelper.open();
        //исполняю запрос к бд выбираю все данные из Таблицы Yoga
        // сортирую данные сначала по полю фишек по убыванию следом по времени игры и в конце по полному времени на игру
        userCursor = Globals.sqlHelper.database.rawQuery("SELECT * FROM Yoga ORDER BY chips DESC, gameTime ASC, fullTime ASC;",null);
        //получаю количество записей полученных из бд
        int count = userCursor.getCount();
        if(count>0) {
            //перехожу на первую запись
            userCursor.moveToFirst();

            for(int i=0; i<count; i++) {
                //создаю переменную вида
                StructDB temp = new StructDB();
                //заполняю её данными из курсора
                temp.getStructDB(userCursor);
                //добавляю вид на главный макет
                mainLayout.addView(getViewHighscoresRecord(this.getApplicationContext(),temp));
                //перехожу на следующую запись
                userCursor.moveToNext();
            }
        }
        else
        {
            View view = getLayoutInflater().inflate(R.layout.fragment_no_records, null);
            mainLayout.addView(view);
        }
        //закрываю доступ к БД
        userCursor.close();
        Globals.sqlHelper.close();
    }

    //метод заполняющий данными из бд фрагмент
    public View getViewHighscoresRecord(Context context, StructDB structDB)
    {
        LayoutInflater inflater = (LayoutInflater) context.getSystemService( Context.LAYOUT_INFLATER_SERVICE );
        View view = inflater.inflate(R.layout.fragment_record, null);
        TextView tvName = view.findViewById(R.id.fName);
        TextView tvDate = view.findViewById(R.id.fDate);
        TextView tvFullTime = view.findViewById(R.id.fTimeForGame);
        TextView tvGameTime = view.findViewById(R.id.fTimeGame);
        TextView tvChips = view.findViewById(R.id.fChips);

        tvName.setText(structDB.name);
        tvDate.setText(structDB.date);
        tvFullTime.setText(""+structDB.fullTime);
        tvGameTime.setText(""+structDB.gameTime);
        tvChips.setText(""+structDB.chips);

        return view;
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


    //методы для перехода между активностями

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

    private void OpenActivityMainMenu()
    {
        Intent intent_fac = new Intent(this, MainActivity.class);
        startActivity(intent_fac);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_game, menu);
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

        if(id == R.id.mmMainMenu){
            OpenActivityMainMenu();
        }
        return super.onOptionsItemSelected(item);
    }

}
