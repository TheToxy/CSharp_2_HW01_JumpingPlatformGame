using System.Drawing;

namespace JumpingPlatformGame {
	class Entity {
		public virtual Color Color => Color.Black;
        public WorldPoint Location;

        public virtual void Update(Seconds seconds) {}
	}

    class MovableEntity : Entity
    {
        public Movement Horizontal = new Movement();
        public override void Update(Seconds seconds)
        {
            var newLocation = this.Location.X + this.Horizontal.Speed * seconds;

            if (newLocation.Value > this.Horizontal.UpperBound.Value)
            {
                newLocation = this.Horizontal.UpperBound;
                this.Horizontal.ReverseDirection();
            }
            if (newLocation.Value < this.Horizontal.LowerBound.Value)
            {
                newLocation = this.Horizontal.LowerBound;
                this.Horizontal.ReverseDirection();
            }

            this.Location.X = newLocation;
        }
    }

    class MovableJumpingEntity : MovableEntity {
        public Movement Vertical = new Movement();
        public override void Update(Seconds seconds)
        {
            base.Update(seconds);            
            var newLocation = this.Location.Y + (this.Vertical.Speed * seconds);

            if (newLocation.Value > this.Vertical.UpperBound.Value)
            {
                newLocation = this.Vertical.UpperBound;
                this.Vertical.ReverseDirection();
            }
            if (newLocation.Value < this.Vertical.LowerBound.Value)
            {
                newLocation = this.Vertical.LowerBound;               
            }

            this.Location.Y = newLocation;
        }
    }

	class Joe : MovableEntity {
		public override string ToString() => "Joe";
		public override Color Color => Color.Blue;
	}

	class Jack : MovableEntity {
		public override string ToString() => "Jack";
		public override Color Color => Color.LightBlue;
	}

	class Jane : MovableJumpingEntity {
		public override string ToString() => "Jane";
		public override Color Color => Color.Red;
	}

	class Jill : MovableJumpingEntity {
		public override string ToString() => "Jill";
		public override Color Color => Color.Pink;
	}
}