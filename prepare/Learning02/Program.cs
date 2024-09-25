using System;

class Program
{
    static void Main(string[] args)
    {
        // First Job
        Job job1 = new Job();
        job1._JobTitle = "Sotware Engineer";
        job1._company = "Microsoft";
        job1._StartYear = 2019;
        job1._EndYear = 2022;

        // Second Job
        Job job2 = new Job();
        job2._JobTitle = "Manager";
        job2._company = "Apple";
        job2._StartYear = 2022;
        job2._EndYear = 2023;

        // Create resume
        Resume MyResume =  new Resume();
        MyResume._name ="Allison Rose";

        // Add jobs to resume
        MyResume._jobs.Add(job1);
        MyResume._jobs.Add(job2);

        // Display resume
        MyResume.Display();
    }
}