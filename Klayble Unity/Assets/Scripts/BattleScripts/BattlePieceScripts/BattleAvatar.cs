namespace BattlePieceSystem
{
	/// <summary>
	/// BattleAvatars represent characters on the field, being Cards, Deckmasters, or other possible fellas.
	/// They have HP, Atk, Def, Level, TileMapPosition, and Names.
	/// </summary>
	public abstract class BattleAvatar : BattlePiece
	{
		public int HP, Atk, Def;
	}
}
