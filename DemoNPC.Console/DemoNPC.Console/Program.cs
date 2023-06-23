using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        NPC npc = GenerateNPC();

        Console.WriteLine("Generated NPC:");
        Console.WriteLine($"Name: {npc.FirstName} {npc.LastName}");
        Console.WriteLine($"Race: {npc.Race}");
        Console.WriteLine($"Class: {npc.Class}");

        // Output additional properties
        Console.WriteLine($"Gender: {npc.Gender}");
        Console.WriteLine($"Age: {npc.Age}");
        Console.WriteLine($"Alignment: {npc.Alignment}");

        Console.ReadLine();
    }

    static NPC GenerateNPC()
    {
        Random random = new Random();

        string[] races = { "Human", "Elf", "Dwarf", "Halfling", "Orc" };
        string[] classes = { "Fighter", "Wizard", "Rogue", "Cleric", "Bard" };
        string[] genders = { "Male", "Female" };
        string[] alignments = { "Lawful Good", "Neutral Good", "Chaotic Good", "Lawful Neutral", "True Neutral", "Chaotic Neutral", "Lawful Evil", "Neutral Evil", "Chaotic Evil" };

        NPC npc = new NPC();
        npc.Race = races[random.Next(races.Length)]; // Pick a random race
        npc.Class = classes[random.Next(classes.Length)]; // Pick a random class
        npc.Gender = genders[random.Next(genders.Length)]; // Pick a random gender
        npc.Age = random.Next(18, 80); // Generate a random age between 18 and 80
        npc.Alignment = alignments[random.Next(alignments.Length)]; // Pick a random alignment

        // Generate name based on gender
        string nameFile = npc.Gender == "Male" ? "male_names.txt" : "female_names.txt";
        npc.FirstName = GenerateRandomFirstName(nameFile);
        npc.LastName = GenerateRandomLastName();


        // Add more properties and generate additional random attributes

        return npc;
    }

    static string GenerateRandomFirstName(string filename)
    {
        string[] names = File.ReadAllLines(filename);
        Random random = new Random();
        return names[random.Next(names.Length)];
    }

    static string GenerateRandomLastName()
    {
        string[] names = File.ReadAllLines("last_name.txt");
        Random random = new Random();
        return names[random.Next(names.Length)];
    }
}

