using ChessLogic.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Board
    {
        private readonly Piece[,] pieces = new Piece[8, 8];
        private readonly Dictionary<Player, Position> pawnSkipPosition = new()
        { 
               {Player.White, null}, {Player.Black, null},
        };
        public Piece this[int row, int col]
        {
            get => pieces[row, col];
            set => pieces[row, col] = value;
        }

        public Piece this[Position position]
        {
            get => this[position.Row, position.Column];
            set => this[position.Row, position.Column] = value;
        }

        public Position GetPawnSkipPosition(Player player)
        {
            return pawnSkipPosition[player];
        }

        public void SetPawnSkipPosition(Player player, Position pos)
        {
            pawnSkipPosition[player] = pos;
        }




        public static Board Initial()
        {
            Board board = new();
            board.AddStartPieces();
            return board;
        }

        private void AddStartPieces()
        {
            this[0, 0] = new Rook(Player.Black);
            this[0, 1] = new Knight(Player.Black);
            this[0, 2] = new Bishop(Player.Black);
            this[0, 3] = new Queen(Player.Black);
            this[0, 4] = new King(Player.Black);
            this[0, 5] = new Bishop(Player.Black);
            this[0, 6] = new Knight(Player.Black);
            this[0, 7] = new Rook(Player.Black);

            this[7, 0] = new Rook(Player.White);
            this[7, 1] = new Knight(Player.White);
            this[7, 2] = new Bishop(Player.White);
            this[7, 3] = new Queen(Player.White);
            this[7, 4] = new King(Player.White);
            this[7, 5] = new Bishop(Player.White);
            this[7, 6] = new Knight(Player.White);
            this[7, 7] = new Rook(Player.White);

            for (int c = 0; c < 8; c++)
            {
                this[1, c] = new Pawn(Player.Black);
                this[6, c] = new Pawn(Player.White);
            }
        }

        public static bool IsInside(Position position) => position.Row >= 0 && position.Row < 8 && position.Column >= 0 && position.Column < 8;
        public bool IsEmpty(Position position) => this[position] == null;

        public IEnumerable<Position> PiecePosition()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Position pos = new Position(i, j);
                    if (!IsEmpty(pos))
                    {
                        yield return pos;
                    }
                }
            }
        }

        public IEnumerable<Position> PiecePositionsFor(Player player) => PiecePosition().Where(pos => this[pos].Color == player);

        public bool IsInCheck(Player player) => PiecePositionsFor(player.Opponent()).Any(pos =>
        {
            Piece p = this[pos];
            return p.CanCaptureOpponentKing(pos, this);
        });

        public Board CopyBoard()
        {
            Board copy = new Board();
            foreach (Position pos in PiecePosition())
            {
                copy[pos] = this[pos].Copy();
            }
            return copy;
        }


        public Counting CountPieces()
        {
            Counting counting = new Counting();
            foreach(Position pos in PiecePosition())
            {
                Piece piece = this[pos];
                counting.Increment(piece.Color, piece.Type);
            }
            return counting;
        }

        public bool InsufficientMaterial()
        {
            Counting counting =  CountPieces();


            return IsKingVsKing(counting) || IsKingBishopVsKing(counting) || IsKingKNightVsKing(counting) || IsKingBishopVsKingBishop(counting);
        }

        private static bool IsKingVsKing(Counting counting) => counting.TotalCount == 2;

        private static bool IsKingBishopVsKing(Counting counting)
        {
            return counting.TotalCount == 3 && (counting.White(PieceType.Bishop) == 1 || counting.Black(PieceType.Bishop) == 1);
        }

        private static bool IsKingKNightVsKing(Counting counting)
        {
            return counting.TotalCount == 3 && (counting.White(PieceType.Knight) == 1 || counting.Black(PieceType.Knight) == 1);
        }

        private  bool IsKingBishopVsKingBishop(Counting counting)
        {
            if (counting.TotalCount != 4)
                return false;
            
            if (counting.White(PieceType.Bishop) != 1 || counting.Black(PieceType.Bishop) != 1)
                return false;

            Position whiteBishop = FindPiece(Player.White, PieceType.Bishop);
            Position blackBishop = FindPiece(Player.Black, PieceType.Bishop);

            return whiteBishop.SquareColor() == blackBishop.SquareColor();


        }

        private Position FindPiece(Player color, PieceType type) => PiecePositionsFor(color).First(pos => this[pos].Type == type);
        

    }
}
