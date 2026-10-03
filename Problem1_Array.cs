// Name: Taganna, Kyle Aldrich P.
// Section: BSIT - 2 B

using System;

namespace TagannaKAP
{
    struct Student
    {
        public string StudentNumber;
        public string Name;
        public string Program;
        public int YearLevel;
    }

    class Problem1_Array
    {
        static Student[] students = new Student[10];
        static int studentCount = 0;

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nSTUDENT RECORD MANAGEMENT");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");
                
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddStudent(); break;
                    case "2": DisplayAll(); break;
                    case "3": SearchStudent(); break;
                    case "4": UpdateStudent(); break;
                    case "5": DeleteStudent(); break;
                    case "6": return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        static void AddStudent()
        {
            if (studentCount >= 10)
            {
                Console.WriteLine("Cannot add more students. Maximum capacity reached.");
                return;
            }

            Console.Write("Enter Student Number: ");
            string num = Console.ReadLine();
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Program: ");
            string program = Console.ReadLine();
            Console.Write("Enter Year Level: ");
            if (int.TryParse(Console.ReadLine(), out int year))
            {
                students[studentCount] = new Student { StudentNumber = num, Name = name, Program = program, YearLevel = year };
                studentCount++;
                Console.WriteLine("Student added successfully!");
            }
        }

        static void DisplayAll()
        {
            if (studentCount == 0) { Console.WriteLine("No students found."); return; }
            Console.WriteLine("\nSTUDENT RECORDS");
            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine($"{students[i].StudentNumber} - {students[i].Name} | Program: {students[i].Program} | Year Level: {students[i].YearLevel}");
            }
        }

        static void SearchStudent()
        {
            Console.Write("Enter Student Number to search: ");
            string num = Console.ReadLine();
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].StudentNumber == num)
                {
                    Console.WriteLine($"Found: {students[i].Name}, Program: {students[i].Program}, Year: {students[i].YearLevel}");
                    return;
                }
            }
            Console.WriteLine("Student not found.");
        }

        static void UpdateStudent()
        {
            Console.Write("Enter Student Number to update: ");
            string num = Console.ReadLine();
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].StudentNumber == num)
                {
                    Console.Write("Enter New Name: ");
                    students[i].Name = Console.ReadLine();
                    Console.Write("Enter New Program: ");
                    students[i].Program = Console.ReadLine();
                    Console.Write("Enter New Year Level: ");
                    if (int.TryParse(Console.ReadLine(), out int year)) students[i].YearLevel = year;
                    Console.WriteLine("Student updated successfully!");
                    return;
                }
            }
            Console.WriteLine("Student not found.");
        }

        static void DeleteStudent()
        {
            Console.Write("Enter Student Number to delete: ");
            string num = Console.ReadLine();
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].StudentNumber == num)
                {
                    for (int j = i; j < studentCount - 1; j++)
                    {
                        students[j] = students[j + 1];
                    }
                    studentCount--;
                    Console.WriteLine("Student deleted successfully!");
                    return;
                }
            }
            Console.WriteLine("Student not found.");
        }
    }
}