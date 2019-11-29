using UnityEngine;

namespace BattlePieceSystem
{
    /// <summary>
    /// The top of the hierarchy, BattlePieces represent objects on the battlefield.
    /// Relevant fields include Level, TileMapPosition, and Name;
    /// </summary>
    public abstract class BattlePiece : MonoBehaviour
    {
        public int Level;
        public Vector2 TileMapPosition;
        public string Name;
    }
}