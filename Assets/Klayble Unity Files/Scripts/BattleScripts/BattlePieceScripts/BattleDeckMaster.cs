using UnityEngine;

namespace BattlePieceSystem
{
    public class BattleDeckMaster : BattlePiece
    {
        [SerializeField]
        private DeckMasterData m_DMData;

        public DeckMasterData DMData { get => m_DMData; private set => m_DMData = value; }
    }
}