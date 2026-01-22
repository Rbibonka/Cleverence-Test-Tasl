using ServerSimulated.ServerUsers;

namespace ServerSimulated.ServerClients
{
    public class ClientsLifeCycle
    {
        private Thread[] threads;

        public ClientsLifeCycle(int clientCount)
        {
            threads = new Thread[clientCount];
        }

        public void StartLifeCycle()
        {
            for (int i = 0; i < threads.Length; i++)
            {
                var realClient = new Client();
                var decoratedClient = new ProbabilityClientDecorator(realClient, readProbabilityPercent: 80);

                threads[i] = new Thread(() =>
                {
                    for (int j = 0; j < 20; j++)
                    {
                        decoratedClient.Execute();
                    }
                });

                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
        }
    }
}