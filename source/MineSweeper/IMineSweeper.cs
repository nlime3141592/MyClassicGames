namespace MyClassicGame
{
    public interface IMineSweeper
    {
        void OnClickFlusher(int width, int height, int mines);
        void OnClickCell(int x, int y);
        void OnCheck(int x, int y);
        void PrintBoard(GameMode mode);
    }
}