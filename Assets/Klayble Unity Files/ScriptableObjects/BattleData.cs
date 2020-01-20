using BattleObjectSystem;
using UnityEngine;

public class BattleData : ScriptableObject
{
    [SerializeField]
    protected int m_Level;

    public int Level { get => m_Level; protected set => m_Level = value; }

    [SerializeField]
    protected BattleStats m_BattleStats;

    public BattleStats BattleStats { get => m_BattleStats; protected set => m_BattleStats = value; }

    [SerializeField]
    protected BattleObject m_BattleObject;
    
    public BattleObject BattleObject { get => m_BattleObject; protected set => m_BattleObject = value; }
}