using UnityEngine;

[CreateAssetMenu(fileName = "MoveData", menuName = "ScriptableObjects/MoveData", order = 3)]
public class MoveData : ScriptableObject
{
    [SerializeField]
    private Elementals m_ElementalType;

    public Elementals ElementalType { get => m_ElementalType; private set => m_ElementalType = value; }

    [SerializeField]
    private float m_BaseDamage;

    public float BaseDamage { get => m_BaseDamage; private set => m_BaseDamage = value; }
}