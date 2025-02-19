using System;
using System.Collections.Generic;

class Program
{
    // Task structure to hold task information
    struct Task
    {
        public string Name;
        public bool IsCompleted;

        public Task(string name)
        {
            Name = name;
            IsCompleted = false;
        }
    }

    static List<Task> toDoList = new List<Task>();  // List to hold tasks

    static void Main()
    {
        string userChoice;

        // Main loop to interact with the user
        do
        {
            try{
                Console.Clear();
            }
            catch(IOException ex){
                Console.WriteLine("Console could not be cleared. Error" + ex.Message);
            }
            Console.WriteLine("To-Do List Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. List Tasks");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            userChoice = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            switch (userChoice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ListTasks();
                    break;
                case "3":
                    MarkTaskAsCompleted();
                    break;
                case "4":
                    DeleteTask();
                    break;
                case "5":
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }

        } while (userChoice != "5");
    }

    static void AddTask()
    {
        Console.Write("Enter task name: ");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        string taskName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
        Task newTask = new Task(taskName);
#pragma warning restore CS8604 // Possible null reference argument.
        toDoList.Add(newTask);
        Console.WriteLine("Task added successfully!");
        Console.Read();
    }

    static void ListTasks()
    {
        Console.WriteLine("\nYour To-Do List:");
        if (toDoList.Count == 0)
        {
            Console.WriteLine("No tasks to display.");
        }
        else
        {
            for (int i = 0; i < toDoList.Count; i++)
            {
                string status = toDoList[i].IsCompleted ? "Completed" : "Pending";
                Console.WriteLine($"{i + 1}. {toDoList[i].Name} - {status}");
            }
        }
        Console.Read();
    }

    static void MarkTaskAsCompleted()
    {
        ListTasks();
        Console.Write("\nEnter the task number to mark as completed: ");
        int taskNumber;
        if (int.TryParse(Console.ReadLine(), out taskNumber) && taskNumber >= 1 && taskNumber <= toDoList.Count)
        {
            Task task = toDoList[taskNumber - 1];
            task.IsCompleted = true;
            Console.WriteLine("Task marked as completed!");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
         Console.Read();
    }

    static void DeleteTask()
    {
        ListTasks();
        Console.Write("\nEnter the task number to delete: ");
        int taskNumber;
        if (int.TryParse(Console.ReadLine(), out taskNumber) && taskNumber >= 1 && taskNumber <= toDoList.Count)
        {
            toDoList.RemoveAt(taskNumber - 1);
            Console.WriteLine("Task deleted successfully!");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
        Console.Read();
    }
}
