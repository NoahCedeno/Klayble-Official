using UnityEngine;

namespace BattlePieceSystem
{
	/// <summary>
	/// BattleNPOs represent Non-Player Objects on the battlefield, such as structures like walls and buildings
	/// to objects like treasure chests and interactive elements on the field.
	/// </summary>
	public abstract class BattleNPO : BattlePiece
	{
		[SerializeField]
		private bool m_IsInteractable;
		public bool IsInteractable { get => m_IsInteractable; private set => m_IsInteractable = value; }

		public void Interact() // TODO: Change access modifiers for the whole abstraction maybe.
		{
			if (IsInteractable)
			{
				// TODO: Implement something here.
			}
			else
			{
				Debug.Log("Cannot interact with " + this.PieceName + "!");
			}
		}
	}
}
