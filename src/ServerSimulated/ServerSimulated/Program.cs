using ServerSimulated.Configs;
using ServerSimulated.ServerClients;

ClientsLifeCycle clientsLifeCycle = new(Config.ClientsCount);

clientsLifeCycle.StartLifeCycle();