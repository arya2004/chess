﻿using ChessLogic.Moves;

namespace ChessLogic.Pieces
{
    public class King(Player color) : Piece
    {
        public override PieceType Type => PieceType.King;

        public override Player Color { get; } = color;

        public static readonly Direction[] dirs =
        [
            Direction.North,
            Direction.East,
            Direction.South,
            Direction.West,
            Direction.NorthWest,
            Direction.NorthEast,
            Direction.SouthEast,
            Direction.SouthWest
        ];

        public override Piece Copy()
        {
            King copy = new(Color)
            {
                HasMoved = HasMoved
            };
            return copy;
        }

        private IEnumerable<Position> MovePositions(Position from, Board board)
        {
            foreach(Direction dir in dirs)
            {
                Position to = from + dir;
                if (!Board.IsInside(to))
                {
                    continue;
                }
                if(board.IsEmpty(to) || board[to].Color != Color)
                {
                    yield return to;
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            foreach(Position to in MovePositions(from, board))
            {
                yield return new NormalMove(from, to);
            }
            if(CanCastleKingSide(from, board))
            {
                yield return new Castle(MoveType.CastleKingSide, from);
            }
            if(CanCastleQUeenSide(from, board))
            {
                yield return new Castle(MoveType.CastleQueenSide, from);
            }
        }

        public override bool CanCaptureOpponentKing(Position from, Board board)
        {
            return MovePositions(from, board).Any(to =>
            {
                Piece p = board[to];
                return p != null && p.Type == PieceType.King;
            });
        }

        private static bool AllEmpty(IEnumerable<Position> positions, Board board)
        {
            return positions.All(pos => board.IsEmpty(pos));
        }

        private bool CanCastleKingSide(Position from, Board board)
        {
            if (HasMoved)
            {
                return false;
            }
            Position rookPos = new Position(from.Row, 7);
            Position[] betweenPosition = [new(from.Row, 5), new(from.Row, 6)];

            return IsUnmovedRook(rookPos, board) && AllEmpty(betweenPosition, board);
        }
        private bool CanCastleQUeenSide(Position from, Board board)
        {
            if (HasMoved)
            {
                return false;
            }
            Position rookPos = new Position(from.Row, 0);
            Position[] betweenPosition = [new(from.Row, 1), new(from.Row, 2), new(from.Row, 3)];

            return IsUnmovedRook(rookPos, board) && AllEmpty(betweenPosition, board);
        }


        private static bool IsUnmovedRook(Position pos, Board board)
        {
            if (board.IsEmpty(pos))
            {
                return false;
            }
            Piece piece = board[pos];
            return piece.Type == PieceType.Rook && !piece.HasMoved;
        }
    }
}
