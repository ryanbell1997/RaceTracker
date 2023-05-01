namespace RaceTracker.Data
{
    public class TimeComputer
    {
        private readonly RacePredictions _racePredictions;

        private TimeSpan _t1Prediction = TimeSpan.FromMinutes(5);
        private TimeSpan _t2Prediction = TimeSpan.FromMinutes(3);

        private DateTime _actualSwimFinishTime;
        private DateTime _actualT1FinishTime;
        private DateTime _startTime;
        private DateTime _actualBikeFinishTime;
        private DateTime _actualT2FinishTime;
        private DateTime _predictedRunFinishTime;

        public TimeComputer(RacePredictions racePredictions)
        {
            _racePredictions = racePredictions;
            ItalyTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
        }

        public TimeZoneInfo ItalyTimeZoneInfo { get; init; }

        public DateTime StartTime
        {
            get => _startTime;
            set
            {
                _startTime = value;
                PredictedSwimFinishTime = StartTime.Add(_racePredictions.SwimTime);
                PredictedT1FinishTime = PredictedSwimFinishTime.Add(_t1Prediction);
                PredictedBikeFinishTime = PredictedT1FinishTime.Add(_racePredictions.BikeTime);
                PredictedT2FinishTime = PredictedBikeFinishTime.Add(_t2Prediction);
                PredictedRunFinishTime = PredictedT2FinishTime.Add(_racePredictions.RunTime);
            }
        }
        public DateTime ActualSwimFinishTime
        {
            get => _actualSwimFinishTime;
            set
            {
                _actualSwimFinishTime = value;
                PredictedT1FinishTime = _actualSwimFinishTime.Add(_t1Prediction);
                PredictedBikeFinishTime = PredictedT1FinishTime.Add(_racePredictions.BikeTime);
                PredictedT2FinishTime = PredictedBikeFinishTime.Add(_t2Prediction);
                PredictedRunFinishTime = PredictedT2FinishTime.Add(_racePredictions.RunTime);
            }
        }
        public DateTime ActualT1FinishTime
        {
            get => _actualT1FinishTime;
            set
            {
                _actualT1FinishTime = value;
                PredictedBikeFinishTime = _actualT1FinishTime.Add(_racePredictions.BikeTime);
                PredictedT2FinishTime = PredictedBikeFinishTime.Add(_t2Prediction);
                PredictedRunFinishTime = PredictedT2FinishTime.Add(_racePredictions.RunTime);
            }
        }
        public DateTime ActualBikeFinishTime
        {
            get => _actualBikeFinishTime;
            set
            {
                _actualBikeFinishTime = value;
                PredictedT2FinishTime = _actualBikeFinishTime.Add(_t2Prediction);
                PredictedRunFinishTime = PredictedT2FinishTime.Add(_racePredictions.RunTime);
            }
        }
        public DateTime ActualT2FinishTime 
        {
            get => _actualT2FinishTime;
            set
            {
                _actualT2FinishTime = value;
                PredictedRunFinishTime = _actualT2FinishTime.Add(_racePredictions.RunTime);
            }
        }
        public DateTime ActualRunFinishTime { get; set; }

        public DateTime PredictedSwimFinishTime { get; set; }
        public DateTime PredictedT1FinishTime { get; set; }
        public DateTime PredictedBikeFinishTime { get; set; }
        public DateTime PredictedT2FinishTime { get; set; }
        public DateTime PredictedRunFinishTime 
        {
            get => _predictedRunFinishTime;
            set
            {
                _predictedRunFinishTime = value;
            }
        }

        public void ResetAll()
        {
            PredictedSwimFinishTime = DateTime.MinValue;
            ActualBikeFinishTime = DateTime.MinValue;
            ActualRunFinishTime = DateTime.MinValue;
            ActualSwimFinishTime = DateTime.MinValue;
            ActualT1FinishTime = DateTime.MinValue;
            ActualT2FinishTime = DateTime.MinValue;
            StartTime = DateTime.MinValue;
        }

        public void SetStartTime()
            => StartTime = GetCurrentItalyTime();
        public void SetSwimTime()
            => ActualSwimFinishTime = GetCurrentItalyTime();
        public void SetT1Time()
            => ActualT1FinishTime = GetCurrentItalyTime();
        public void SetBikeTime()
            => ActualBikeFinishTime = GetCurrentItalyTime();
        public void SetT2Time()
            => ActualT2FinishTime = GetCurrentItalyTime();
        public void SetRunTime()
            => ActualRunFinishTime = GetCurrentItalyTime();

        private DateTime GetCurrentItalyTime()
            => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, ItalyTimeZoneInfo);

    }

}
