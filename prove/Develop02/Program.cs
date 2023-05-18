using System;


   class JournalProgram
  {
    static string journalFileName = "journal.txt";
    static string journalContent = "";

    static void Main()
    {
        LoadJournal();
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("Options:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("Choose an option:");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteEntry();
                    break;
                case "2":
                    DisplayEntries();
                    break;
                case "3":
                    LoadJournal();
                    break;
                case "4":
                    SaveJournal();
                    break;
                case "5":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void WriteEntry()
    {
        Console.WriteLine("Enter your journal entry:");
        string entry = Console.ReadLine();
        journalContent += $"{entry}\n";
    }

    static void DisplayEntries()
    {
        if (!string.IsNullOrEmpty(journalContent))
        {
            Console.WriteLine("Journal Entries:");
            Console.WriteLine(journalContent);
        }
        else
        {
            Console.WriteLine("No entries to display.");
        }
    }

    static void LoadJournal()
    {
        if (File.Exists(journalFileName))
        {
            journalContent = File.ReadAllText(journalFileName);
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("No journal file found.");
        }
    }

    static void SaveJournal()
    {
        File.WriteAllText(journalFileName, journalContent);
        Console.WriteLine("Journal saved successfully.");
    }
}
