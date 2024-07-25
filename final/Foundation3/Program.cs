using System;
using System.Collections.Generic;

// Base class for Event
public class Event
{
    private string title;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Type: {GetType().Name}\nTitle: {title}\nDate: {date.ToShortDateString()}";
    }
}

// Derived class for Lecture
public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

// Derived class for Reception
public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Reception\nRSVP Email: {rsvpEmail}";
    }
}

// Derived class for OutdoorGathering
public class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather Forecast: {weatherForecast}";
    }
}

// Address class
public class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public string GetFullAddress()
    {
        return $"{street}, {city}, {state}, {country}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Elm St", "Chicago", "IL", "USA");
        Address address3 = new Address("789 Oak St", "Naperville", "IL", "USA");

        Lecture lecture = new Lecture("Tech Talk", "A talk on the latest in technology", new DateTime(2024, 8, 1), new TimeSpan(14, 0, 0), address1, "John Doe", 100);
        Reception reception = new Reception("Networking Event", "An event to network with professionals", new DateTime(2024, 8, 5), new TimeSpan(18, 0, 0), address2, "rsvp@example.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Community Picnic", "A picnic for the community", new DateTime(2024, 8, 10), new TimeSpan(12, 0, 0), address3, "Sunny with a chance of rain");

        List<Event> events = new List<Event> { lecture, reception, outdoorGathering };

        foreach (var ev in events)
        {
            Console.WriteLine("Standard Details:");
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine("Full Details:");
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine("Short Description:");
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine();
            Console.WriteLine("--------------------------");
        }
    }
}
