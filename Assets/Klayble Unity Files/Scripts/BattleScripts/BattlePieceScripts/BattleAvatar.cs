using UnityEngine;

namespace BattlePieceSystem
{
	/// <summary>
	/// BattleAvatars represent characters on the field, being Cards, Deckmasters, or other possible fellas.
	/// They have HP, Atk, Def, Level, TileMapPosition, and Names.
	/// </summary>
	public abstract class BattleAvatar : BattlePiece
	{
		[SerializeField]
		private int m_HitPoints;
		public int HitPoints { get => m_HitPoints; protected set => m_HitPoints = value; }

		[SerializeField]
		private int m_Attack;
		public int Attack { get => m_Attack; protected set => m_Attack = value; }

		[SerializeField]
		private int m_Defense;
		public int Defense { get => m_Defense; protected set => m_Defense = value; }
	}
}
