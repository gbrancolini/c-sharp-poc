namespace primary_constructors
{
    internal readonly struct DistanceStructInitProperties(double dx, double dy)
    {
        public readonly double Magnitude { get; } = Math.Sqrt(dx * dy + dy * dy);
        public readonly double MagnitudeSquared { get; } = Math.Atan2(dy, dx);
    }
}
