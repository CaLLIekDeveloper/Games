package com.example.yoga.Classes;

public class MovesYoga {
    public static int a[][] = new int[7][7];

    public static int countMove = 0;
    public static int countDot;
    public static Move lastMove;
    public static boolean endGame = false;

    public static int ndx = -1;
    public static int ndy = -1;

    public static int fullTime;
    public static int endTime;

    //нет хода - 0
    //точка - 1
    //возможный ход - 2
    static public void newGame() {
        //заполняю массив игрового поля нужными значениями
        for (int i = 0; i < 7; i++) {
            for (int j = 0; j < 7; j++) {
                a[i][j] = 1;
            }
        }
        a[0][0] = 0;
        a[0][1] = 0;
        a[1][0] = 0;
        a[1][1] = 0;

        a[0][5] = 0;
        a[0][6] = 0;
        a[1][5] = 0;
        a[1][6] = 0;

        a[5][0] = 0;
        a[5][1] = 0;
        a[6][0] = 0;
        a[6][1] = 0;

        a[5][5] = 0;
        a[5][6] = 0;
        a[6][5] = 0;
        a[6][6] = 0;

        a[3][3] = 2;

        endGame = false;
        countMove = 0;
    }

    //метод проверки возможности хода с точки From в точку To
    static public boolean move(int xFrom, int yFrom, int xTo, int yTo) {
    //если текущее поле пустое
        if (a[xTo][yTo] == 2) {
            //запоминаю начальную фигуру
            int temp = a[xFrom][yFrom];
            //пытаюсь сделать ход
            lastMove = new Move(xFrom, yFrom, xTo, yTo, temp);
            //если ход можно сделать
            if (CheackMove()) {
                //присваиваю полю откуда был сделал ход пустое поле
                a[xFrom][yFrom] = 2;
                //присваиваю полю куда был сделан ход поле с фишкой
                a[xTo][yTo] = 1;
                //присваиваю поле с фишкой через которую мы сделали ход пустое поле
                a[ndx][ndy] = 2;
                //добавляю количество ходов
                countMove++;
                return true;
            //иначе удаляю данные
            } else {
                ndx = -1;
                ndy = -1;
                lastMove = null;
            }
        }
        return false;
    }

    //проверка на конец игры
    static public boolean EndGame() {
        countDot = 0;
        for (int i = 0; i < 7; i++) {
            for (int j = 0; j < 7; j++) {
                //если в клетке стоит точка то производится проверка на её взятие со всех возможных позиций
                if (a[i][j] == 1) {
                    countDot++;

                    if (CheackMove(new Move(i, j, i + 2, j, 1))) {
                        return false;
                    }
                    if (CheackMove(new Move(i, j, i - 2, j, 1))) {
                        return false;
                    }
                    if (CheackMove(new Move(i, j, i, j + 2, 1))) {
                        return false;
                    }
                    if (CheackMove(new Move(i, j, i, j - 2, 1))) {
                        return false;
                    }
                }
            }
        }
        endGame = true;
        return true;
    }

    static private boolean CheackMove() {

        if (lastMove.xFrom == lastMove.xTo) {
            if (Math.abs(lastMove.yFrom - lastMove.yTo) == 2) {
                if (lastMove.yFrom > lastMove.yTo) {
                    ndx = lastMove.xFrom;
                    ndy = lastMove.yFrom - 1;
                } else {
                    ndx = lastMove.xFrom;
                    ndy = lastMove.yFrom + 1;
                }
                if (a[ndx][ndy] == 1) {
                    return true;
                }
            }
        }
        if (lastMove.yFrom == lastMove.yTo) {
            if (Math.abs(lastMove.xFrom - lastMove.xTo) == 2) {
                if (lastMove.xFrom > lastMove.xTo) {
                    ndx = lastMove.xFrom - 1;
                    ndy = lastMove.yTo;
                } else {
                    ndx = lastMove.xFrom + 1;
                    ndy = lastMove.yTo;
                }
                if (a[ndx][ndy] == 1) {
                    return true;
                }
            }
        }
        return false;
    }

    static private boolean CheackMove(Move move) {
        //если фишка с ходом находится не в поле ход невозможно сделать
        if (move.xTo < 0 || move.xTo > 6) {
            return false;
        }
        //если фишка куда идет ход находится не в поле ход невозможно сделать
        if (move.yTo < 0 || move.yTo > 6) {
            return false;
        }
        //если поле куда хочет пойти игрок не являеться пустым игровым полем ход сделать невозможно
        if (a[move.xTo][move.yTo] != 2) {
            return false;
        }

        if (move.xFrom == move.xTo) {
            if (Math.abs(move.yFrom - move.yTo) == 2) {
                if (move.yFrom > move.yTo) {
                    ndx = move.xFrom;
                    ndy = move.yFrom - 1;
                } else {
                    ndx = move.xFrom;
                    ndy = move.yFrom + 1;
                }
                if (a[ndx][ndy] == 1) {
                    return true;
                }
            }
        }
        if (move.yFrom == move.yTo) {
            if (Math.abs(move.xFrom - move.xTo) == 2) {
                if (move.xFrom > move.xTo) {
                    ndx = move.xFrom - 1;
                    ndy = move.yTo;
                } else {
                    ndx = move.xFrom + 1;
                    ndy = move.yTo;
                }
                if (a[ndx][ndy] == 1) {
                    return true;
                }
            }
        }
        return false;
    }
}
