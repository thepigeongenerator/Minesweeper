using UnityEngine;

namespace Minesweeper
{
    public class MonoLevel : MonoBehaviour
    {
        [SerializeField] private int levelSizeX = 0;
        [SerializeField] private int levelSizeY = 0;
        private TileState[,] tiles = null;

        private void Awake()
        {
            if (levelSizeX <= 0) throw new System.ArgumentOutOfRangeException(nameof(levelSizeX), $"{nameof(levelSizeX)} may not be equal to or less than 0");
            if (levelSizeY <= 0) throw new System.ArgumentOutOfRangeException(nameof(levelSizeY), $"{nameof(levelSizeY)} may not be equal to or less than 0");

            tiles = new TileState[levelSizeX, levelSizeY]; // numeric array; all values are set to 0
        }

    }
}