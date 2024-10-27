using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        bool quit = false;
        while (!quit)
        {
            try
            {
                Console.WriteLine($"\nYou have {_score} points.");
                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Save Goals");
                Console.WriteLine("4. Load Goals");
                Console.WriteLine("5. Record Event");
                Console.WriteLine("6. Quit");

                Console.Write("Select a choice from the menu: ");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Invalid option. Please enter a number between 1 and 6.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        CreateGoal();
                        break;
                    case 2:
                        ListGoals();
                        break;
                    case 3:
                        SaveGoals();
                        break;
                    case 4:
                        LoadGoals();
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        quit = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    private void CreateGoal()
    {
        try
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");

            Console.Write("Which type of goal would you like to create? ");
            if (!int.TryParse(Console.ReadLine(), out int goalType) || goalType < 1 || goalType > 3)
            {
                Console.WriteLine("Invalid selection. Please enter 1, 2, or 3.");
                return;
            }

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            if (!int.TryParse(Console.ReadLine(), out int points))
            {
                Console.WriteLine("Invalid points. Please enter a valid integer.");
                return;
            }

            Goal goal;
            switch (goalType)
            {
                case 1:
                    goal = new SimpleGoal(name, description, points);
                    break;
                case 2:
                    goal = new EternalGoal(name, description, points);
                    break;
                case 3:
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    if (!int.TryParse(Console.ReadLine(), out int target))
                    {
                        Console.WriteLine("Invalid target. Please enter a valid integer.");
                        return;
                    }
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    if (!int.TryParse(Console.ReadLine(), out int bonus))
                    {
                        Console.WriteLine("Invalid bonus. Please enter a valid integer.");
                        return;
                    }
                    goal = new ChecklistGoal(name, description, points, target, bonus);
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    return;
            }
            _goals.Add(goal);
            Console.WriteLine("Goal created successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while creating the goal: {ex.Message}");
        }
    }

    private void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to list.");
            return;
        }

        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available to record.");
            return;
        }

        try
        {
            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
            }

            Console.Write("Which goal did you accomplish? ");
            if (!int.TryParse(Console.ReadLine(), out int goalIndex) || goalIndex < 1 || goalIndex > _goals.Count)
            {
                Console.WriteLine("Invalid selection. Please choose a valid goal number.");
                return;
            }

            Goal goal = _goals[goalIndex - 1];
            int pointsEarned = goal.RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while recording the event: {ex.Message}");
        }
    }

    private void SaveGoals()
    {
        try
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving goals: {ex.Message}");
        }
    }

    private void LoadGoals()
    {
        try
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found. Please check the filename and try again.");
                return;
            }

            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(":");
                string type = parts[0];
                string details = parts[1];

                Goal goal;
                if (type == "Simple Goal")
                {
                    goal = SimpleGoal.FromString(details);
                }
                else if (type == "Eternal Goal")
                {
                    goal = EternalGoal.FromString(details);
                }
                else if (type == "Checklist Goal")
                {
                    goal = ChecklistGoal.FromString(details);
                }
                else
                {
                    Console.WriteLine($"Unknown goal type found in file: {type}");
                    continue;
                }

                _goals.Add(goal);
            }

            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading goals: {ex.Message}");
        }
    }
}