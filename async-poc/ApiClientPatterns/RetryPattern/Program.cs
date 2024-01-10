namespace RetryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataService dataService = new DataService();
            dataService.GetSomeData();
        }
    }
}
