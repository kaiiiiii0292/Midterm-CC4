// Name: Taganna, Kyle Aldrich P.
// Section: BSIT - 2 B

using System;
using System.Collections.Generic;

namespace TagannaKAP
{
    struct StudentRequest
    {
        public string StudentNumber;
        public string StudentName;
        public string RequestType;
    }

    class Problem3_Queue
    {
        static Queue<StudentRequest> requestQueue = new Queue<StudentRequest>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nSTUDENT REQUEST QUEUE");
                Console.WriteLine("1. Add Request");
                Console.WriteLine("2. View Pending Requests");
                Console.WriteLine("3. Process Request");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddRequest(); break;
                    case "2": ViewRequests(); break;
                    case "3": ProcessRequest(); break;
                    case "4": return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        static void AddRequest()
        {
            Console.Write("Enter Student Number: ");
            string num = Console.ReadLine();
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Request Type (e.g., Certificate of Enrollment, Student ID): ");
            string type = Console.ReadLine();

            requestQueue.Enqueue(new StudentRequest { StudentNumber = num, StudentName = name, RequestType = type });
            Console.WriteLine("Request added successfully!");
        }

        static void ViewRequests()
        {
            if (requestQueue.Count == 0)
            {
                Console.WriteLine("No pending requests.");
                return;
            }

            Console.WriteLine("\nPENDING REQUESTS:");
            int count = 1;
            foreach (var req in requestQueue)
            {
                Console.WriteLine($"{count}. {req.StudentName} - {req.RequestType}");
                count++;
            }
        }

        static void ProcessRequest()
        {
            if (requestQueue.Count == 0)
            {
                Console.WriteLine("No pending requests to process.");
                return;
            }

            StudentRequest processed = requestQueue.Dequeue();
            Console.WriteLine($"Processing request for {processed.StudentName}: {processed.RequestType}");
            Console.WriteLine("Request processed successfully!");
        }
    }
}