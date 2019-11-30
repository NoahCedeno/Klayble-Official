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
	private int m_HitPoints;
	public int HitPoints { get => m_HitPoints; private set => m_HitPoints = value; }

	[SerializeField]
	private int m_Attack;
	public int Attack { get => m_Attack; private set => m_Attack = value; }

	[SerializeField]
	private int m_Defense;
	public int Defense { get => m_Defense; private set => m_Defense = value; }

	[SerializeField]
	private string m_DeckName;
	public string DeckName { get => m_DeckName; private set => m_DeckName = value; }

	[SerializeField]
	private List<CardData> m_Deck;
	public List<CardData> Deck { get => new List<CardData>(m_Deck); private set => m_Deck = value; }
}
