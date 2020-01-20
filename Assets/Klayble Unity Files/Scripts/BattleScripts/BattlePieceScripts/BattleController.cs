using BoardSystem;
using System.Collections;
using UnityEngine;

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

            Move(new Vector2Int(5, 2));
        }

        /// <summary>
        /// Moves the GameObject with the help of an IEnumerator, ONLY if
        /// the type of BattleObject can move, that is.
        /// </summary>
        /// <param name="direction"></param>
        public void Move(Vector2Int direction)
        {
            if (CanMove)
            {
                // TODO: Start an animation here perhaps? Animator boolean thingie?
                StartCoroutine(LerpToVector3(new Vector3(direction.x, 0.5f, direction.y)));
            }
        }

        /// <summary>
        /// A helper coroutine to lerp the GameObject to a Vector3.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private IEnumerator LerpToVector3(Vector3 target)
        {

            float elapsedTime = 0f;
            float waitTime = 2f;
            Vector3 currentPos = transform.position;

            while(elapsedTime < waitTime)
            {
                transform.position = Vector3.Lerp(currentPos, target, (elapsedTime / waitTime));
                elapsedTime += Time.deltaTime;

                yield return null;
            }

            transform.position = target;

            yield return null;
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