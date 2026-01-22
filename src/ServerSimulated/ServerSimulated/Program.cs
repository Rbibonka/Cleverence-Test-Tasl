using ServerSimulated.Servers;
using ServerSimulated.ServerUsers;

for (int i = 1; i <= 10; i++)
{
    new User(i).Start();
}

Console.WriteLine("Все пользователи завершили работу." + Server.GetCount());