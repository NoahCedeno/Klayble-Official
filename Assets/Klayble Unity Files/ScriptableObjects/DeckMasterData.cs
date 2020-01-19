using System.Collections.Generic;
using UnityEngine;
using BattleObjectSystem;

[CreateAssetMenu(fileName = "DeckMasterData", menuName = "ScriptableObjects/DeckMasterData", order = 2)]
public class DeckMasterData : BattleData
{
    [SerializeField]
    private int m_DeckMasterId;

    public int DeckMasterId { get => m_DeckMasterId; private set => m_DeckMasterId = value; }

    [SerializeField]
    private List<CardData> m_Deck;

    public List<CardData> Deck { get => new List<CardData>(m_Deck); private set => m_Deck = value; }

    private void Awake()
    {
        m_BattleObject = BattleObject.DeckMaster;
    }
}