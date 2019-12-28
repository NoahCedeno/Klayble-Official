using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattlePieceSystem
{
    public abstract class BattlePiece
    {
        [SerializeField]
        protected Vector2Int m_BoardPosition;
        public Vector2Int BoardPosition { get => m_BoardPosition; private set => m_BoardPosition = value; }

        [SerializeField]
        protected string m_Name;
        public string Name { get => m_Name; private set => m_Name = value; }
    }
}
