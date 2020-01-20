using UnityEngine;

[CreateAssetMenu(fileName = "BattleStats", menuName = "ScriptableObjects/BattleStats", order = 1)]
public class BattleStats : ScriptableObject
{
    [SerializeField]
    private int m_TotalHitPoints;

    public int TotalHitPoints { get => m_TotalHitPoints; set => m_TotalHitPoints = value; }

    [SerializeField]
    private int m_CurrentHitPoints;

    public int CurrentHitPoints { get => m_CurrentHitPoints; set => m_CurrentHitPoints = value; }

    [SerializeField]
    private bool m_IsDead;

    public bool IsDead { get => m_IsDead; set => m_IsDead = value; }

    [SerializeField]
    private int m_Attack;

    public int Attack { get => m_Attack; set => m_Attack = value; }

    [SerializeField]
    private Elementals m_Element;

    public Elementals Element { get => m_Element; set => m_Element = value; }
}