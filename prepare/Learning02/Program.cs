using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2015;
        job1._endYear = 2020;
        /*Console.WriteLine(job1._company);
        Console.WriteLine(job1._jobTitle);
        Console.WriteLine(job1._startYear);
        Console.WriteLine(job1._endYear);*/
        //job1.DisplayJobDetails();
        
        Job job2 = new() //VSC suggested this as a shortened way of creating a new instance. I'm testing it here!
        {
            _company = "Apple",
            _jobTitle = "Software Developer",
            _startYear = 2019,
            _endYear = 2023
        };
        /*Console.WriteLine("");
        Console.WriteLine(job2._company);
        Console.WriteLine(job2._jobTitle);
        Console.WriteLine(job2._startYear);
        Console.WriteLine(job2._endYear);*/
        //job2.DisplayJobDetails();



        Resume myResume = new Resume(); 
        myResume._name = "Martín Rantucho";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        
        myResume.Display();
    }
}