namespace JumpingPlatformGame {
    public struct Movement
    {
        public Meters UpperBound { get; set; }
        public Meters LowerBound { get; set; }
        public MeterPerSeconds Speed;
       
        public void ReverseDirection()
        {
            Speed.Value = Speed.Value * -1;
        }
    }

    public struct WorldPoint
    {
        public Meters X, Y;
    }
    public struct MeterPerSeconds
    {
        public double Value { get; set; }
        
        public override string ToString()
        {
            return Value.ToString();
        }

        public static Meters operator *(MeterPerSeconds mps, Seconds s) => new Meters() { Value = mps.Value * s.Value};

    }
    public struct Meters
    {
        public double Value { get; set; }

        public static Meters operator *(Meters x, int direction) => new Meters() { Value = x.Value *direction };
        public static MeterPerSeconds operator /(Meters m, Seconds s)
        {
            double v = m.Value / s.Value;
            return new MeterPerSeconds() { Value = v };
        }
        public static Meters operator +(Meters x, Meters y) => new Meters() { Value = x.Value + y.Value };
    }
    public struct Seconds
    {
        public double Value { get; set; }
    }
    public static class IntExtensions
    {
        public static Seconds Seconds(this int value)
        {
            return new Seconds() { Value = value };
        }
        public static Meters Meters(this int value)
        {
            return new Meters() { Value = value };
        }
        public static MeterPerSeconds MeterPerSeconds(this int value)
        {
            return new MeterPerSeconds() { Value = value };
        }
    }

    public static class DoubleExtensions
    {
        public static Seconds Seconds(this double value)
        {
            return new Seconds() { Value = value };
        }
        public static Meters Meters(this double value)
        {
            return new Meters() { Value = value };
        }
        public static MeterPerSeconds MeterPerSeconds(this double value)
        {
            return new MeterPerSeconds() { Value = value };
        }
    }


}