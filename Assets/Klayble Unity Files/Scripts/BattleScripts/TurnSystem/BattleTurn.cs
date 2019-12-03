using BattlePieceSystem;
using UnityEngine;

namespace TurnSystem
{
    public abstract class BattleTurn
    {
        [SerializeField]
        protected BattlePiece m_User;

        public BattlePiece User { get => m_User; private set => m_User = value; }

        [SerializeField]
        protected BattlePiece m_Target;

        public BattlePiece Target { get => m_Target; private set => m_Target = value; }

        [SerializeField]
        protected BattleAction m_Action;

        public BattleAction Action { get => m_Action; private set => m_Action = value; }

        protected BattleTurn(BattlePiece user, BattlePiece target, BattleAction action)
        {
            User = user;
            Target = target;
            Action = action;
        }
    }
}