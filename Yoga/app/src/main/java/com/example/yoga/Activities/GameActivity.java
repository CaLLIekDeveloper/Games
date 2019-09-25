package com.example.yoga.Activities;

import android.content.Intent;
import android.content.res.Configuration;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import com.example.yoga.Classes.Globals;
import com.example.yoga.Classes.MovesYoga;
import com.example.yoga.R;

import java.util.Locale;

public class GameActivity extends AppCompatActivity {

    Button [][] buttons = new Button[7][7];
    TextView tvTimer;
    TextView tvMoves;

    private  CountDownTimer countDownTimer;
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
        setContentView(R.layout.activity_game);
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        //Заполняю массив кнопок игры
        buttons[0][0] = findViewById(R.id.btn11);
        buttons[0][1] = findViewById(R.id.btn12);
        buttons[0][2] = findViewById(R.id.btn13);
        buttons[0][3] = findViewById(R.id.btn14);
        buttons[0][4] = findViewById(R.id.btn15);
        buttons[0][5] = findViewById(R.id.btn16);
        buttons[0][6] = findViewById(R.id.btn17);

        buttons[1][0] = findViewById(R.id.btn21);
        buttons[1][1] = findViewById(R.id.btn22);
        buttons[1][2] = findViewById(R.id.btn23);
        buttons[1][3] = findViewById(R.id.btn24);
        buttons[1][4] = findViewById(R.id.btn25);
        buttons[1][5] = findViewById(R.id.btn26);
        buttons[1][6] = findViewById(R.id.btn27);

        buttons[2][0] = findViewById(R.id.btn31);
        buttons[2][1] = findViewById(R.id.btn32);
        buttons[2][2] = findViewById(R.id.btn33);
        buttons[2][3] = findViewById(R.id.btn34);
        buttons[2][4] = findViewById(R.id.btn35);
        buttons[2][5] = findViewById(R.id.btn36);
        buttons[2][6] = findViewById(R.id.btn37);

        buttons[3][0] = findViewById(R.id.btn41);
        buttons[3][1] = findViewById(R.id.btn42);
        buttons[3][2] = findViewById(R.id.btn43);
        buttons[3][3] = findViewById(R.id.btn44);
        buttons[3][4] = findViewById(R.id.btn45);
        buttons[3][5] = findViewById(R.id.btn46);
        buttons[3][6] = findViewById(R.id.btn47);

        buttons[4][0] = findViewById(R.id.btn51);
        buttons[4][1] = findViewById(R.id.btn52);
        buttons[4][2] = findViewById(R.id.btn53);
        buttons[4][3] = findViewById(R.id.btn54);
        buttons[4][4] = findViewById(R.id.btn55);
        buttons[4][5] = findViewById(R.id.btn56);
        buttons[4][6] = findViewById(R.id.btn57);

        buttons[5][0] = findViewById(R.id.btn61);
        buttons[5][1] = findViewById(R.id.btn62);
        buttons[5][2] = findViewById(R.id.btn63);
        buttons[5][3] = findViewById(R.id.btn64);
        buttons[5][4] = findViewById(R.id.btn65);
        buttons[5][5] = findViewById(R.id.btn66);
        buttons[5][6] = findViewById(R.id.btn67);

        buttons[6][0] = findViewById(R.id.btn71);
        buttons[6][1] = findViewById(R.id.btn72);
        buttons[6][2] = findViewById(R.id.btn73);
        buttons[6][3] = findViewById(R.id.btn74);
        buttons[6][4] = findViewById(R.id.btn75);
        buttons[6][5] = findViewById(R.id.btn76);
        buttons[6][6] = findViewById(R.id.btn77);

        //устанавливаю каждой кнопке тег с её номером
        for(int i=0; i<7; i++)
            for(int j=0; j<7; j++)
                buttons[i][j].setTag(""+i+""+j);

        View.OnClickListener onClickListener = new View.OnClickListener() {

            @Override
            public void onClick(View v) {

                Button temp = (Button)v;
                //если не конец игры
                if (!MovesYoga.endGame) {
                    //получаю координаты нажатой кнопки
                    int rowIndx, colIndx;

                    rowIndx = Integer.parseInt(""+temp.getTag().toString().charAt(0));
                    colIndx = Integer.parseInt(""+temp.getTag().toString().charAt(1));

                    //если кнопка находится в поле
                    if (colIndx != -1) {
                        if (xFrom == -1) {
                            //если на поле находится запрещенное поле иил пустое поле делаю выход из функции
                            if (MovesYoga.a[rowIndx][colIndx] == 0 || MovesYoga.a[rowIndx][colIndx] == 2) {
                                return;
                            }
                            xFrom = rowIndx;
                            yFrom = colIndx;
                            temp.setBackgroundResource(R.drawable.dotz);
                            RenderTable();
                        } else {
                            //если кнопка нажата во второй раз убираю подсветку кнопки
                            if (xFrom == rowIndx && yFrom == colIndx) {
                                xFrom = -1;
                                yFrom = -1;
                                RenderTable();
                                return;
                            }
                            //если ход сделан удаляю начальные значения нажатой фишки и отрисовую поле
                            if (MovesYoga.move(xFrom, yFrom, rowIndx, colIndx)) {
                                xFrom = -1;
                                yFrom = -1;
                                RenderTable();
                                //если игра окончена узнаю время игры и открываю активность конца игры
                                if (MovesYoga.EndGame()) {
                                    MovesYoga.endTime  = Integer.parseInt(tvTimer.getText().toString());
                                    OpenActivityEndGame();
                                }

                            }
                        }
                    }
                }
            }
        };

        for(int i=0; i<7; i++)
            for(int j=0; j<7; j++)
                buttons[i][j].setOnClickListener(onClickListener);


        //Нахожу текстовое поле для таймера
        tvTimer = findViewById(R.id.tvTimer);
        tvMoves = findViewById(R.id.tvCountMoves);
        Initiate();

        Button restart = findViewById(R.id.btnRestart);
        restart.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                OpenActivityGame();
            }
        });
    }

    //заполняю массив кнопок с помощью значений из массива поля Йоги
    //Устанавливаю на каждое значение нужную картинку
    private  void RenderTable()
    {
        for(int i=0; i<7; i++)
            for(int j=0; j<7; j++)
            {
                if (MovesYoga.a[i][j] == 0) {buttons[i][j].setBackgroundResource(R.drawable.nope);}
                if (MovesYoga.a[i][j] == 1) {buttons[i][j].setBackgroundResource(R.drawable.dot);}
                if (MovesYoga.a[i][j] == 2) {buttons[i][j].setBackgroundResource(R.drawable.empty);}
                if(i == xFrom && j == yFrom)buttons[i][j].setBackgroundResource(R.drawable.dotz);
            }
        tvMoves.setText(""+ MovesYoga.countMove);
    }

    int xFrom = -1, yFrom = -1;

    private void Initiate()
    {
        MovesYoga.fullTime = (Globals.TimeOfGame*60000)/1000;
        //Запускаю таймер по количеству минут игры
        countDownTimer = new CountDownTimer(Globals.TimeOfGame*60000 + 1000, 1000) {

            public void onTick(long millisUntilFinished) {
                tvTimer.setText("" + millisUntilFinished / 1000);
            }

            public void onFinish() {
                tvTimer.setText("END");
                MovesYoga.endTime = MovesYoga.fullTime;
                MovesYoga.endGame = true;
                OpenActivityEndGame();
            }
        }.start();
        MovesYoga.newGame();
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

    private void OpenActivityEndGame()
    {
        countDownTimer.cancel();
        Intent intent_fac = new Intent(this, EndGameActivity.class);
        startActivity(intent_fac);
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
    @Override
    public void onStop()
    {
        super.onStop();
        countDownTimer.cancel();
    }
}
