using UnityEngine;

[CreateAssetMenu(fileName = "AttackData", menuName = "ScriptableObjects/AttackData", order = 3)]
public class AttackData : ScriptableObject
{
    [SerializeField]
    private Elementals m_ElementalType;

    public Elementals ElementalType { get => m_ElementalType; private set => m_ElementalType = value; }

    [SerializeField]
    private int m_BaseDamage;

    public int BaseDamage { get => m_BaseDamage; private set => m_BaseDamage = value; }
}