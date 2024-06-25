using Minesweeper.Util;
using Minesweeper.Data;
using UnityEngine;

namespace Minesweeper.Unity
{
    public class MonoLevel : MonoBehaviour
    {
        // level data
        [SerializeField] private int levelSizeX = 0;
        [SerializeField] private int levelSizeY = 0;

        // sprite data
        [SerializeField] private Texture2D spritesheetTexture = null;
        [SerializeField] private int spriteSize = 0;

        private TileState[] tiles = null;
        private Spritesheet spritesheet;


        public void SetTile(string tileName)
        {
            int index = int.Parse(tileName);
            throw new System.NotImplementedException();
        }

        private void Awake()
        {
            Checker.IsLessThenOrEqualTo(levelSizeX, 0, nameof(levelSizeX));
            Checker.IsLessThenOrEqualTo(levelSizeY, 0, nameof(levelSizeY));
            Checker.IsLessThenOrEqualTo(spriteSize, 0, nameof(spriteSize));

            tiles = new TileState[levelSizeX * levelSizeY]; // numeric array; all values are set to 0
            spritesheet = new Spritesheet(spritesheetTexture, spriteSize);

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
                    spriteRenderer.sprite = spritesheet.sprites[4];

                    // initialize the collider
                    var collider = tile.GetComponent<BoxCollider2D>();
                    collider.size = Vector2.one;
                    collider.offset = new Vector2(0.5F, 0.5F);
                }
            }
        }
    }
}