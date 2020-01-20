using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleObjectSystem
{
    [DisallowMultipleComponent]
    public class CardController : BattleController
    {
        [SerializeField, Header("Card Data")]
        private CardData m_CardData;
        public CardData CardData { get => m_CardData; private set => m_CardData = value; }

        // + + + + + + + + + + | Methods | + + + + + + + + + + 

        private void Awake()
        {
            BattleObject = BattleObject.Card;
            CanMove = true;
            CanAttack = true;
        }

        new private void Start()
        {
            base.Start();
        }

        /// <summary>
        /// Cards attack with some calculation of their Attack/Move's base damage and type.
        /// </summary>
        /// <param name="target"></param>
        public override void Attack(BattleController target)
        {
            throw new System.NotImplementedException();
        }

    }
}
