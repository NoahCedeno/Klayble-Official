using UnityEngine;

[CreateAssetMenu(fileName = "AttackData", menuName = "ScriptableObjects/AttackData", order = 3)]
public class AttackData : ScriptableObject
{
    [SerializeField]
    private Elementals m_ElementalType;

    public Elementals ElementalType { get => m_ElementalType; private set => m_ElementalType = value; }

    [SerializeField]
    private float m_BaseDamage;

    public float BaseDamage { get => m_BaseDamage; private set => m_BaseDamage = value; }
}