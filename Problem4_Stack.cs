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

    struct Operation
    {
        public string Action;
        public string StudentNumber;
        public string StudentName;
    }

    class Problem4_Stack
    {
        static Student[] students = new Student[10];
        static int studentCount = 0;
        static Stack<Operation> operationHistory = new Stack<Operation>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nSYSTEM WITH OPERATION HISTORY");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Update Student");
                Console.WriteLine("3. Delete Student");
                Console.WriteLine("4. View Operation History");
                Console.WriteLine("5. View Last Operation");
                Console.WriteLine("6. Remove Last Operation");
                Console.WriteLine("7. Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddStudent(); break;
                    case "2": UpdateStudent(); break;
                    case "3": DeleteStudent(); break;
                    case "4": ViewHistory(); break;
                    case "5": ViewLastOperation(); break;
                    case "6": RemoveLastOperation(); break;
                    case "7": return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        static void AddStudent()
        {
            if (studentCount >= 10) { Console.WriteLine("Capacity reached."); return; }
            Console.Write("Enter Student Number: ");
            string num = Console.ReadLine();
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            
            students[studentCount] = new Student { StudentNumber = num, Name = name };
            studentCount++;

            operationHistory.Push(new Operation { Action = "Added", StudentNumber = num, StudentName = name });
            Console.WriteLine("Student added successfully!");
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
                    string oldName = students[i].Name;
                    students[i].Name = Console.ReadLine();
                    
                    operationHistory.Push(new Operation { Action = "Updated", StudentNumber = num, StudentName = oldName });
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
                    string deletedName = students[i].Name;
                    for (int j = i; j < studentCount - 1; j++)
                    {
                        students[j] = students[j + 1];
                    }
                    studentCount--;

                    operationHistory.Push(new Operation { Action = "Deleted", StudentNumber = num, StudentName = deletedName });
                    Console.WriteLine("Student deleted successfully!");
                    return;
                }
            }
            Console.WriteLine("Student not found.");
        }

        static void ViewHistory()
        {
            if (operationHistory.Count == 0)
            {
                Console.WriteLine("No recorded operations.");
                return;
            }

            Console.WriteLine("\nOPERATION HISTORY");
            int index = 1;
            
            // To display from oldest to newest based on the sample output, 
            // we convert the stack to an array and reverse it, 
            // or iterate directly which goes top-to-bottom.
            // Sample shows 1. Added 2. Added 3. Updated, so it displays chronologically.
            var historyArray = operationHistory.ToArray();
            Array.Reverse(historyArray);

            foreach (var op in historyArray)
            {
                Console.WriteLine($"{index}. {op.Action} {op.StudentName}");
                index++;
            }
        }

        static void ViewLastOperation()
        {
            if (operationHistory.Count > 0)
            {
                Operation last = operationHistory.Peek();
                Console.WriteLine($"Last Operation: {last.Action} {last.StudentName}");
            }
            else
            {
                Console.WriteLine("No recorded operations.");
            }
        }

        static void RemoveLastOperation()
        {
            if (operationHistory.Count > 0)
            {
                operationHistory.Pop();
                Console.WriteLine("Last operation removed successfully!");
            }
            else
            {
                Console.WriteLine("No operations to remove.");
            }
        }
    }
}