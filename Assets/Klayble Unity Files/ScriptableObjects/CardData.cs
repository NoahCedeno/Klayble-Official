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
    private int m_HitPoints;

    public int HitPoints { get => m_HitPoints; private set => m_HitPoints = value; }

    [SerializeField]
    private int m_Attack;

    public int Attack { get => m_Attack; private set => m_Attack = value; }

    [SerializeField]
    private int m_Defense;

    public int Defense { get => m_Defense; private set => m_Defense = value; }

    [SerializeField]
    private string m_CardName;

    public string CardName { get => m_CardName; private set => m_CardName = value; }
}