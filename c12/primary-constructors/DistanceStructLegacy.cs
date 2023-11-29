namespace primary_constructors
{
    internal readonly struct DistanceStructLegacy
    {
        public readonly double Magnitude { get; }
        public readonly double Direction { get; }

        public DistanceStructLegacy(double dx, double dy)
        {
            Magnitude = Math.Sqrt(dx*dy + dy*dy);
            Direction = Math.Atan2(dy, dx);
        }
    }
}
