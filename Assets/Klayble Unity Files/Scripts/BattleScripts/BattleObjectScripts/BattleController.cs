using BoardSystem;
using System.Collections;
using UnityEngine;

namespace BattleObjectSystem
{
    /// <summary>
    /// Planned to be the base class for my more specific scripts.
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class BattleController : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        protected BattleObject m_BattleObject;

        public BattleObject BattleObject { get => m_BattleObject; protected set => m_BattleObject = value; }

        [SerializeField, HideInInspector]
        protected BoardManager m_BoardManager;

        public BoardManager BoardManager { get => m_BoardManager; protected set => m_BoardManager = value; }

        [SerializeField, HideInInspector]
        protected Vector2Int m_BoardPosition;

        public Vector2Int BoardPosition { get => m_BoardPosition; protected set => m_BoardPosition = value; }

        [SerializeField, HideInInspector]
        protected bool m_IsMoving = false; // Used for animation and Moving

        [SerializeField, HideInInspector]
        protected BattlePermission m_CanMove;

        public BattlePermission CanMove { get => m_CanMove; protected set => m_CanMove = value; }

        [SerializeField, HideInInspector]
        protected BattlePermission m_CanAttack;

        public BattlePermission CanAttack { get => m_CanAttack; protected set => m_CanAttack = value; }

        [SerializeField, HideInInspector]
        protected BattlePermission m_CanInteract;

        public BattlePermission CanInteract { get => m_CanInteract; protected set => m_CanAttack = value; }

        // + + + + + + + + + + | Methods | + + + + + + + + + +

        protected void Start()
        {
            BoardManager = GameObject.Find("Board").GetComponent<BoardManager>();
        }

        /// <summary>
        /// Moves the GameObject with the help of an IEnumerator, ONLY if
        /// the type of BattleObject can move, that is.
        /// </summary>
        /// <param name="direction"></param>
        public void Move(Vector2Int direction)
        {
            // Must invert the Y for Vector2Int constants because of BoardPosition / Array indexing style.
            direction.y *= -1;
            Vector2Int toBoardPosition = BoardPosition + direction;
            if (CanMove.CanPerform)
            {
                if (!m_IsMoving)
                {
                    if (BoardManager.GetTileAt(toBoardPosition.x, toBoardPosition.y) != null)
                    {
                        StartCoroutine(LerpWithDisplacement(direction));
                    }
                    else
                    {
                        Debug.Log("There is no Tile at the position " + toBoardPosition + "!");
                    }
                }
                else
                {
                    Debug.Log("Cannot start Coroutine, already moving!");
                }
            }
            else
            {
                Debug.Log("The type " + BattleObject + " cannot Move!");
            }
        }

        /// <summary>
        /// A helper coroutine to lerp from a BoardPosition (Vec2Int) with a displacement Vector2 for an argument.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private IEnumerator LerpWithDisplacement(Vector2Int displacement)
        {
            m_IsMoving = true;
            // TODO: Start an animation here perhaps? Animator boolean thingie = m_IsMoving?
            float elapsedTime = 0f;
            float waitTime = 2f;
            Vector2Int currentPos = BoardPosition;
            Vector2Int toPosition = BoardPosition + displacement;
            Vector3 objOffset = new Vector3(0f, 0.5f, 0f);

            while (elapsedTime < waitTime)
            {
                transform.position = Vector3.Lerp(BoardManager.GetTileAt(currentPos.x, currentPos.y).transform.position + objOffset,
                                                  BoardManager.GetTileAt(toPosition.x, toPosition.y).transform.position + objOffset,
                                                  (elapsedTime / waitTime));
                elapsedTime += Time.deltaTime;

                yield return null;
            }

            transform.position = BoardManager.GetTileAt(toPosition.x, toPosition.y).transform.position + objOffset;
            yield return null;
            m_IsMoving = false;
        }

        /// <summary>
        /// Updates the Board Position according to a TileController's,
        /// called every time the GO enters a TileController's Collider.
        /// </summary>
        public void UpdateBoardPosition(TileController tileOn)
        {
            BoardPosition = tileOn.ArrayLocation;
        }

        public abstract void Attack(BattleController target);

        public abstract void ChangeHP(int change);

        public abstract void CheckIfDead();

        public abstract void Interact(BattleController target);
    }
}