using System.Collections.Generic;
using UnityEngine;

namespace BattlePieceSystem
{
	/// <summary>
	/// Contains the relevant and battle-ready information for the BattleDeckmaster, which could
	/// represent the player or another AI/Story Deckmaster.
	/// </summary>
	public class BattleDeckMaster : BattleAvatar
	{
		[SerializeField]
		private List<BattleCard> m_Deck;
		public List<BattleCard> Deck { get => new List<BattleCard>(m_Deck); private set => m_Deck = value; }

		[SerializeField]
		private int m_DeckMasterId;
		public int DeckMasterId { get => m_DeckMasterId; private set => m_DeckMasterId = value; }

		[SerializeField]
		private DeckMasterData m_DeckMasterData;
		public DeckMasterData DeckMasterData { get => m_DeckMasterData; private set => m_DeckMasterData = value; }

		private void Awake()
		{
			{
				HitPoints = DeckMasterData.HitPoints;
				Attack = DeckMasterData.Attack;
				Defense = DeckMasterData.Defense;
				Level = DeckMasterData.Level;
				PieceName = DeckMasterData.DeckName;
				DeckMasterId = DeckMasterData.DeckMasterId;
			}
		}
	}
}
