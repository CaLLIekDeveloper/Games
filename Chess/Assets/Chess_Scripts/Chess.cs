using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using MainStatic;

namespace MyGame
{
    public class Chess
    {
        public string fen;
        Board board;
        Moves moves;
        List<FigureMoving> allMoves;
        List<string> allMovesString;
        public Chess(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
        {
            this.fen = fen;
            board = new Board(fen);
            moves = new Moves(board);

        }

        Chess(Board board)
        {

            this.board = board;
            this.fen = board.fen;
            moves = new Moves(board);
        }


        public Chess Move(String move)
        {
            FigureMoving fm = new FigureMoving(move);
            if (!moves.CanMove(fm))
                return this;
            if (board.IsCheckAfterMove(fm))
                return this;
            Board nextBoard;
            Chess nextChess;

            if (fm.figure == Figure.blackPawn || fm.figure == Figure.whitePawn)
            {
                if (fm.to.y == 0)
                {
                    fm.promotion = Figure.blackQueen;
                    nextBoard = board.Move(fm);
                    nextChess = new Chess(nextBoard);

                    return nextChess;
                }
                if (fm.to.y == 7)
                {
                    fm.promotion = Figure.whiteQueen;
                    nextBoard = board.Move(fm);
                    nextChess = new Chess(nextBoard);

                    return nextChess;

                }

                if (fm.from.x != fm.to.x && board.GetFigureAt(fm.to) == Figure.none)
                {
                    FigureMoving fmt = new FigureMoving(Main.previousMove);
                    nextBoard = board.Move(fm);
                    nextBoard.SetFigureAt(fmt.to, Figure.none);
                    nextBoard.GenerateFen();
                    nextChess = new Chess(nextBoard);
                    return nextChess;
                }
            }

            nextBoard = board.Move(fm);
            nextChess = new Chess(nextBoard);

            if (fm.from != fm.to)
            {
                if (fm.figure == Figure.whiteKing)
                    Castling.isWhiteKingMoves = true;
                if (fm.figure == Figure.blackKing)
                    Castling.isBlackKingMoves = true;

                if (fm.from == new Square(0, 0))
                    Castling.isWhiteRookMovesLeft = true;
                if (fm.from == new Square(7, 0))
                    Castling.isWhiteRookMovesRight = true;

                if (fm.to == new Square(0, 0))
                    Castling.isWhiteRookMovesLeft = true;
                if (fm.to == new Square(7, 0))
                    Castling.isWhiteRookMovesRight = true;


                if (fm.from == new Square(0, 7))
                    Castling.isBlackRookMovesLeft = true;
                if (fm.from == new Square(7, 7))
                    Castling.isBlackRookMovesRight = true;
                if (fm.to == new Square(0, 7))
                    Castling.isBlackRookMovesLeft = true;
                if (fm.to == new Square(7, 7))
                    Castling.isBlackRookMovesRight = true;

                if (fm.ToString() == "Ke1g1")
                {
                    Board nextBoard1 = nextBoard.Move(new FigureMoving("Rh1f1"));
                    nextBoard1.moveColor = Color.black;
                    nextChess = new Chess(nextBoard1);
                }
                if (fm.ToString() == "Ke1c1")
                {
                    Board nextBoard1 = nextBoard.Move(new FigureMoving("Ra1d1"));
                    nextBoard1.moveColor = Color.black;
                    nextChess = new Chess(nextBoard1);
                }

                if (fm.ToString() == "ke8g8")
                {
                    Board nextBoard1 = nextBoard.Move(new FigureMoving("rh8f8"));
                    nextBoard1.moveColor = Color.white;
                    nextChess = new Chess(nextBoard1);
                }
                if (fm.ToString() == "ke8c8")
                {
                    Board nextBoard1 = nextBoard.Move(new FigureMoving("ra8d8"));
                    nextBoard1.moveColor = Color.white;
                    nextChess = new Chess(nextBoard1);
                }
            }
            return nextChess;
        }


        public Chess UndoMove(String move, Figure figure)
        {
            String tempMove = "" + move[0] + move[3] + move[4] + move[1] + move[2];
            FigureMoving fm = new FigureMoving(tempMove);
            Board nextBoard;
            Chess nextChess;
            nextBoard = board.Move(fm);
            if (figure != Figure.none) nextBoard.SetFigureAt(fm.from, figure);
            nextChess = new Chess(nextBoard);
            /*
            if (fm.from != fm.to)
            {
                if (fm.figure == Figure.whiteKing)
                    Castling.isWhiteKingMoves = true;
                if (fm.figure == Figure.blackKing)
                    Castling.isBlackKingMoves = true;

                if (fm.from == new Square(0, 0))
                    Castling.isWhiteRookMoves1 = true;
                if (fm.from == new Square(7, 0))
                    Castling.isWhiteRookMoves2 = true;

                if (fm.to == new Square(0, 0))
                    Castling.isWhiteRookMoves1 = true;
                if (fm.to == new Square(7, 0))
                    Castling.isWhiteRookMoves2 = true;

                if (fm.from == new Square(0, 7))
                    Castling.isBlackRookMoves1 = true;
                if (fm.from == new Square(7, 7))
                    Castling.isBlackRookMoves2 = true;
                if (fm.to == new Square(0, 7))
                    Castling.isBlackRookMoves1 = true;
                if (fm.to == new Square(7, 7))
                    Castling.isBlackRookMoves2 = true;
            }
            */


            return nextChess;
        }

        public Figure GetFigureAt(Square temp)
        {
            Figure f = board.GetFigureAt(temp);
            return f;
        }

        public char GetFigureAt(string s)
        {
            int x = s[0] - 'a';
            int y = s[1] - '1';

            Square square = new Square(x, y);
            Figure f = board.GetFigureAt(square);
            return f == Figure.none ? '.' : (char)f;
        }

        public char GetFigureAt(int x, int y)
        {
            Square square = new Square(x, y);
            Figure f = board.GetFigureAt(square);
            return f == Figure.none ? '.' : (char)f;
        }

        public bool FigureColorIsWhite(string s)
        {
            return (FigureMethods.GetColor((Figure)GetFigureAt(s)) == Color.white) ? true : false;
        }

        public void FindAllMoves()
        {
            allMoves = new List<FigureMoving>();
            allMovesString = new List<string>();
            foreach (FigureOnSquare fs in board.YieldFigures())
                foreach (Square to in Square.YieldSquares())
                {
                    FigureMoving fm = new FigureMoving(fs, to);
                    if (moves.CanMove(fm))
                        if (!board.IsCheckAfterMove(fm))
                        {
                            allMovesString.Add(fm.ToString());
                            allMoves.Add(fm);
                        }
                }

        }

        public List<string> GetAllMoves()
        {
            return allMovesString;
        }

        public bool IsCheck()
        {
            return board.IsCheck();
        }

        public bool isWhiteStep()
        {
            if (board.moveColor == Color.white)
                return true;
            return false;
        }
    }

    class Board
    {
        public string fen { get; private set; }
        Figure[,] figures;
        public Color moveColor { get; set; }
        public int moveNumber { get; private set; }

        public Board(string fen)
        {
            this.fen = fen;
            figures = new Figure[8, 8];
            Init();
        }

        void Init()
        {
            //rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
            string[] parts = fen.Split();
            if (parts.Length != 6) return;
            InitFigures(parts[0]);
            moveColor = parts[1] == "b" ? Color.black : Color.white;
            moveNumber = int.Parse(parts[5]);
            moveColor = Color.white;
        }

        void InitFigures(string data)
        {
            for (int j = 8; j >= 2; j--)
                data = data.Replace(j.ToString(), (j - 1).ToString() + "1");
            data = data.Replace("1", ".");
            string[] lines = data.Split('/');
            for (int y = 7; y >= 0; y--)
                for (int x = 0; x < 8; x++)
                    figures[x, y] = lines[7 - y][x] == '.' ? Figure.none : (Figure)lines[7 - y][x];

        }

        public IEnumerable<FigureOnSquare> YieldFigures()
        {
            foreach (Square square in Square.YieldSquares())
                if (GetFigureAt(square).GetColor() == moveColor)
                    yield return new FigureOnSquare(GetFigureAt(square), square);
        }

        public Figure GetFigureAt(Square square)
        {
            if (square.OnBoard())
                return figures[square.x, square.y];
            return Figure.none;
        }

        public void SetFigureAt(Square square, Figure figure)
        {
            if (square.OnBoard())
                figures[square.x, square.y] = figure;
        }

        public Board Move(FigureMoving fm)
        {
            Board next = new Board(fen);
            next.SetFigureAt(fm.from, Figure.none);
            next.SetFigureAt(fm.to, fm.promotion == Figure.none ? fm.figure : fm.promotion);
            if (moveColor == Color.black)
                next.moveNumber++;
            next.moveColor = moveColor.flipColor();
            next.GenerateFen();
            return next;
        }

        string FenFigures()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 7; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                    sb.Append(figures[x, y] == Figure.none ? '1' : (char)figures[x, y]);
                if (y > 0)
                    sb.Append('/');
            }
            string eight = "11111111";
            for (int j = 8; j >= 2; j--)
                sb.Replace(eight.Substring(0, j), j.ToString());
            return sb.ToString();
        }

        public void GenerateFen()
        {
    
            string FenPawn = "";
            FigureMoving fmTemp = new FigureMoving(Main.previousMove);
            if(fmTemp.figure==Figure.blackPawn  || fmTemp.figure==Figure.whitePawn)
            {
                if (fmTemp.from.y==6 || fmTemp.from.y==1)
                {
                        FenPawn = fmTemp.from.PawnEnPassant();
                    Debug.Log("FenPawn: " + FenPawn);
                }
            }
            if (FenPawn.Length == 0) FenPawn = "-";
            fen = FenFigures() + " " + (moveColor == Color.white ? "w" : "b") +" "+Castling.FenCastling()
                +" "+ FenPawn + " 0 " + moveNumber.ToString();
        }

        bool CanEatKing()
        {
            Square badKing = FindBadKing();
            Moves moves = new Moves(this);
            foreach (FigureOnSquare fs in YieldFigures())
            {
                FigureMoving fm = new FigureMoving(fs, badKing);
                if (moves.CanMove(fm))
                    return true;
            }
            return false;
        }

        public bool CanEatSquare(Square temp)
        {
            Moves moves = new Moves(this);
            foreach (FigureOnSquare fs in YieldFigures())
            {
                FigureMoving fm = new FigureMoving(fs, temp);
                if (moves.CanMove(fm))
                    return true;
            }
            return false;
        }

        Square FindBadKing()
        {
            Figure badKing = moveColor == Color.black ? Figure.whiteKing : Figure.blackKing;
            foreach (Square square in Square.YieldSquares())
            {
                if (GetFigureAt(square) == badKing)
                    return square;
            }
            return Square.none;
        }
        public bool IsCheck()
        {
            Board after = new Board(fen);
            after.moveColor = moveColor.flipColor();
            return after.CanEatKing();
        }

        public bool IsCheckAfterMove(FigureMoving fm)
        {
            Board after = Move(fm);
            return after.CanEatKing();
        }
    }
    enum Color
    {
        none,
        white,
        black
    }

    static class ColorMethods
    {
        public static Color flipColor(this Color color)
        {
            if (color == Color.black) return Color.white;
            if (color == Color.white) return Color.black;
            return Color.none;

        }
    }
    public enum Figure
    {
        none,
        whiteKing = 'K',
        whiteQueen = 'Q',
        whiteRook = 'R',
        whiteBishop = 'B',
        whiteKnight = 'N',
        whitePawn = 'P',

        blackKing = 'k',
        blackQueen = 'q',
        blackRook = 'r',
        blackBishop = 'b',
        blackKnight = 'n',
        blackPawn = 'p',

    }

    static class FigureMethods
    {
        public static Color GetColor(this Figure figure)
        {
            if (figure == Figure.none)
                return Color.none;

            return (figure == Figure.whiteKing ||
                figure == Figure.whiteBishop ||
                figure == Figure.whiteKnight ||
                figure == Figure.whitePawn ||
                figure == Figure.whiteQueen ||
                figure == Figure.whiteRook
                ) ? Color.white : Color.black;


        }
    }
    class FigureMoving
    {
        public Figure figure { get; private set; }
        public Square from { get; private set; }
        public Square to { get; private set; }
        public Figure promotion { get; set; }

        public FigureMoving(FigureOnSquare fs, Square to, Figure promotion = Figure.none)
        {
            this.figure = fs.figure;
            this.from = fs.square;
            this.to = to;
            this.promotion = promotion;
        }

        public FigureMoving(string move)
        {
            if (move != null)
            {
                this.figure = (Figure)move[0];
                this.from = new Square(move.Substring(1, 2));
                this.to = new Square(move.Substring(3, 2));
                this.promotion = (move.Length == 6) ? (Figure)move[5] : Figure.none;
            }

        }

        public int DeltaX { get { return to.x - from.x; } }
        public int DeltaY { get { return to.y - from.y; } }

        public int AbsDeltaX { get { return Math.Abs(DeltaX); } }
        public int AbsDeltaY { get { return Math.Abs(DeltaY); } }

        public int SignX { get { return Math.Sign(DeltaX); } }
        public int SignY { get { return Math.Sign(DeltaY); } }


        public override string ToString()
        {
            string text = (char)figure + from.Name + to.Name;
            if (promotion != Figure.none)
                text += (char)promotion;
            return text;
        }
    }
    class FigureOnSquare
    {
        public Figure figure { get; private set; }
        public Square square { get; private set; }

        public FigureOnSquare(Figure figure, Square square)
        {
            this.figure = figure;
            this.square = square;
        }

    }
    class Moves
    {
        FigureMoving fm;
        Board board;

        public Moves(Board board)
        {
            this.board = board;
        }

        public bool CanMove(FigureMoving fm)
        {
            this.fm = fm;
            return
                CanMoveFrom() &&
                CanMoveTo() &&
                CanFigureMove();
        }

        bool CanMoveFrom()
        {
            return fm.from.OnBoard() && fm.figure.GetColor() == board.moveColor;
        }

        bool CanMoveTo()
        {
            return fm.to.OnBoard() && fm.from != fm.to && board.GetFigureAt(fm.to).GetColor() != board.moveColor;
        }
        bool CanFigureMove()
        {
            switch (fm.figure)
            {
                case Figure.whiteKing:
                    return CanKWhiteKingMove();

                case Figure.blackKing:
                    return CanBlackKingMove();

                case Figure.whiteQueen:
                case Figure.blackQueen:
                    return CanStraightMove();

                case Figure.whiteRook:
                case Figure.blackRook:
                    return (fm.SignX == 0 || fm.SignY == 0)
                        && CanStraightMove();

                case Figure.whiteBishop:
                case Figure.blackBishop:
                    return (fm.SignX != 0 && fm.SignY != 0)
                        && CanStraightMove();

                case Figure.whiteKnight:
                case Figure.blackKnight:
                    return CanKnightMove();

                case Figure.whitePawn:
                    return CanWhitePawnMove();
                case Figure.blackPawn:
                    return CanBlackPawnMove();
                default: return false;
            }

        }
        private bool CanKWhiteKingMove()
        {
            if (!Castling.isWhiteKingMoves && !Castling.isWhiteRookMovesLeft)
            {
                //Debug.Log("Можно сделать рокировку на c1");
                if (fm.to == new Square(2, 0))
                {
                    if (board.GetFigureAt(new Square(3, 0)) == Figure.none && board.GetFigureAt(new Square(2, 0)) == Figure.none)
                    {
                        FigureMoving moveK = new FigureMoving(new FigureOnSquare(Figure.whiteKing, new Square(4, 0)), new Square(4, 0));
                        FigureMoving moveK1 = new FigureMoving(new FigureOnSquare(Figure.whiteKing, new Square(4, 0)), new Square(3, 0));
                        FigureMoving moveK2 = new FigureMoving(new FigureOnSquare(Figure.whiteKing, new Square(4, 0)), new Square(2, 0));

                        //Debug.Log("XOD: " + moveK2.ToString());
                        if (!board.IsCheckAfterMove(moveK) && !board.IsCheckAfterMove(moveK1) && !board.IsCheckAfterMove(moveK2))
                            return true;
                    }

                }
            }

            if (!Castling.isWhiteKingMoves && !Castling.isWhiteRookMovesRight)
                if (fm.to == new Square(6, 0))
                {
                    if (board.GetFigureAt(new Square(5, 0)) == Figure.none && board.GetFigureAt(new Square(6, 0)) == Figure.none)
                    {

                        FigureMoving moveK = new FigureMoving(new FigureOnSquare(Figure.whiteKing, new Square(4, 0)), new Square(4, 0));
                        FigureMoving moveK1 = new FigureMoving(new FigureOnSquare(Figure.whiteKing, new Square(4, 0)), new Square(5, 0));
                        FigureMoving moveK2 = new FigureMoving(new FigureOnSquare(Figure.whiteKing, new Square(4, 0)), new Square(6, 0));

                        if (!board.IsCheckAfterMove(moveK) && !board.IsCheckAfterMove(moveK1) && !board.IsCheckAfterMove(moveK2))
                            return true;
                    }
                }

            if (fm.AbsDeltaX <= 1 && fm.AbsDeltaY <= 1)
                return true;
            return false;
        }

        private bool CanBlackKingMove()
        {
            if (!Castling.isBlackKingMoves && !Castling.isBlackRookMovesLeft)
            {
                if (fm.to == new Square(2, 7))
                {
                    if (board.GetFigureAt(new Square(3, 7)) == Figure.none && board.GetFigureAt(new Square(2, 7)) == Figure.none)
                    {
                        FigureMoving moveK = new FigureMoving(new FigureOnSquare(Figure.blackKing, new Square(4, 7)), new Square(4, 7));
                        FigureMoving moveK1 = new FigureMoving(new FigureOnSquare(Figure.blackKing, new Square(4, 7)), new Square(3, 7));
                        FigureMoving moveK2 = new FigureMoving(new FigureOnSquare(Figure.blackKing, new Square(4, 7)), new Square(2, 7));

                        if (!board.IsCheckAfterMove(moveK) && !board.IsCheckAfterMove(moveK1) && !board.IsCheckAfterMove(moveK2))
                            return true;
                    }

                }
            }

            if (!Castling.isBlackKingMoves && !Castling.isBlackRookMovesRight)
                if (fm.to == new Square(6, 7))
                {
                    if (board.GetFigureAt(new Square(5, 7)) == Figure.none && board.GetFigureAt(new Square(6, 7)) == Figure.none)
                    {

                        FigureMoving moveK = new FigureMoving(new FigureOnSquare(Figure.blackKing, new Square(4, 7)), new Square(4, 7));
                        FigureMoving moveK1 = new FigureMoving(new FigureOnSquare(Figure.blackKing, new Square(4, 7)), new Square(5, 7));
                        FigureMoving moveK2 = new FigureMoving(new FigureOnSquare(Figure.blackKing, new Square(4, 7)), new Square(6, 7));

                        if (!board.IsCheckAfterMove(moveK) && !board.IsCheckAfterMove(moveK1) && !board.IsCheckAfterMove(moveK2))
                            return true;
                    }
                }

            if (fm.AbsDeltaX <= 1 && fm.AbsDeltaY <= 1)
                return true;
            return false;
        }
        private bool CanKnightMove()
        {
            if (fm.AbsDeltaX == 1 && fm.AbsDeltaY == 2) return true;
            if (fm.AbsDeltaX == 2 && fm.AbsDeltaY == 1) return true;
            return false;
        }
        private bool CanBishopMove()
        {
            return false;
        }
        private bool CanStraightMove()
        {
            Square at = fm.from;
            do
            {
                at = new Square(at.x + fm.SignX, at.y + fm.SignY);
                if (at == fm.to)
                    return true;

            } while (at.OnBoard() &&
            board.GetFigureAt(at) == Figure.none);
            return false;
        }

        private bool CanBlackPawnMove()
        {
            if (fm.from.y < 1 || fm.from.y > 6)
                return false;
            int stepY = fm.figure.GetColor() == Color.white ? 1 : -1;
            return CanPawnGo(stepY) ||
                CanPawnJump(stepY) ||
                CanBlackPawnEat(stepY);
        }



        private bool CanWhitePawnMove()
        {
            if (fm.from.y < 1 || fm.from.y > 6)
                return false;
            int stepY = fm.figure.GetColor() == Color.white ? 1 : -1;
            return CanPawnGo(stepY) ||
                CanPawnJump(stepY) ||
                CanWhitePawnEat(stepY);
        }

        private bool CanPawnJump(int stepY)
        {
            if (board.GetFigureAt(fm.to) == Figure.none)
                if (fm.DeltaX == 0)
                    if (fm.DeltaY == 2 * stepY)
                        if (fm.from.y == 1 || fm.from.y == 6)
                            if (board.GetFigureAt(new Square(fm.from.x, fm.from.y + stepY)) == Figure.none)
                                return true;
            return false;


        }

        private bool CanPawnGo(int stepY)
        {
            if (board.GetFigureAt(fm.to) == Figure.none)
                if (fm.DeltaX == 0)
                    if (fm.DeltaY == stepY)
                        return true;
            return false;
        }

        private bool CanWhitePawnEat(int stepY)
        {
            //Взятие на проходе  En passant
            if (fm.from.y == 4)
            {
                FigureMoving fmt = new FigureMoving(Main.previousMove);
                if (fmt.figure == Figure.blackPawn)
                {
                    if (fmt.from.y == 6 && fmt.to.y == 4)
                    {
                        if (fm.to.x == fmt.from.x)
                        {
                            if (fm.to.y == 5)
                                return true;
                        }
                        if (fm.to.x == fmt.from.x)
                        {

                            if (fm.to.y == 5)
                                return true;
                        }
                    }
                }
            }

            if (board.GetFigureAt(fm.to) != Figure.none)
                if (fm.AbsDeltaX == 1)
                    if (fm.DeltaY == stepY)
                        return true;
            return false;
        }

        private bool CanBlackPawnEat(int stepY)
        {
            if (fm.from.y == 3)
            {
                FigureMoving fmt = new FigureMoving(Main.previousMove);
                if (fmt.figure == Figure.whitePawn)
                {
                    if (fmt.from.y == 1 && fmt.to.y == 3)
                    {
                        if (fm.to.x == fmt.from.x)
                        {
                            if (fm.to.y == 2)
                                return true;
                        }
                        if (fm.to.x == fmt.from.x)
                        {

                            if (fm.to.y == 2)
                                return true;
                        }
                    }
                }
            }

            if (board.GetFigureAt(fm.to) != Figure.none)
                if (fm.AbsDeltaX == 1)
                    if (fm.DeltaY == stepY)
                        return true;
            return false;
        }


    }
    public struct Square
    {
        public static Square none = new Square(-1, -1);
        public int x { get; private set; }
        public int y { get; private set; }

        public Square(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool OnBoard()
        {
            return x >= 0 && x < 8 &&
                y >= 0 && y < 8;
        }

        public Square(string e2)
        {
            if (e2.Length == 2 &&
            e2[0] >= 'a' && e2[0] <= 'h' &&
            e2[1] >= '1' && e2[1] <= '8')
            {
                x = e2[0] - 'a';
                y = e2[1] - '1';
            }
            else
                this = none;
        }

        public static bool operator ==(Square a, Square b)
        {
            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(Square a, Square b)
        {
            return !(a == b);
        }

        public static IEnumerable<Square> YieldSquares()
        {
            for (int y = 0; y < 8; y++)
                for (int x = 0; x < 8; x++)
                    yield return new Square(x, y);

        }

        public string Name { get { return ((char)('a' + x)).ToString() + (y + 1).ToString(); } }

        public string PawnEnPassant()
        {
            if(this.y==1)
            return ((char)('a' + x)).ToString() + (3).ToString(); 
            return ((char)('a' + x)).ToString() + (6).ToString();
        }
    }
    public static class Castling
    {
        static public bool isWhiteKingMoves = false;
        static public bool isBlackKingMoves = false;
        static public bool isWhiteRookMovesLeft = false;
        static public bool isWhiteRookMovesRight = false;
        static public bool isBlackRookMovesLeft = false;
        static public bool isBlackRookMovesRight = false;
        static public void Default()
        {
            isWhiteKingMoves = false;
            isBlackKingMoves = false;
            isWhiteRookMovesLeft = false;
            isWhiteRookMovesRight = false;
            isBlackRookMovesLeft = false;
            isBlackRookMovesRight = false;
        }

        static public string FenCastling()
        {
            string temp = "";
            if (!isWhiteKingMoves)
            {
                if (!isWhiteRookMovesRight)
                    temp += "K";

                if (!isWhiteRookMovesLeft)
                    temp += "Q";
            }
            if (!isBlackKingMoves)
            {
                if (!isBlackRookMovesRight)
                    temp += "k";

                if (!isBlackRookMovesLeft)
                    temp += "q";
            }
            if (temp.Length == 0) return "-";
            return temp;
        }


    }
}
