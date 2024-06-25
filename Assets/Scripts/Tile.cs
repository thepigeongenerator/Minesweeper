namespace Minesweeper
{
    public enum Tile : byte
    {
        // 0-8 contains the amount of bombs surounding the tile
        CONTAINS_BOMB = 16,
        FLAGGED = 32,
        OPENED = 64,
        // bit 7 (128) is still free
    }
}