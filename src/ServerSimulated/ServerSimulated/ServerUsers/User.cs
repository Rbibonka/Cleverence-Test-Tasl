using ServerSimulated.Servers;
using ServerSimulated.ServerUsers.Interfaces;

namespace ServerSimulated.ServerUsers
{
    public class User : IWriter
    {
        private static readonly Random random = new Random();
        private readonly int id;
        private readonly Thread thread;

        public User(int id)
        {
            this.id = id;
            thread = new Thread(Work);
        }

        public void Start()
        {
            thread.Start();
        }

        private void Work()
        {
            while (true)
            {
                bool writeOperation;

                writeOperation = random.Next(0, 4) == 0;

                if (writeOperation)
                {
                    int value;
                    lock (random)
                    {
                        value = random.Next(1, 10);
                    }

                    Server.AddToCount(value);
                    Console.WriteLine($"User {id} wrote +{value}");
                }
                else
                {
                    int value = Server.GetCount();
                    Console.WriteLine($"User {id} read {value}");
                }

                Thread.Sleep(2000);
            }
        }
    }
}