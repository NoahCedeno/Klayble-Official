using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattlePieceSystem;

[CreateAssetMenu(fileName = "StatsData", menuName = "ScriptableObjects/StatsData", order = 1)]
public class BattleStatsData : ScriptableObject
{
    [SerializeField]
    private int m_HitPoints;
    public int HitPoints { get => m_HitPoints; private set => m_HitPoints = value; }

    [SerializeField]
    private int m_Attack;
    public int Attack { get => m_Attack; private set => m_Attack = value; }

    [SerializeField]
    private Elementals m_Element;
    public Elementals Element { get => m_Element; private set => m_Element = value; }

}
