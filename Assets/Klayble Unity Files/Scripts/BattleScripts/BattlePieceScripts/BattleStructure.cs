using UnityEngine;

namespace BattlePieceSystem
{
	/// <summary>
	/// BattleStructures represent different elements on the field that may buff BattleAvatars.
	/// </summary>
	public class BattleStructure : BattleNPO
	{
		[SerializeField]
		private int m_HitPointsBuffAmount;
		public int HitPointsBuffAmount { get => m_HitPointsBuffAmount; protected set => m_HitPointsBuffAmount = value; }

		[SerializeField]
		private int m_AttackBuffAmount;
		public int AttackBuffAmount { get => m_AttackBuffAmount; protected set => m_AttackBuffAmount = value; }

		[SerializeField]
		private int m_DefenseBuffAmount;
		public int DefenseBuffAmount { get => m_DefenseBuffAmount; protected set => m_DefenseBuffAmount = value; }

		[SerializeField]
		private int m_LevelUpAmount;
		public int LevelUpAmount { get => m_LevelUpAmount; protected set => m_LevelUpAmount = value; }
	}
}
