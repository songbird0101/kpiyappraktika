using System;

class Coach
{
    public string Name { get; set; }

    public Coach(string name)
    {
        Name = name;
    }

    public void Train(Athlete athlete)
    {
        Console.WriteLine($"Тренер {Name} тренирует спортсмена {athlete.Name}");
    }
}

class Equipment
{
    public string Type { get; private set; }

    public Equipment(string type)
    {
        Type = type;
    }

    public void Use()
    {
        Console.WriteLine($"Используется экипировка: {Type}");
    }
}

class Team
{
    public string Name { get; set; }

    public Team(string name)
    {
        Name = name;
    }

    public void AddAthlete(Athlete athlete)
    {
        Console.WriteLine($"Спортсмен {athlete.Name} присоединился к команде {Name}");
    }
}

class Athlete
{
    public string Name { get; set; }

    private Coach[] coaches;

    private Equipment equipment;

    public Team Team { get; set; }

    public Athlete(string name, Coach[] coaches, string equipmentType)
    {
        Name = name;
        this.coaches = coaches;
        equipment = new Equipment(equipmentType); 
    }

    public void Train()
    {
        Console.WriteLine($"\nСпортсмен {Name} начинает тренировку:");
        equipment.Use();
        foreach (var coach in coaches)
        {
            coach.Train(this);
        }
        if (Team != null)
            Console.WriteLine($"Тренируется в команде {Team.Name}");
        else
            Console.WriteLine("Тренируется индивидуально");
    }
}

class Program
{
    static void Main()
    {
        Coach[] coaches1 = new Coach[] { new Coach("Иван"), new Coach("Петр") };
        Coach[] coaches2 = new Coach[] { new Coach("Сергей") };

        Athlete athlete1 = new Athlete("Алексей", coaches1, "Беговые кроссовки");
        Athlete athlete2 = new Athlete("Мария", coaches2, "Спортивная форма");

        Team team = new Team("Сборная города");
        athlete1.Team = team;
        team.AddAthlete(athlete1);

        Athlete[] athletes = { athlete1, athlete2 };

        foreach (var athlete in athletes)
        {
            athlete.Train();
        }
    }
}