using System.Collections.Generic;

[System.Serializable]
public class Game
{
    public string gameID;
    public List<Client> clients;
    public Game() { }
    public void RemoveClient(string clientID)
    {
        int length = clients.Count;
        for(int i=0;i<length;i++)
        {
            if (clients[i].clientID == clientID)
            {
                clients.RemoveAt(i);
                return;
            }
        }
    }
    public void ChangePrio(string clientID, int prio)
    {
        int length = clients.Count;
        for (int i = 0; i < length; i++)
        {
            if (clients[i].clientID == clientID)
            {
                clients[i].prio = prio;
            }
        }
    }
    public bool ReadyClient(string clientID)
    {
        int length = clients.Count;
        for (int i = 0; i < length; i++)
        {
            if (clients[i].clientID == clientID)
            {
                clients[i].ready = !clients[i].ready;
                return clients[i].ready;
            }
        }
        return false;
    }
}
