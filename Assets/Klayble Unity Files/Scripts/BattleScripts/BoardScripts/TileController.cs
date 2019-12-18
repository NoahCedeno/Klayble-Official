using UnityEngine;

namespace BoardSystem
{
    public class TileController : MonoBehaviour
    {
        [SerializeField]
        private Tile m_Tile;
        public Tile Tile { get => m_Tile; private set => m_Tile = value; }

        [SerializeField]
        private bool IsLocationSet = false; // Useful to save this so no redefinition!

        [SerializeField]
        private Vector2Int m_ArrayLocation;

        [SerializeField]
        private BoxCollider OnTileCollider;

        [SerializeField] // Not sure if I save this
        private GameObject ObjectOn;

        private void Awake()
        {
            OnTileCollider = gameObject.GetComponent<BoxCollider>();
        }

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
        /// <returns>A Vector2Int of the Transform's X and Z Components in World Space.</returns>
        public Vector2Int GetTransformLocation()
        {
            Vector3 position = transform.position;
            return new Vector2Int((int) position.x, (int) position.z);
        }

        /// <summary>
        /// Returns the location of the Tile in Local Space, relative to the Board.
        /// </summary>
        /// <returns>A Vector2Int of the Transform's X and Z Components in Local Space.</returns>
        public Vector2Int GetLocalPosition()
        {
            Vector3 localPosition = transform.localPosition;
            return new Vector2Int((int) localPosition.x, (int) localPosition.z);
        }

        /// <summary>
        /// Returns the location of the Tile in the array.
        /// </summary>
        /// <returns>A Vector2Int of the Array's Location.</returns>
        public Vector2Int GetArrayLocation() {
            return ArrayLocation;
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

        //****************| GameObject Checking |****************

        /// <summary>
        /// Defines ObjectOn when a GameObject enters the Tile's Collider.
        /// </summary>
        /// <param name="objectOnCollider">The Collider of the object on the Tile.</param>
        private void OnTriggerEnter(Collider objectOnCollider)
        {
            ObjectOn = objectOnCollider.gameObject;
            Debug.Log("Object " + ObjectOn.name + " entered " + gameObject.name + "!");
        }

        private void OnTriggerExit(Collider other)
        {
            ObjectOn = null;
            Debug.Log("Object has LEFT " + gameObject.name + "!");
        }

        /// <summary>
        /// Uses our trigger Collider to find whatever GameObject is on this Tile.
        /// </summary>
        /// <returns>Returns either the GameObject within the Tile's collider.</returns>
        public GameObject GetGameObjectOn()
        {
            return ObjectOn;
        }

        /// <summary>
        /// Simply returns IF a GameObject is on the Tile or not.
        /// </summary>
        /// <returns>If the result of GetGameObjectOn() is not null </return>
        public bool IsGameObjectOn() {
            return GetGameObjectOn() != null;
        }
    }
}
