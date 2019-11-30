namespace BattlePieceSystem
{
	/// <summary>
	/// BattleCards are containers for the base data of a CardData ScriptableObject which
	/// inherit TileMapPosition and other fields to make them battle-ready.
	/// </summary>
	public class BattleCard : BattleAvatar
	{
		public int CardID;
		public CardData SOData;

		private void Awake()
		{
			{
				HP = SOData.HP;
				Atk = SOData.Atk;
				Def = SOData.Def;
				Level = SOData.Level;
				CardID = SOData.CardID;
				Name = SOData.Name;
			}
		}
	}
}
