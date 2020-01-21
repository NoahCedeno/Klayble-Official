using BattleObjectSystem;
using UnityEngine;

namespace TurnSystem
{
    public abstract class BattleTurn : ITurn
    {
        [SerializeField]
        protected BattleController m_User;

        public BattleController User { get => m_User; private set => m_User = value; }

        [SerializeField]
        protected BattleController m_Target;

        public BattleController Target { get => m_Target; private set => m_Target = value; }

        [SerializeField]
        protected BattleAction m_Action;

        public BattleAction Action { get => m_Action; private set => m_Action = value; }

        protected BattleTurn(BattleController user, BattleController target, BattleAction action)
        {
            User = user;
            Target = target;
            Action = action;
        }

        // + + + + + + + + + + | Methods | + + + + + + + + + +

        public abstract void ExecuteAction();

        /// <summary>
        /// Checks, for any BattleAction type of the BattleTurn, whether the members
        /// are able to perform such an action.
        /// </summary>
        /// <returns>Whether the User and Target are capable of the action.</returns>
        public abstract bool IsMoveValid();

        /* Copy cases to other implementations.
        {
            if (Action == BattleAction.Attack)
            {
                return (User.CanAttack.CanPerform && Target.CanAttack.CanReceive);
            }
            else if (Action == BattleAction.Interact)
            {
                return (User.CanInteract.CanPerform && Target.CanInteract.CanReceive);
            }
            else
            {
                Debug.Log("This move isn't legal!");
                return false;
            }
        } */
    }
}