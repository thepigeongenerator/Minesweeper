using Minesweeper.Util;
using UnityEngine;

namespace Minesweeper.Data
{
    public struct Spritesheet
    {
        public readonly Sprite[] sprites;

        public Spritesheet(Texture2D spritesheet, int spriteSize)
        {
            Readonly<int> spritesX = new(spritesheet.width / spriteSize);
            Readonly<int> spritesY = new(spritesheet.height / spriteSize);
            sprites = new Sprite[spritesX.value * spritesY.value];

            // initialize the sprites (using transformed positions to make sure the sprite indeces are as expected)
            int i = 0;
            for (int y = spritesY.value - 1; y >= 0; y--)
            {
                for (int x = 0; x < spritesX.value; x++)
                {
                    Rect mask = new(x * spriteSize, y * spriteSize, spriteSize, spriteSize);
                    sprites[i] = Sprite.Create(spritesheet, mask, Vector2.zero, spriteSize);
                    i++;
                }
            }
        }
    }
}