using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardSystem
{
    /// <summary>
    /// Adjacents contain whether or not TileControllers adjacent to a specific TileController exist .
    /// </summary>
    public class Adjacents
    {
        public Adjacents(bool north, bool south, bool east, bool west)
        {
            HasNorthTile = north;
            HasSouthTile = south;
            HasEastTile = east;
            HasWestTile = west;
        }

        [SerializeField]
        private bool m_HasNorthTile;
        public bool HasNorthTile { get => m_HasNorthTile; set => m_HasNorthTile = value; }

        [SerializeField]
        private bool m_HasEastTile;
        public bool HasEastTile { get => m_HasEastTile; set => m_HasEastTile = value; }

        [SerializeField]
        private bool m_HasWestTile;
        public bool HasWestTile { get => m_HasWestTile; set => m_HasWestTile = value; }

        [SerializeField]
        private bool m_HasSouthTile;
        public bool HasSouthTile { get => m_HasSouthTile; set => m_HasSouthTile = value; }

        public override string ToString()
        {
            return "North: " + HasNorthTile + ", South: " + HasSouthTile + ", East: " + HasEastTile + ", West: " + HasWestTile;
        }
    }
}
