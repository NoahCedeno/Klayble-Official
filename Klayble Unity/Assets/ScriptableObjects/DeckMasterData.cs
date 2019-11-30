using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DeckMasterData", menuName = "ScriptableObjects/DeckMasterData", order = 2)]
public class DeckMasterData : ScriptableObject
{
	public int DeckMasterID;
	public int Level;
	public int HP;
	public int Atk;
	public int Def;

	public string Name;

	public List<CardData> Deck;
}
