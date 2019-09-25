package com.example.yoga.Classes;

public class Move {
    int xFrom;
    int yFrom;

    int xTo;
    int yTo;

    int figure;

    //контруктор класса ХОД
    public Move(int xFrom, int yFrom, int xTo, int yTo, int figure) {
        this.xFrom = xFrom;
        this.yFrom = yFrom;
        this.xTo = xTo;
        this.yTo = yTo;
        this.figure = figure;
    }
}
