namespace RaceTracker.Data
{
    public class RacePredictions
    {
        public TimeSpan SwimTime { get; set; } = TimeSpan.FromMinutes(32);
        public TimeSpan BikeTime { get; set; } = TimeSpan.FromHours(2.66);
        public TimeSpan RunTime { get; set; } = TimeSpan.FromHours(1.95);
    }
}
