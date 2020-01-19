using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData", order = 1)]
public class CardData : BattleData
{
    [SerializeField]
    private int m_CardId;

    public int CardId { get => m_CardId; private set => m_CardId = value; }

    [SerializeField]
    private AttackData m_AttackData;

    public AttackData AttackData { get => m_AttackData; private set => m_AttackData = value; }

    // TODO: Check with Jeff if I can use abstraction to still inherit serialized data with backing fields.
}