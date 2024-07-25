using System;
using System.Collections.Generic;

// Base class for Activity
public abstract class Activity
{
    private DateTime date;
    private int lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        this.date = date;
        this.lengthInMinutes = lengthInMinutes;
    }

    public int LengthInMinutes => lengthInMinutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{date.ToShortDateString()} {GetType().Name} ({lengthInMinutes} min): Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace {GetPace():0.0} min per mile";
    }
}

// Derived class for Running
public class Running : Activity
{
    private double distance; // in miles

    public Running(DateTime date, int lengthInMinutes, double distance)
        : base(date, lengthInMinutes)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;
    public override double GetSpeed() => (distance / LengthInMinutes) * 60;
    public override double GetPace() => LengthInMinutes / distance;
}

// Derived class for Cycling
public class Cycling : Activity
{
    private double speed; // in mph

    public Cycling(DateTime date, int lengthInMinutes, double speed)
        : base(date, lengthInMinutes)
    {
        this.speed = speed;
    }

    public override double GetDistance() => (speed * LengthInMinutes) / 60;
    public override double GetSpeed() => speed;
    public override double GetPace() => 60 / speed;
}

// Derived class for Swimming
public class Swimming : Activity
{
    private int laps;
    private const double LapDistanceInMiles = 50 / 1000.0 * 0.62; // Convert meters to miles

    public Swimming(DateTime date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        this.laps = laps;
    }

    public override double GetDistance() => laps * LapDistanceInMiles;
    public override double GetSpeed() => (GetDistance() / LengthInMinutes) * 60;
    public override double GetPace() => LengthInMinutes / GetDistance();
}

class Program
{
    static void Main(string[] args)
    {
        var activities = new List<Activity>
        {
            new Running(new DateTime(2024, 7, 20), 30, 3.0),
            new Cycling(new DateTime(2024, 7, 21), 45, 15.0),
            new Swimming(new DateTime(2024, 7, 22), 60, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}
