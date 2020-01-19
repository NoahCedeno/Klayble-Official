using UnityEngine;
using BoardSystem;

namespace BattleObjectSystem
{
    /// <summary>
    /// Planned to be the base class for my more specific scripts.
    /// </summary>
    [DisallowMultipleComponent]
    public class BattleController : MonoBehaviour
    {
        [SerializeField]
        private BattleData m_Data;

        public BattleData Data { get => m_Data; private set => m_Data = value; }

        [SerializeField, HideInInspector]
        private BattleObject m_BattleObject;

        public BattleObject BattleObject { get => m_BattleObject; private set => m_BattleObject = value; }

        [SerializeField, HideInInspector]
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

        /// <summary>
        /// Updates the Board Position according to a TileController's,
        /// called every time the GO enters a TileController's Collider.
        /// </summary>
        public void UpdateBoardPosition(TileController tileOn)
        {
            BoardPosition = tileOn.ArrayLocation;
        }

        public void Attack(BattleController target)
        {
            Debug.Log("Attacking " + target.Data.name + "!"); // TODO: Implement Something Here!
        }

    }
}