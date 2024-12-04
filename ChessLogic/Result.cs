namespace ChessLogic
{
    public class Result
    {
        public  Player Winner { get; }
        public EndReason Reason { get; }
        public Result(Player winner, EndReason reason)
        {
            Winner = winner;
            Reason = reason;
        }

        public static Result Win(Player winner) => new Result(winner, EndReason.Checkmate);

        public static Result Draw(EndReason reason) => new Result(Player.None, reason);

    }
}
