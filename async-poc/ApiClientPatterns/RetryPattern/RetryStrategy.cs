namespace RetryPattern
{
    public class RetryStrategy
    {
        public int MaxRetries { get; private set; }

        public TimeSpan Interval { get; private set; }

        public RetryStrategy(int maxRetryAttemps, TimeSpan interval) {
            MaxRetries = maxRetryAttemps;
            Interval = interval;
        }

       

    }
}
