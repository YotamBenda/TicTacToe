public interface IGameManager
{
    int CheckForHint(bool shouldShow);
    bool CheckIfGameEnded();
    bool CheckIfPlayerVSComputer();
    void NextTurn();
    void UndoLastMoves();
}