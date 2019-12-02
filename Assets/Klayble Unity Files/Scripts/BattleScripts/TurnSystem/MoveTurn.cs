using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattlePieceSystem;

namespace TurnSystem
{
    public class MoveTurn : BattleTurn
    {
        public MoveTurn(BattlePiece user, BattlePiece target) : base(user, target, BattleAction.Move)
        {
            
        }
    }
}