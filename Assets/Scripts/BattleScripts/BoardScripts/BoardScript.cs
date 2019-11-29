using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardSystem
{
    public class BoardScript : MonoBehaviour
    {
        List<GameObject> UnsortedChildren = new List<GameObject>(); // May be redundant
        Vector2Int RootTransformOffset = new Vector2Int();

        int NumRows, NumCols;
        TileScript[,] TileMap;

        private void Awake()
        {
            RootTransformOffset = new Vector2Int((int)transform.position.x, (int)transform.position.z);
            SetupBoard();
        }

        private void SetupBoard()
        {
            CalculateTileMapBounds();
            DefineTileMap();
        }

        /// <summary>
        /// Finds and uses local Tile extrema to define the bounds of the TileMap array.
        /// </summary>
        private void CalculateTileMapBounds()
        {
            int lowestLocalX = 0;
            int highestLocalX = 0;
            int lowestLocalZ = 0;
            int highestLocalZ = 0;

            // For each child, check for local extrema
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform current = transform.GetChild(i);
                Vector2Int currCoords = new Vector2Int((int)current.localPosition.x, (int)current.localPosition.y);

                // Find Extrema on X
                highestLocalX = (currCoords.x > highestLocalX) ? currCoords.x : highestLocalX;
                lowestLocalX = (currCoords.x < lowestLocalX) ? currCoords.x : lowestLocalX;

                // Find Extrema on Z
                highestLocalZ = (currCoords.y > highestLocalZ) ? currCoords.y : highestLocalZ;
                lowestLocalZ = (currCoords.y < lowestLocalZ) ? currCoords.y : lowestLocalZ;

            }

            // Process extrema as positive numbers for array bounds
            NumRows = Mathf.Abs(lowestLocalX) + Mathf.Abs(highestLocalX);
            NumCols = Mathf.Abs(lowestLocalZ) + Mathf.Abs(highestLocalZ);

            TileMap = new TileScript[NumRows - 1, NumCols - 1];
        }

        /// <summary>
        /// Defines our TileMap array with the TileScripts that 
        /// </summary>
        private void DefineTileMap()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform current = transform.GetChild(i);
                Vector2Int currCoords = new Vector2Int((int)current.localPosition.x, (int)current.localPosition.y);

                // Set the indices per Tile, not per index. Will need to check this math.
                // This math should define the appropriate TileScript for the TileMap by using indices within the TileMap array
                // that are 'normalized' or shifted by a local factor in relation to the root transform.
                TileMap[Mathf.Abs(currCoords.x + RootTransformOffset.x),
                        Mathf.Abs(currCoords.y + RootTransformOffset.y)] = current.gameObject.GetComponent<TileScript>();
            }

        }




    }
}