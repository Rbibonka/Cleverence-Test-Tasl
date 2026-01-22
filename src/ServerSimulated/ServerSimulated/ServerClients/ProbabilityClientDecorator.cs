using ServerSimulated.ServerUsers.Interfaces;

namespace ServerSimulated.ServerUsers
{
    public class ProbabilityClientDecorator
    {
        private readonly IClient client;

        private static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));

        private int ReadProbabilityPercent;

        public ProbabilityClientDecorator(IClient client, int readProbabilityPercent)
        {
            this.client = client;
            ReadProbabilityPercent = readProbabilityPercent;
        }

        public void Execute()
        {
            int value = random.Value.Next(100);

            if (value < ReadProbabilityPercent)
            {
                client.Read();
            }
            else
            {
                client.Write();
            }
        }
    }
}