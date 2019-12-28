using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData", order = 1)]
public class CardData : ScriptableObject
{
    [SerializeField]
    private int m_CardId;

    public int CardId { get => m_CardId; private set => m_CardId = value; }

    [SerializeField]
    private int m_Level;

    public int Level { get => m_Level; private set => m_Level = value; }

    [SerializeField]
    private BattleStats m_BattleStats;

    public BattleStats BattleStats { get => m_BattleStats; private set => m_BattleStats = value; }

    [SerializeField]
    private MoveData m_MoveData;

    public MoveData MoveData { get => m_MoveData; private set => m_MoveData = value; }
}