using System;

public class Job
{
    // Member
    public string _JobTitle;
    public string _company;
    public int _StartYear;
    public int _EndYear;

    // Method to display
    public void Display()
    {
        Console.WriteLine($"{_JobTitle} ({_company}) {_StartYear}-{_EndYear}");
    }
}