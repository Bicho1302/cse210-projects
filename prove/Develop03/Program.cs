using System;



public class Program
{
    public static void Main()
    {
        Console.WriteLine("Welcome to the Scripture Hiding Program!");

        // Create a new instance of the Scripture class
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his only Son, " +
            "that whoever believes in him should not perish but have eternal life.");

        // Clear the console screen and display the complete scripture
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        // Prompt the user to press enter or type quit
        string input;
        do
        {
            Console.WriteLine("Press Enter to hide some words or type 'quit' to exit.");
            input = Console.ReadLine();

            if (input == "")
            {
                // Hide some random words in the scripture
                scripture.HideRandomWord();

                // Clear the console screen and display the modified scripture
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
            }

        } while (input != "quit");

        Console.WriteLine("Thank you for using the Scripture Hiding Program!");
    }
}

public class Scripture
{
    private string reference;
    private List<Word> words;
    private List<int> hiddenIndices;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.words = new List<Word>();
        this.hiddenIndices = new List<int>();

        string[] wordArray = text.Split(' ');
        for (int i = 0; i < wordArray.Length; i++)
        {
            words.Add(new Word(wordArray[i]));
        }
    }

    public string GetDisplayText()
    {
        string displayText = reference + " ";
        for (int i = 0; i < words.Count; i++)
        {
            if (hiddenIndices.Contains(i))
            {
                displayText += "***** ";
            }
            else
            {
                displayText += words[i].Text + " ";
            }
        }
        return displayText;
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        int randomIndex;
        do
        {
            randomIndex = random.Next(0, words.Count);
        } while (hiddenIndices.Contains(randomIndex));

        hiddenIndices.Add(randomIndex);
    }
}

public class Word
{
    public string Text { get; set; }

    public Word(string text)
    {
        Text = text;
    }
}
