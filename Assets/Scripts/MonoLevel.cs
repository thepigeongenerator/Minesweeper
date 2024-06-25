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
        [SerializeField] private int spriteSize = 0;

        private TileState[] tiles = null;
        private Sprite[] sprites;


        public void SetTile(string tileName) {
            int index = int.Parse(tileName);
            throw new System.NotImplementedException();
        }

        private void Awake()
        {
            IsLessThenOrEqualTo(levelSizeX, 0, nameof(levelSizeX));
            IsLessThenOrEqualTo(levelSizeY, 0, nameof(levelSizeY));
            IsLessThenOrEqualTo(spriteSize, 0, nameof(spriteSize));

            tiles = new TileState[levelSizeX * levelSizeY]; // numeric array; all values are set to 0

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

            // initialize the level
            for (int x = 0; x < levelSizeX; x++)
            {
                for (int y = 0; y < levelSizeY; y++)
                {
                    // create a new gameobject
                    GameObject tile = new(((x * levelSizeX) + y).ToString(), typeof(SpriteRenderer), typeof(BoxCollider2D));
                    tile.transform.position = new Vector3(x, y, 0.0F);
                    tile.transform.parent = transform;

                    // initialize the spriterenderer
                    var spriteRenderer = tile.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = sprites[4];

                    // initialize the collider
                    var collider = tile.GetComponent<BoxCollider2D>();
                    collider.size = Vector2.one;
                    collider.offset = new Vector2(0.5F, 0.5F);
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