using System;
using System.Collections.Generic;

// Base class for all goals
abstract class Goal
{
    public string Title { get; set; }
    public int Value { get; set; }
    public bool IsComplete { get; set; }

    public Goal(string title, int value)
    {
        Title = title;
        Value = value;
        IsComplete = false;
    }

    // Method to mark a goal as complete and update the score
    public virtual void CompleteGoal(ref int score)
    {
        if (!IsComplete)
        {
            score += Value;
            IsComplete = true;
        }
    }

    public abstract string GetGoalStatus();
}

// Simple goal class
class SimpleGoal : Goal
{
    public SimpleGoal(string title, int value) : base(title, value) { }

    public override string GetGoalStatus()
    {
        return IsComplete ? "[X]" : "[ ]";
    }
}

// Eternal goal class
class EternalGoal : Goal
{
    public EternalGoal(string title, int value) : base(title, value) { }

    public override void CompleteGoal(ref int score)
    {
        score += Value;
    }

    public override string GetGoalStatus()
    {
        return "[X]";
    }
}

// Checklist goal class
class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CompletedCount { get; set; }

    public ChecklistGoal(string title, int value, int targetCount) : base(title, value)
    {
        TargetCount = targetCount;
        CompletedCount = 0;
    }

    public override void CompleteGoal(ref int score)
    {
        if (!IsComplete)
        {
            score += Value;
            CompletedCount++;

            if (CompletedCount >= TargetCount)
            {
                score += Value * 10; // Bonus points for completing all checklist items
                IsComplete = true;
            }
        }
    }

    public override string GetGoalStatus()
    {
        return $"Completed {CompletedCount}/{TargetCount} times";
    }
}

// Program class
class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main(string[] args)
    {
        bool exit = false;

        LoadGoalsAndScore(); // Load saved goals and score

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("---------------------");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. Record goal completion");
            Console.WriteLine("3. Show goals");
            Console.WriteLine("4. Show score");
            Console.WriteLine("5. Save goals and score");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordGoalCompletion();
                    break;
                case "3":
                    ShowGoals();
                    break;
                case "4":
                    ShowScore();
                    break;
                case "5":
                    SaveGoalsAndScore();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    static void CreateGoal()
    {
        Console.Write("Enter goal title: ");
        string title = Console.ReadLine();
        Console.Write("Enter goal value: ");
        int value = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple goal");
        Console.WriteLine("2. Eternal goal");
        Console.WriteLine("3. Checklist goal");

        Console.Write("Enter goal type: ");
        string choice = Console.ReadLine();
        Console.WriteLine();

        switch (choice)
        {
            case "1":
                goals.Add(new SimpleGoal(title, value));
                Console.WriteLine("Simple goal created.");
                break;
            case "2":
                goals.Add(new EternalGoal(title, value));
                Console.WriteLine("Eternal goal created.");
                break;
            case "3":
                Console.Write("Enter target count: ");
                int targetCount = Convert.ToInt32(Console.ReadLine());
                goals.Add(new ChecklistGoal(title, value, targetCount));
                Console.WriteLine("Checklist goal created.");
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    static void RecordGoalCompletion()
    {
        Console.WriteLine("Select a goal to complete:");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Title}");
        }

        Console.Write("Enter goal number: ");
        int goalNumber = Convert.ToInt32(Console.ReadLine());
        int index = goalNumber - 1;

        if (index >= 0 && index < goals.Count)
        {
            Goal goal = goals[index];
            goal.CompleteGoal(ref score);
            Console.WriteLine($"Goal '{goal.Title}' completed!");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    static void ShowGoals()
    {
        Console.WriteLine("Goals:");
        Console.WriteLine("------");

        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            Console.WriteLine($"{i + 1}. {goal.GetGoalStatus()} {goal.Title}");
        }
    }

    static void ShowScore()
    {
        Console.WriteLine($"Score: {score}");
    }

    static void SaveGoalsAndScore()
    {
        // Save goals and score to a file or database
        Console.WriteLine("Goals and score saved.");
    }

    static void LoadGoalsAndScore()
    {
        // Load goals and score from a file or database
        Console.WriteLine("Goals and score loaded.");
    }
}
