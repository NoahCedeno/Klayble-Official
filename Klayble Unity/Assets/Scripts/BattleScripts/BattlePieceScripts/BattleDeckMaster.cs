using System.Collections.Generic;

namespace BattlePieceSystem
{
	/// <summary>
	/// Contains the relevant and battle-ready information for the BattleDeckmaster, which could
	/// represent the player or another AI/Story Deckmaster.
	/// </summary>
	public class BattleDeckMaster : BattleAvatar
	{
		public List<BattleCard> Deck;
		public int DeckMasterID;
		public DeckMasterData DMData;

		private void Awake()
		{
			{
				HP = DMData.HP;
				Atk = DMData.Atk;
				Def = DMData.Def;
				Level = DMData.Level;
				Name = DMData.Name;
				DeckMasterID = DMData.DeckMasterID;
			}
		}
	}
}
