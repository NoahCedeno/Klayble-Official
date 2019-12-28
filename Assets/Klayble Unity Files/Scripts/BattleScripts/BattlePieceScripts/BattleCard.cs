using UnityEngine;

namespace BattlePieceSystem
{
    /// <summary>
    /// Represents a Card on the battleField!
    /// </summary>
    public class BattleCard : BattlePiece
    {
        [SerializeField]
        private CardData m_CardData;

        public CardData CardData { get => m_CardData; private set => m_CardData = value; }
    }
}