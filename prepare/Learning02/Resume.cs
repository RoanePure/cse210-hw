using System;
using System.Collections.Generic;

public class Resume
{
    // Member
    public string _name;
    public List<Job> _jobs =  new List<Job>();

    // Method to display
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        // Iterate
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}