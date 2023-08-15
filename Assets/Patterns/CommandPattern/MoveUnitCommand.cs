using UnityEngine;

    public class MoveUnitCommand : Command
    {
        private int x_;
        private int y_;
        private int yBefore_ = 0;
        private int xBefore_ = 0;

        public MoveUnitCommand(Unit unit, int x, int y) : base(unit)
        {
            this.x_ = x;
            this.y_ = y;
            xBefore_ = unit_.x();
            yBefore_ = unit_.y();
        }

        public override void Execute()
        {
            unit_.MoveTo(x_,y_);
        }

        public override void Undo()
        {
            var tempX = unit_.x();
            var tempY = unit_.y();
            
            unit_.MoveTo(xBefore_, yBefore_);
            
            this.xBefore_ = tempX;
            this.yBefore_ = tempY;
        }
    }