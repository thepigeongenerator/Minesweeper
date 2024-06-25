using System.Runtime.CompilerServices;
using UnityEngine;

namespace Minesweeper
{
    public class MonoLevel : MonoBehaviour
    {
        // level data
        [SerializeField] private int levelSizeX = 0;
        [SerializeField] private int levelSizeY = 0;

        // sprite data
        [SerializeField] private Texture2D spritesheet = null;
        [SerializeField] private int spriteSizeX = 0;
        [SerializeField] private int spriteSizeY = 0;

        private TileState[,] tiles = null;
        private Sprite[] sprites;


        private void Awake()
        {
            IsLessThenOrEqualTo(levelSizeX, 0, nameof(levelSizeX));
            IsLessThenOrEqualTo(levelSizeY, 0, nameof(levelSizeY));
            IsLessThenOrEqualTo(spriteSizeX, 0, nameof(spriteSizeX));
            IsLessThenOrEqualTo(spriteSizeY, 0, nameof(spriteSizeY));

            tiles = new TileState[levelSizeX, levelSizeY]; // numeric array; all values are set to 0

            Readonly<int> spritesX = new(spritesheet.width / spriteSizeX);
            Readonly<int> spritesY = new(spritesheet.height / spriteSizeY);
            sprites = new Sprite[spritesX.value * spritesY.value];

            // initialize the sprites
            int i = 0;
            for (int x = 0; x < spritesX.value; x++)
            {
                for (int y = 0; y < spritesY.value; y++)
                {
                    Rect mask = new(x * spriteSizeX, y * spriteSizeY, spriteSizeX, spriteSizeY);
                    sprites[i] = Sprite.Create(spritesheet, mask, new Vector2(0.5F, 0.5F), spriteSizeX);
                    i++;
                }
            }
        }

        // throws ArgumentOutOfRangeException if a is less than or equal to b
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void IsLessThenOrEqualTo(int a, int b, string variableName)
        {
            if (a <= b)
            {
                throw new System.ArgumentOutOfRangeException(variableName, $"{variableName} mustn't be equal or less than {b}");
            }
        }
    }
}