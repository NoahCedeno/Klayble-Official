namespace BoardSystem
{
	/// <summary>
	/// Represents all the variants a Tile can have!
	/// Useful in drawing unique tile palettes with variance from level to level,
	/// instead of having all sorts of generic Tile textures.
	/// </summary>
	public enum Tile
	{
		Normal = 0,
		Lava = 1,
		Water = 2,
		Poison = 3
	}
}
