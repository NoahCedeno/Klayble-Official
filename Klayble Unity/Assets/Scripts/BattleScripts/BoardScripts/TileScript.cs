using UnityEngine;

namespace BoardSystem
{
    public class TileScript : MonoBehaviour
    {
        [SerializeField]
        private TileTypes TileType; // May become an enumerated TileType at some point.

        /// <summary>
        /// Returns the location of the Tile within the Board!
        /// </summary>
        /// <returns>A Vector2 of the Transform's X and Z Components.</returns>
        public Vector2 GetLocation()
        {
            return new Vector2((int)transform.position.x, (int)transform.position.z);
        }

        /// <summary>
        /// Used in checking and applying status effects on the Board.
        /// May return an enumerated Type.
        /// </summary>
        /// <returns>A String of the TileType.</returns>
        public TileTypes GetTileType()
        {
            return TileType;
        }

        /// <summary>
        /// Used to change the type of the Tile, updating the Tile's texture and information.
        /// </summary>
        /// <param name="NewTileType">The desired Tile type.</param>
        public void SetTileType(TileTypes NewTileType)
        {
            TileType = NewTileType;
            // TODO: Redraw Tile accordingly with references to Materials somewhere
        }

        /// <summary>
        /// Uses a Raycast, targeting only Battlefield-layer colliders (not Tile layer),
        /// returns whatever it hits (or doesn't).
        /// </summary>
        /// <returns>Returns either the GameObject it hit, or null.</returns>
        public GameObject GetGameObjectOn()
        {
            int battlefieldLayer = 1 << 9;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, battlefieldLayer))
            {
                // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
                return hit.collider.gameObject;
            }
            else
            {
                return null;
            }
        }
    }
}