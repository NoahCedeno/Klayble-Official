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
        [SerializeField, Header("Battle Object Data")]
        private BattleData m_Data;

        public BattleData Data { get => m_Data; private set => m_Data = value; }

        [SerializeField, HideInInspector]
        private BattleObject m_BattleObject;

        public BattleObject BattleObject { get => m_BattleObject; private set => m_BattleObject = value; }

        [SerializeField, HideInInspector]
        private BoardManager m_BoardManager;
        
        public BoardManager BoardManager { get => m_BoardManager; private set => m_BoardManager = value; }

        [SerializeField]
        protected Vector2Int m_BoardPosition;

        public Vector2Int BoardPosition { get => m_BoardPosition; private set => m_BoardPosition = value; }

        [SerializeField]
        private bool m_CanMove;

        public bool CanMove { get => m_CanMove; private set => m_CanMove = value; }

        [SerializeField, HideInInspector]
        private bool m_IsMoving; // Used for animation and Moving

        [SerializeField]
        private bool m_CanAttack;

        public bool CanAttack { get => m_CanAttack; private set => m_CanAttack = value; }

        // + + + + + + + + + + | Methods | + + + + + + + + + +

        private void Awake()
        {
            BattleObject = Data.BattleObject;

            // TODO: These cases will need redefinition as restrictions develop.
            CanMove = (BattleObject == BattleObject.Card || BattleObject == BattleObject.DeckMaster);
            CanAttack = (BattleObject == BattleObject.Card || BattleObject == BattleObject.DeckMaster);

            m_IsMoving = false;

        }

        private void Start()
        {
            BoardManager = GameObject.Find("Board").GetComponent<BoardManager>();
        }

        private void Update()
        {
            if (!m_IsMoving)
            {
                Move(Vector2Int.right);
            }
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
            if(CanMove)
            {
                if(!m_IsMoving)
                {
                    if(BoardManager.GetTileAt(toBoardPosition.x, toBoardPosition.y) != null)
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

        public void Attack(BattleController target)
        {
            Debug.Log("Attacking " + target.Data.name + "!"); // TODO: Implement Something Here!
        }
    }
}