using UnityEngine;

namespace BattleObjectSystem
{
    /// <summary>
    /// Represents a DeckMaster on the battlefield!
    /// </summary>
    public class BattleDeckMaster : BattlePiece
    {
        [SerializeField]
        private DeckMasterData m_DMData;

        public DeckMasterData DMData { get => m_DMData; private set => m_DMData = value; }
    }
}