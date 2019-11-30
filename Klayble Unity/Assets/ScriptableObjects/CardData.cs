using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData", order = 1)]
public class CardData : ScriptableObject
{
	public int CardID;
	public int Level;
	public int HP;
	public int Atk;
	public int Def;

	public string Name;
}
