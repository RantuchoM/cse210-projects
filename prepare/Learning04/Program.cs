using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new("Martín Rantucho","Programming with Classes");
        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine();

        MathAssignment mathAssign = new("Juan Pérez","This Topic","9.3","13.3");
        Console.WriteLine(mathAssign.GetSummary());
        Console.WriteLine(mathAssign.GetHomeworkList());
        Console.WriteLine();
        
        WritingAssignment wriAssign = new("Dora Ríos","Another Topic","This is a new title");
        Console.WriteLine(wriAssign.GetSummary());
        Console.WriteLine(wriAssign.GetWritingInformation());
    }
}