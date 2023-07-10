using System;
using System.Threading;

abstract class MindfulnessActivity
{
    public string ActivityName { get; set; }
    public string ActivityDescription { get; set; }
    public int Duration { get; set; }

    public virtual void StartActivity()
    {
        Console.WriteLine($"Starting the {ActivityName} activity.");
        Console.WriteLine(ActivityDescription);
        Console.WriteLine("Enter the duration for the activity in seconds:");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        CountDown(3);
        Thread.Sleep(3000);
    }

    public abstract void DoActivity();

    public virtual void EndActivity()
    {
         Console.WriteLine("You have done a good job!");
       
        Console.WriteLine($"You have completed the {ActivityName} activity for {Duration} seconds.");
        
    }

    protected void CountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
    }
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        ActivityName = "Breathing";
        ActivityDescription = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void DoActivity()
    {
        StartActivity();
        for (int i = 0; i < Duration; i++)
        {
            Console.WriteLine(i % 2 == 0 ? "Breathe in..." : "Breathe out...");
            CountDown(3);
            
        }
        EndActivity();
    }
}

class ReflectionActivity : MindfulnessActivity
{
    public ReflectionActivity()
    {
        ActivityName = "Reflection";
        ActivityDescription = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public override void DoActivity()
    {
        StartActivity();
        string[] prompts = new string[]
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        Random rnd = new Random();
        Console.WriteLine(prompts[rnd.Next(prompts.Length)]);
        Thread.Sleep(Duration * 1000);
        EndActivity();
    }
}

class ListingActivity : MindfulnessActivity
{
    public ListingActivity()
    {
        ActivityName = "Listing";
        ActivityDescription = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void DoActivity()
    {
        StartActivity();
        string[] prompts = new string[]
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        Random rnd = new Random();
        Console.WriteLine(prompts[rnd.Next(prompts.Length)]);
        Thread.Sleep(Duration * 1000);
        EndActivity();
    }
}

class Program
{
    static void Main()
    {
        MindfulnessActivity[] activities = new MindfulnessActivity[]
        {
            new BreathingActivity(),
            new ReflectionActivity(),
            new ListingActivity()
        };
        Console.WriteLine("Select an activity:");
        for (int i = 0; i < activities.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {activities[i].ActivityName}");
        }
        int activityNumber = int.Parse(Console.ReadLine());
        activities[activityNumber - 1].DoActivity();
    }
}
