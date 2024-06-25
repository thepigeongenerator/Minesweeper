using UnityEngine;

namespace Minesweeper.Unity
{
    public class MonoInput : MonoBehaviour
    {
        private MonoLevel level;

        // get the level
        private void Awake()
        {
            level = GetComponent<MonoLevel>();
        }

        // call Raycast() whenver the user clicks their mouse
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }

        // fires a raycast at the mouse position, if it hits a tile, that is told to MonoLevel
        private void Raycast(Vector3 mousePosition)
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                level.SetTile(hit.collider.name);
            }
        }
    }
}