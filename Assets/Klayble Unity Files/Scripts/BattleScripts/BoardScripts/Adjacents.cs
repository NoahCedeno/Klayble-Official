using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardSystem
{
    public struct Adjacents
    {
        [SerializeField]
        private TileController m_NorthTile;
        public TileController NorthTile { get => m_NorthTile; private set => m_NorthTile = value; }

        [SerializeField]
        private TileController m_EastTile;
        public TileController EastTile { get => m_EastTile; private set => m_EastTile = value; }

        [SerializeField]
        private TileController m_WestTile;
        public TileController WestTile { get => m_WestTile; private set => m_WestTile = value; }

        [SerializeField]
        private TileController m_SouthTile;
        public TileController SouthTile { get => m_SouthTile; private set => m_SouthTile = value; }
    }
}
