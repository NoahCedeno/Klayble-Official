using UnityEngine;

namespace BattlePieceSystem
{
    /// <summary>
    /// Represents any piece on the battlefield/board via abstraction.
    /// </summary>
    public abstract class BattlePiece : MonoBehaviour
    {
        [SerializeField]
        protected Vector2Int m_BoardPosition;

        public Vector2Int BoardPosition { get => m_BoardPosition; private set => m_BoardPosition = value; }

        [SerializeField]
        protected string m_PieceName;

        public string PieceName { get => m_PieceName; private set => m_PieceName = value; }

        // TODO: Should hold Model reference!

        //+++++++++++| Event Listeners |+++++++++++
    }
}