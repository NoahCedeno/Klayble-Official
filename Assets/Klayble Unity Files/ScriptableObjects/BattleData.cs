using UnityEngine;

public class BattleData : ScriptableObject
{
    [SerializeField]
    private int m_Level;

    public int Level { get => m_Level; private set => m_Level = value; }

    [SerializeField]
    private BattleStats m_BattleStats;

    public BattleStats BattleStats { get => m_BattleStats; private set => m_BattleStats = value; }
}