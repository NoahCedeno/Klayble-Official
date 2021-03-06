﻿using System;
using System.Collections;
using UnityEngine;

namespace BoardSystem
{
    public class BoardManager : MonoBehaviour
    {
        private Vector2Int m_RootOffsetToOrigin = new Vector2Int();
        private int m_Rows, m_Cols;
        private TileController[,] m_TileMap;

        private void Awake()
        {
            m_RootOffsetToOrigin = new Vector2Int((int)transform.position.x, (int)transform.position.z);
            CalculateTileMapBounds();
            DefineTileMap();
            DefineAdjacents();
        }

        /// <summary>
        /// Finds and uses local Tile extrema to define the bounds of the TileMap array.
        /// As well, this function defines a few other helpful fields of my Board.
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
                Vector2Int currCoords = new Vector2Int((int)current.localPosition.x, (int)current.localPosition.z);

                // Find Extrema on X
                highestLocalX = (currCoords.x > highestLocalX) ? currCoords.x : highestLocalX;
                lowestLocalX = (currCoords.x < lowestLocalX) ? currCoords.x : lowestLocalX;

                // Find Extrema on Z
                highestLocalZ = (currCoords.y > highestLocalZ) ? currCoords.y : highestLocalZ;
                lowestLocalZ = (currCoords.y < lowestLocalZ) ? currCoords.y : lowestLocalZ;
            }

            // Define RootOffsetToOrigin
            m_RootOffsetToOrigin.x = lowestLocalX;
            m_RootOffsetToOrigin.y = highestLocalZ;

            // Process extrema as positive numbers for array bounds, accounting for 0!
            m_Cols = Mathf.Abs(lowestLocalX) + Mathf.Abs(highestLocalX) + ((lowestLocalX < 0 && highestLocalX > 0) ? 1 : 0);
            m_Rows = Mathf.Abs(lowestLocalZ) + Mathf.Abs(highestLocalZ) + ((lowestLocalZ < 0 && highestLocalZ > 0) ? 1 : 0);

            m_TileMap = new TileController[m_Cols, m_Rows]; // TODO: Investigate why subtracting 1 from each generates Index Error!

            // Debug.Log("NumCols: " + NumCols);
            // Debug.Log("NumRows: " + NumRows);
            // Debug.Log(RootOffsetToOrigin);
        }

        /// <summary>
        /// Defines our TileMap array with the TileScripts on the field by finding and utilising
        /// vectors to the parent's origin, to the array/global origin.
        /// </summary>
        private void DefineTileMap()
        { 
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform current = transform.GetChild(i);
                Vector2Int currCoords = new Vector2Int((int)current.localPosition.x, (int)current.localPosition.z);

                Vector2Int currToOrigin = new Vector2Int(-currCoords.x, -currCoords.y);
                currToOrigin += m_RootOffsetToOrigin;

                // Debug.Log(current.transform.gameObject.name + ": " + Mathf.Abs(currToOrigin.x) + ", " + Mathf.Abs(currToOrigin.y));

                // Defines our TileMap array with the GameObject's TileScript
                m_TileMap[Mathf.Abs(currToOrigin.x), Mathf.Abs(currToOrigin.y)] = current.gameObject.GetComponent<TileController>();
                // Defines the Vector2 of the coordinates in the board, within the TileScript.
                m_TileMap[Mathf.Abs(currToOrigin.x), Mathf.Abs(currToOrigin.y)].ArrayLocation = new Vector2Int(Mathf.Abs(currToOrigin.x), Mathf.Abs(currToOrigin.y));
            }
        }

        /// <summary>
        /// Defines the Adjacent component of each TileController in the m_TileMap!
        /// </summary>
        private void DefineAdjacents()
        {
            TileController current;
            bool hasNorth;
            bool hasEast;
            bool hasSouth;
            bool hasWest;

            for (int i = 0; i < m_TileMap.GetLength(0); i++)
            {
                for (int j = 0; j < m_TileMap.GetLength(1); j++)
                {
                    current = GetTileAt(i, j);

                    if (current != null)
                    {
                        // East-West Checking
                        hasWest = (i - 1 >= 0 && m_TileMap[i - 1, j] != null);
                        hasEast = (i + 1 <= m_TileMap.GetLength(0) - 1 && m_TileMap[i + 1, j] != null);

                        // North-South Checking
                        hasNorth = (j - 1 >= 0 && m_TileMap[i, j - 1] != null);
                        hasSouth = (j + 1 <= m_TileMap.GetLength(1) - 1 && m_TileMap[i, j + 1] != null);

                        m_TileMap[i, j].Adjacents = new Adjacents(hasNorth, hasSouth, hasEast, hasWest);
                    }
                }
            }
        }

        /// <summary>
        /// Returns a TileScript or null for any two coordinates within the TileMap array.
        /// STARTS AT 0, and accounts for IndexOutOfRangeExceptions.
        /// </summary>
        /// <param name="col">The column index of the Tile requested.</param>
        /// <param name="row">The row index of the Tile requested.</param>
        /// <returns></returns>
        public TileController GetTileAt(int col, int row)
        {
            try
            {
                return m_TileMap[col, row];
            }
            catch (IndexOutOfRangeException) // TODO: Consider keeping exception reference for debug testing, etc?
            {
                Debug.Log("Indices " + col + ", " + row + " are invalid.");
                return null;
            }
            catch (NullReferenceException)
            {
                Debug.Log("Indices " + col + ", " + row + " store no value.");
                return null;
            }
        }

        public void SetTileTypeAt(int col, int row, Tile newTile)
        {
            GetTileAt(col, row).SetTileType(newTile);
        }


    }
}