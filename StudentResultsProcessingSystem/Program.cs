using System;
using System.Collections.Generic;
// A console application to calculate the total and average score of students in a class and determine their grades and pass/fail status.

//The Student class represents a student with properties for their full name, student ID, programme, level, and a dictionary to store their course scores.
namespace StudentResultsProcessingSystem;

public class StudentResultProcessingSystem
{
    // Properties to store student details
    public string? FullName { get; set; }
    public string? StudentId { get; set; }
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
            string option = Console.ReadLine();
            if (option == "1")
            {
                students.Clear();
                for (int i = 1; i <= 3; i++)
                {
                    Console.WriteLine($"Enter details for Student {i}");
                    StudentResultProcessingSystem student = new StudentResultProcessingSystem();// Student object
                    Console.Write("Enter Full Name: ");
                    student.FullName = Console.ReadLine();
                    Console.Write("Enter Student ID: ");
                    student.StudentId = Console.ReadLine();
                    Console.Write("Enter Programme: ");
                    student.Programme = Console.ReadLine();
                    Console.Write("Enter Level: ");
                    student.Level = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Enter Course Scores");
                    foreach (string course in courses)
                    {
                        Console.Write($"Enter score for {course}: ");
                        int score = int.Parse(Console.ReadLine());
                        while (score < 0 || score > 100)
                        {
                            Console.WriteLine("Invalid score. Please enter a score between 0 and 100.");
                            Console.Write($"Enter score for {course}: ");
                            score = int.Parse(Console.ReadLine());
                        }
                        student.Scores.Add(course, score);
                    }
                    students.Add(student);
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
                        Console.WriteLine($"Student Name: {student.FullName}");
                        Console.WriteLine($"Student ID: {student.StudentId}");
                        Console.WriteLine($"Programme: {student.Programme}");
                        Console.WriteLine($"Level: {student.Level}");
                        Console.WriteLine();
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("Course Scores:");
                        int AverageScore = 0;
                        int TotalScore = 0;
                        foreach (var score in student.Scores)
                        {
                            Console.WriteLine($"{score.Key}: {score.Value}");
                            TotalScore += score.Value;
                            AverageScore = TotalScore / student.Scores.Count;
                        }
                        Console.WriteLine();
                        Console.WriteLine($"Total Score: {TotalScore}");
                        Console.WriteLine($"Average Score: {AverageScore}");
                        if (AverageScore >= 80)
                        {
                            Console.WriteLine("Grade: A");
                        }
                        else if (AverageScore >= 70 && AverageScore < 80)
                        {
                            Console.WriteLine("Grade: B");
                        }
                        else if (AverageScore >= 60 && AverageScore < 70)
                        {
                            Console.WriteLine("Grade: C");
                        }
                        else if (AverageScore >= 50 && AverageScore < 60)
                        {
                            Console.WriteLine("Grade: D");
                        }
                        else
                        {
                            Console.WriteLine("Grade: F");
                        }

                        if (AverageScore >= 50)
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