using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DeckMasterData", menuName = "ScriptableObjects/DeckMasterData", order = 2)]
public class DeckMasterData : ScriptableObject
{
	[SerializeField]
	private int m_DeckMasterId;
	public int DeckMasterId { get => m_DeckMasterId; private set => m_DeckMasterId = value; }

	[SerializeField]
	private int m_Level;
	public int Level { get => m_Level; private set => m_Level = value; }

	[SerializeField]
	private BattleStats m_BattleStats;
	public BattleStats BattleStats { get => m_BattleStats; private set => m_BattleStats = value; }

	[SerializeField]
	private List<CardData> m_Deck;
	public List<CardData> Deck { get => new List<CardData>(m_Deck); private set => m_Deck = value; }
}
