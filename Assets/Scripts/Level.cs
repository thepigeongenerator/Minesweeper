using UnityEngine;

namespace Minesweeper
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private int levelSizeX = 0;
        [SerializeField] private int levelSizeY = 0;
        private Tile[,] tiles = null;

        private void Awake()
        {
            if (levelSizeX <= 0) throw new System.ArgumentOutOfRangeException(nameof(levelSizeX), $"{nameof(levelSizeX)} may not be equal to or less than 0");
            if (levelSizeY <= 0) throw new System.ArgumentOutOfRangeException(nameof(levelSizeY), $"{nameof(levelSizeY)} may not be equal to or less than 0");

            tiles = new Tile[levelSizeX, levelSizeY]; // numeric array; all values are set to 0
        }

        private void Start() {}
    }
}