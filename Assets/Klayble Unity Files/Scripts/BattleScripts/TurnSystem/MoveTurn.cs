using BattleObjectSystem;

namespace TurnSystem
{
    public class MoveTurn : BattleTurn
    {
        public MoveTurn(BattleController user, BattleController target) : base(user, target, BattleAction.Move)
        {
        }

        // + + + + + + + + + + | Methods | + + + + + + + + + +

        public override bool IsMoveValid()
        {
            return (User.CanMove.CanPerform || User.CanMove.CanReceive);
        }

        public override void ExecuteAction()
        {
            if (IsMoveValid())
            {
                User.Attack(Target); // TODO: Throw and/or handle an exception here?
            }
        }
    }
}