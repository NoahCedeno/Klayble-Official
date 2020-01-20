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

            // Initialize BattlePermissions!
            CanMove = new BattlePermission(true, true);
            CanAttack = new BattlePermission(true, true);
            CanInteract = new BattlePermission(false, false);
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
            target.ChangeHP(CardData.AttackData.BaseDamage);
        }

        /// <summary>
        /// Changes the Card's HP.
        /// </summary>
        /// <param name="change"></param>
        public override void ChangeHP(int change)
        {
            // TODO: Call UI Method to change HP for this target :)

            if (change > 0)
            {
                // If greater than max health,
                if (CardData.BattleStats.CurrentHitPoints + change > CardData.BattleStats.TotalHitPoints)
                {
                    CardData.BattleStats.CurrentHitPoints = CardData.BattleStats.TotalHitPoints;
                }
            }
            else if (change < 0)
            {
                // If less than 0 health,
                if (CardData.BattleStats.CurrentHitPoints + change < 0)
                {
                    // Somehow Call Death here
                    CardData.BattleStats.CurrentHitPoints = 0;
                }
            }
            else
            {
                // If not dead and not max health,
                CardData.BattleStats.CurrentHitPoints += change;
            }

            CheckIfDead();
        }

        /// <summary>
        /// Mostly meant to check if dead or not.
        /// </summary>
        public override void CheckIfDead()
        {
            // If we're dead (HP == 0),
            if (CardData.BattleStats.CurrentHitPoints == 0)
            {
                CardData.BattleStats.IsDead = true;
                // TODO: Fade out or set death animation trigger here, make inactive after or something.
            }
        }

        public override void Interact(BattleController target)
        {
            Debug.Log("Cards cannot Interact!");
        }
    }
}