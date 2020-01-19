﻿using UnityEngine;

namespace BattleObjectSystem
{
    /// <summary>
    /// Planned to be the base class for my more specific scripts.
    /// </summary>
    public class BattleController : MonoBehaviour
    {
        [SerializeField]
        private BattleData m_Data;

        public BattleData Data { get => m_Data; private set => m_Data = value; }

        [SerializeField]
        private BattleObject m_BattleObject;

        public BattleObject BattleObject { get => m_BattleObject; private set => m_BattleObject = value; }

        [SerializeField]
        protected Vector2Int m_BoardPosition;

        public Vector2Int BoardPosition { get => m_BoardPosition; private set => m_BoardPosition = value; }

        [SerializeField]
        private bool m_CanMove;

        public bool CanMove { get => m_CanMove; private set => m_CanMove = value; }

        [SerializeField]
        private bool m_CanAttack;

        public bool CanAttack { get => m_CanAttack; private set => m_CanAttack = value; }

        // + + + + + + + + + + | Methods | + + + + + + + + + +

        protected void Awake()
        {
            BattleObject = Data.BattleObject;

            // These cases will need redefinition as restrictions develop.
            CanMove = (BattleObject == BattleObject.Card || BattleObject == BattleObject.DeckMaster);
            CanAttack = (BattleObject == BattleObject.Card || BattleObject == BattleObject.DeckMaster);
        }

        public void Move(Vector2Int direction)
        {
            if (CanMove)
            {
                BoardPosition += direction; // TODO: Time for an Animation / Lerp Thing!
            }
        }

        public void Attack(BattleController target)
        {
            Debug.Log("Attacking " + target.Data.name + "!"); // TODO: Implement Something Here!
        }
    }
}