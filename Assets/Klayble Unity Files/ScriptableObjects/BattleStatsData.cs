using UnityEngine;

[CreateAssetMenu(fileName = "BattleStatsData", menuName = "ScriptableObjects/BattleStatsData", order = 1)]
public class BattleStats : ScriptableObject
{
    [SerializeField]
    private int m_TotalHitPoints;

    public int TotalHitPoints { get => m_TotalHitPoints; private set => m_TotalHitPoints = value; }

    [SerializeField]
    private int m_CurrentHitPoints;

    public int CurrentHitPoints { get => m_CurrentHitPoints; private set => m_CurrentHitPoints = value; }

    [SerializeField]
    private bool m_IsDead;

    public bool IsDead { get => m_IsDead; private set => m_IsDead = value; }

    [SerializeField]
    private int m_Attack;

    public int Attack { get => m_Attack; private set => m_Attack = value; }

    [SerializeField]
    private Elementals m_Element;

    public Elementals Element { get => m_Element; private set => m_Element = value; }
}