using System;
using System.Collections.Generic;

class Player
{
    public int PlayerId { get; set; }
    public string PlayerName { get; set; }
    public int PlayerAge { get; set; }
}

interface ITeam
{
    void Add(Player player);
    void Remove(int playerId);
    Player GetPlayerById(int playerId);
    Player GetPlayerByName(string playerName);
    List<Player> GetAllPlayers();
}

class OneDayTeam : ITeam
{
    public static List<Player> oneDayTeam = new List<Player>();

    public OneDayTeam()
    {
        oneDayTeam.Capacity = 11;
    }

    public void Add(Player player)
    {
        if (oneDayTeam.Count < 11)
        {
            oneDayTeam.Add(player);
            Console.WriteLine("Player added successfully!");
        }
        else
        {
            Console.WriteLine("Cannot add more than 11 players to the team!");
        }
    }

    public void Remove(int playerId)
    {
        Player player = oneDayTeam.Find(p => p.PlayerId == playerId);
        if (player != null)
        {
            oneDayTeam.Remove(player);
            Console.WriteLine("Player removed successfully!");
        }
        else
        {
            Console.WriteLine("Player with given Id not found!");
        }
    }

    public Player GetPlayerById(int playerId)
    {
        return oneDayTeam.Find(p => p.PlayerId == playerId);
    }

    public Player GetPlayerByName(string playerName)
    {
        return oneDayTeam.Find(p => p.PlayerName == playerName);
    }

    public List<Player> GetAllPlayers()
    {
        return oneDayTeam;
    }
}

class Program
{
    static void Main()
    {
        OneDayTeam team = new OneDayTeam();

        while (true)
        {
            Console.WriteLine("\nEnter 1: To Add Player 2: To Remove Player by Id 3. Get Player By Id 4. Get Player by Name 5. Get All Players 6. Exit: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Player Id: ");
                    int playerId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Player Name: ");
                    string playerName = Console.ReadLine();
                    Console.Write("Enter Player Age: ");
                    int playerAge = int.Parse(Console.ReadLine());

                    Player newPlayer = new Player
                    {
                        PlayerId = playerId,
                        PlayerName = playerName,
                        PlayerAge = playerAge
                    };

                    team.Add(newPlayer);
                    break;
                case 2:
                    Console.Write("Enter Player Id to remove: ");
                    int removePlayerId = int.Parse(Console.ReadLine());
                    team.Remove(removePlayerId);
                    break;
                case 3:
                    Console.Write("Enter Player Id to get details: ");
                    int getPlayerId = int.Parse(Console.ReadLine());
                    Player playerById = team.GetPlayerById(getPlayerId);
                    if (playerById != null)
                    {
                        Console.WriteLine($"Player found - Name: {playerById.PlayerName}, Age: {playerById.PlayerAge}");
                    }
                    else
                    {
                        Console.WriteLine("Player with given Id not found!");
                    }
                    break;
                case 4:
                    Console.Write("Enter Player Name to get details: ");
                    string getPlayerName = Console.ReadLine();
                    Player playerByName = team.GetPlayerByName(getPlayerName);
                    if (playerByName != null)
                    {
                        Console.WriteLine($"Player found - Id: {playerByName.PlayerId}, Age: {playerByName.PlayerAge}");
                    }
                    else
                    {
                        Console.WriteLine("Player with given Name not found!");
                    }
                    break;
                case 5:
                    List<Player> allPlayers = team.GetAllPlayers();
                    if (allPlayers.Count > 0)
                    {
                        Console.WriteLine("All Players in the Team:");
                        foreach (Player p in allPlayers)
                        {
                            Console.WriteLine($"Id: {p.PlayerId}, Name: {p.PlayerName}, Age: {p.PlayerAge}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No players in the team!");
                    }
                    break;
                case 6:
                    Console.WriteLine("Exiting the application.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.Write("Do you want to continue? (Y/N): ");
            string continueChoice = Console.ReadLine();
            if (continueChoice.ToUpper() != "Y")
            {
                Console.WriteLine("Exiting the application.");
                return;
            }
        }
    }
}
