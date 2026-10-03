// Name: Taganna, Kyle Aldrich P.
// Section: BSIT - 2 B

using System;
using System.Collections.Generic;

namespace TagannaKAP
{
    struct Student
    {
        public string StudentNumber;
        public string Name;
        public string Program;
        public int YearLevel;
    }

    class Problem2_Dictionary
    {
        static Dictionary<string, Student> studentDictionary = new Dictionary<string, Student>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nSTUDENT LOOKUP USING DICTIONARY");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Search Student");
                Console.WriteLine("3. Display All Students");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");
                
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddStudent(); break;
                    case "2": SearchStudent(); break;
                    case "3": DisplayAll(); break;
                    case "4": return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        static void AddStudent()
        {
            Console.Write("Enter Student Number: ");
            string num = Console.ReadLine();
            
            if (studentDictionary.ContainsKey(num))
            {
                Console.WriteLine("Error: Student Number already exists.");
                return;
            }

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Program: ");
            string program = Console.ReadLine();
            Console.Write("Enter Year Level: ");
            
            if (int.TryParse(Console.ReadLine(), out int year))
            {
                Student newStudent = new Student { StudentNumber = num, Name = name, Program = program, YearLevel = year };
                studentDictionary.Add(num, newStudent);
                Console.WriteLine("Student added successfully!");
            }
        }

        static void SearchStudent()
        {
            Console.Write("Enter Student Number to search: ");
            string num = Console.ReadLine();

            if (studentDictionary.TryGetValue(num, out Student student))
            {
                Console.WriteLine("Student Found!");
                Console.WriteLine($"Student Number: {student.StudentNumber}");
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine($"Program: {student.Program}");
                Console.WriteLine($"Year Level: {student.YearLevel}");
            }
            else
            {
                Console.WriteLine("Student Number does not exist.");
            }
        }

        static void DisplayAll()
        {
            if (studentDictionary.Count == 0) { Console.WriteLine("No students found."); return; }
            Console.WriteLine("\nALL STUDENTS:");
            foreach (var kvp in studentDictionary)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value.Name}");
            }
        }
    }
}