using UnityEngine;

namespace BoardSystem
{
    public class TileController : MonoBehaviour
    {
        [SerializeField]
        private Tile m_Tile;

        public Tile Tile { get => m_Tile; private set => m_Tile = value; }

        [SerializeField]
        private Vector2Int m_ArrayLocation;

        [SerializeField]
        private bool IsLocationSet = false; // Useful to save this so no redefinition!

        public Vector2Int ArrayLocation
        {
            get => m_ArrayLocation;
            set
            {
                if (!IsLocationSet) // A one-time set!
                {
                    m_ArrayLocation = value;
                    IsLocationSet = true;
                    //Debug.Log("Set successfully!");
                }
                else
                {
                    Debug.Log("ArrayLocation cannot be set more than once!");
                }
            }
        }

        [SerializeField]
        private LayerMask m_BattleFieldLayerMask;

        /// <summary>
        /// Returns the location of the Tile in World Space!
        /// </summary>
        /// <returns>A Vector2Int of the Transform's X and Z Components.</returns>
        public Vector2Int GetTransformLocation()
        {
            Vector3 position = transform.position;
            return new Vector2Int((int)position.x, (int)position.z);
        }

        /// <summary>
        /// Used to change the type of the Tile, updating the Tile's texture and information.
        /// </summary>
        /// <param name="newTile">The desired Tile type.</param>
        public void SetTileType(Tile newTile)
        {
            Tile = newTile;
            // TODO: Redraw Tile accordingly with references to Materials somewhere. Consider a Dictionary<Tile, TileTexture>().
        }

        /// <summary>
        /// Uses a Raycast, targeting only Battlefield-layer colliders (not Tile layer),
        /// returns whatever it hits (or doesn't).
        /// </summary>
        /// <returns>Returns either the GameObject it hit, or null.</returns>
        public GameObject GetGameObjectOn()
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, m_BattleFieldLayerMask))
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