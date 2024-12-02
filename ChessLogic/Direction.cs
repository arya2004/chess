namespace ChessLogic
{
    public class Direction
    {
        public readonly static Direction North = new Direction(-1, 0);
        public readonly static Direction South = new Direction(1, 0);
        public readonly static Direction East = new Direction(0, 1);
        public readonly static Direction West = new Direction(0, -1);
        public readonly static Direction NorthEast = North + East;
        public readonly static Direction NorthWest = North + West;
        public readonly static Direction SouthEast = South+ East;
        public readonly static Direction SouthWest = South+ West;

        public int RowDelta { get; }
        public int ColumnDelta { get;  }
        public Direction(int rowDelta, int colDelta)
        {
            RowDelta = rowDelta;
            ColumnDelta = colDelta;
        }

        public static Direction operator +(Direction d1, Direction d2)
        {
            return new Direction(d1.RowDelta + d2.RowDelta, d1.ColumnDelta + d2.ColumnDelta);
        }
        public static Direction operator *(int scalar, Direction d)
        {
            return new Direction(d.RowDelta * scalar, d.ColumnDelta * scalar);
        }
    }
}
