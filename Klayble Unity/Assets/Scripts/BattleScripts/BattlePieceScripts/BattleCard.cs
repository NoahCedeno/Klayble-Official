using UnityEngine;

namespace BattlePieceSystem
{
	/// <summary>
	/// BattleCards are containers for the base data of a CardData ScriptableObject which
	/// inherit TileMapPosition and other fields to make them battle-ready.
	/// </summary>
	public class BattleCard : BattleAvatar
	{
		[SerializeField]
		private int m_CardId;
		public int CardId { get => m_CardId; private set => m_CardId = value; }

		[SerializeField]
		private CardData m_CardData;
		public CardData CardData { get => m_CardData; private set => m_CardData = value; }

		private void Awake()
		{
			{
				HitPoints = CardData.HitPoints;
				Attack = CardData.Attack;
				Defense = CardData.Defense;
				Level = CardData.Level;
				CardId = CardData.CardId;
				PieceName = CardData.CardName;
			}
		}
	}
}
