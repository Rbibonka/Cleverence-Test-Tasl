using ServerSimulated.Servers;
using ServerSimulated.ServerUsers.Interfaces;

namespace ServerSimulated.ServerUsers
{
    class Client : IClient
    {
        public void Read()
        {
            int value = Server.GetCount();
            
            Thread.Sleep(100);
        }

        public void Write()
        {
            Server.AddToCount(1);
            
            Thread.Sleep(300);
        }
    }
}