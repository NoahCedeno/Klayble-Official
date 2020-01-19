using BattleObjectSystem;
using UnityEngine;

namespace TurnSystem
{
    public abstract class BattleTurn
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
    }
}