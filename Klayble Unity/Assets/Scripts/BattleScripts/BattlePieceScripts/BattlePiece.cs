using UnityEngine;

namespace BattlePieceSystem
{
	/// <summary>
	/// The top of the hierarchy, BattlePieces represent objects on the battlefield.
	/// Relevant fields include Level, TileMapPosition, and Name;
	/// </summary>
	public abstract class BattlePiece : MonoBehaviour
	{
		[SerializeField]
		private int m_Level;
		public int Level { get => m_Level; protected set => m_Level = value; }

		[SerializeField]
		private Vector2 m_TileMapPosition;
		public Vector2 TileMapPosition { get => m_TileMapPosition; private set => m_TileMapPosition = value; }

		[SerializeField]
		private string m_PieceName;
		public string PieceName { get => m_PieceName; protected set => m_PieceName = value; }
	}
}
