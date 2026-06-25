using System;
using System.Collections.Generic;
// A console application to calculate the total and average score of students in a class and determine their grades and pass/fail status.

//The Student class represents a student with properties for their full name, student ID, programme, level, and a dictionary to store their course scores.
namespace StudentResultsProcessingSystem;

public class StudentResultProcessingSystem
{
    // Properties to store student details
    public string? Full_Name { get; set; }
    public string? Student_Id { get; set; }
    public string? Programme { get; set; }
    public int Level { get; set; }
    public Dictionary<string, int> Scores { get; set; } = [];
}

public class Program
{
    public static void Main(string[] args)
    {
        List<StudentResultProcessingSystem> students = [];// This list stores student records
        string[] courses =
        [
            "Programming with C#",
            "Database Systems",
            "Computer Networks",
            "Web Development",
            "Mathematics for Computing"
        ];// Array to store the name of the courses
        while (true)
        {
            Console.WriteLine("===== STUDENT RESULTS PROCESSING SYSTEM =====");

            Console.WriteLine("1. Enter Student Results");
            Console.WriteLine("2. View Student Report");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option(Choose a number between 1 and 3): ");
            string? option = Console.ReadLine();
            if (option == "1")
            {
                students.Clear();

                for (int i = 1; i <= 3; i++)
                {
                    Console.WriteLine($"Enter details for Student {i}");

                    StudentResultProcessingSystem student = new();

                    Console.Write("Enter Full Name: ");
                    student.Full_Name = Console.ReadLine() ?? string.Empty;

                    Console.Write("Enter Student ID: ");
                    student.Student_Id = Console.ReadLine() ?? string.Empty;

                    Console.Write("Enter Programme: ");
                    student.Programme = Console.ReadLine() ?? string.Empty;

                    int level;
                    Console.Write("Enter Level: ");

                    while (!int.TryParse(Console.ReadLine(), out level))
                    {
                        Console.Write("Invalid input. Enter a valid level: ");
                    }

                    student.Level = level;

                    Console.WriteLine();
                    Console.WriteLine("Enter Course Scores");

                    foreach (string course in courses)
                    {
                        int score;

                        Console.Write($"Enter score for {course}: ");

                        while (!int.TryParse(Console.ReadLine(), out score) ||
                               score < 0 ||
                               score > 100)
                        {
                            Console.Write("Invalid score. Enter a score between 0 and 100: ");
                        }

                        student.Scores.Add(course, score);
                    }

                    students.Add(student);

                    Console.WriteLine();
                }

                Console.WriteLine("3 Students added successfully!");
            }
            else if (option == "2")
            {
                Console.WriteLine("===== STUDENT RESULTS REPORT =====");
                if (students.Count == 0)
                    Console.WriteLine("No student records found. Enter students first.");

                else
                {
                    foreach (StudentResultProcessingSystem student in students)
                    {
                        Console.WriteLine("***********************************");
                        Console.WriteLine($"Student Name: {student.Full_Name}");
                        Console.WriteLine($"Student ID: {student.Student_Id}");
                        Console.WriteLine($"Programme: {student.Programme}");
                        Console.WriteLine($"Level: {student.Level}");
                        Console.WriteLine();
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("Course Scores:");
                        int totalScore = 0;

                        foreach (var score in student.Scores)
                        {
                            Console.WriteLine($"{score.Key}: {score.Value}");
                            totalScore += score.Value;
                        }

                        double averageScore = (double)totalScore / student.Scores.Count;
                        Console.WriteLine();
                        Console.WriteLine($"Total Score: {totalScore}");
                        Console.WriteLine($"Average Score: {averageScore}");
                        if (averageScore >= 80)
                        {
                            Console.WriteLine("Grade: A");
                        }
                        else if (averageScore >= 70 && averageScore < 80)
                        {
                            Console.WriteLine("Grade: B");
                        }
                        else if (averageScore >= 60 && averageScore < 70)
                        {
                            Console.WriteLine("Grade: C");
                        }
                        else if (averageScore >= 50 && averageScore < 60)
                        {
                            Console.WriteLine("Grade: D");
                        }
                        else
                        {
                            Console.WriteLine("Grade: F");
                        }

                        if (averageScore >= 50)
                        {
                            Console.WriteLine("Status : Passed");
                        }
                        else
                        {
                            Console.WriteLine("Status : Failed");
                        }
                    }
                }
            }
            else if (option == "3")
            {
                Console.WriteLine("Thank you for using the Student Results Processing System");
                break;
            }

            else
                Console.WriteLine("Invalid option. Try again.");

        }
    }
}