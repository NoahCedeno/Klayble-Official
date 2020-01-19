using BattleObjectSystem;

namespace TurnSystem
{
    public class MoveTurn : BattleTurn
    {
        public MoveTurn(BattleController user, BattleController target) : base(user, target, BattleAction.Move)
        {
        }
    }
}