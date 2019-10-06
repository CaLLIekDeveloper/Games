package com.example.quiz;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    private long backPressedTime;
    private Toast backToast;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


        //убираем строку состояния андроида
        Window window = getWindow();
        window.setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,WindowManager.LayoutParams.FLAG_FULLSCREEN);

        Button btn = findViewById(R.id.btn_start);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                try{
                    Intent intent = new Intent(MainActivity.this,GameLevels.class);
                    startActivity(intent);
                    finish();
                }catch (Exception ex)
                {

                }
            }
        });
    }

    //системная кнопка назад
    //закрытие приложения двойным кликом назад
    @Override
    public void onBackPressed() {
        super.onBackPressed();
        if(backPressedTime+2000 > System.currentTimeMillis())
        {
            backToast.cancel();
            super.onBackPressed();
            return;
        }else
        {
            backToast = Toast.makeText(getBaseContext(),"Нажмите еще раз, чтобы выйти",Toast.LENGTH_SHORT);
            backToast.show();
        }
        backPressedTime =  System.currentTimeMillis();
    }
}
