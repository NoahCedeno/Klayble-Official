using BattleObjectSystem;

namespace TurnSystem
{
    public class MoveTurn : BattleTurn
    {
        public MoveTurn(BattlePiece user, BattlePiece target) : base(user, target, BattleAction.Move)
        {
        }
    }
}