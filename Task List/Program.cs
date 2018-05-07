using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> taskList = new List<Task>(); //List that will be used to hold the task objects

            //present the menu method
            Menu();
            string input = Console.ReadLine();
            int num;
            bool valid = int.TryParse(input, out num);
                while (!valid)
                {
                    Console.WriteLine($"Error: {input} is not a valid number. Please try again.");
                    Menu();
                    input = Console.ReadLine();
                    valid = int.TryParse(input, out num);
                }
            while (num != 5)
            {
                switch (num)
                {
                    case 1://List all the items on the task list
                        Console.WriteLine("LIST ITEMS");
                        Console.WriteLine("=============");
                        string done = "n";
                        while (done == "n")
                        {
                            
                            {
                                for (int i = 0; i < taskList.Count; i++)
                                {                                                                        
                                    Console.WriteLine($"TASK {i+1}: ");
                                    Console.WriteLine("~~~~~~~~~~");
                                    Console.WriteLine($"User to complete task: {taskList[i].username}");
                                    Console.WriteLine($"Description of task: {taskList[i].description}");
                                    Console.WriteLine($"Due date for task: {taskList[i].duedate}");
                                    Console.WriteLine($"Task completed? {taskList[i].completed}");
                                    

                                }                                                                
                                //figure out how to list all the objects in a lists along with a number 
                                
                            }
                            Console.WriteLine("\nGo back to main menu? (y/n)");
                            done = Console.ReadLine();
                                while (done.ToLower() != "y" && done.ToLower() != "n")
                                {
                                    Console.WriteLine("Error: That was not an option");
                                    Console.WriteLine("Go back to main menu? (y/n)");
                                    done = Console.ReadLine();
                                }
                        }
                        Menu();
                        input = Console.ReadLine();
                        valid = int.TryParse(input, out num);

                        break;
                    case 2: //Add to task list
                        Console.WriteLine("ADD ITEM TO LIST: ");
                        Console.WriteLine("===================");
                        string cont = "Y";
                        while (cont.ToUpper() == "Y")
                        {
                            Console.WriteLine("Enter user to complete task: ");
                            string user = Console.ReadLine();
                            Console.WriteLine("Enter description of task: ");
                            string description = Console.ReadLine();
                            Console.WriteLine("Enter due date of task: ");
                            string dateInput = Console.ReadLine();
                                DateTime duedate;
                                bool validDate = DateTime.TryParse(dateInput, out duedate);
                                while (!validDate)
                                {
                                    Console.WriteLine("Error that was not a valid date. Please try again.");
                                    Console.WriteLine("Enter due date of task: ");
                                    dateInput = Console.ReadLine();                                
                                    validDate = DateTime.TryParse(dateInput, out duedate);

                                }
                            taskList.Add(new Task(user, description, duedate)); //creates new task object and puts it in the list 
                            Console.WriteLine("Item Added! Add another? (y/n)");
                            cont = Console.ReadLine();
                            while (cont.ToLower() != "y" && cont.ToLower() != "n")
                            {
                                Console.WriteLine("Error: That was not an option");
                                Console.WriteLine("Add another item? (y/n)");
                                cont = Console.ReadLine();
                            }
                        }
                        Menu();
                        input = Console.ReadLine();
                        valid = int.TryParse(input, out num);

                        break;
                    case 3://delete task
                        Console.WriteLine("DELETE ITEM FROM LIST: ");
                        Console.WriteLine("======================");
                        string another = "y";
                        while (another.ToLower() == "y")
                        {
                            Console.WriteLine($"Enter the number of the item you want to delete: 1-{taskList.Count}");
                            string item = Console.ReadLine();
                            int delNum;
                            bool validNum = int.TryParse(item, out delNum);
                                while (!validNum || delNum > taskList.Count || delNum < 0) //while loop to test whether number of item to delete is valid
                                {                                    
                                    Console.WriteLine("Error: That was not a valid number. Please try again.");
                                    Console.WriteLine($"Enter the number of the item you want to enter: 1-{taskList.Count}");
                                    item = Console.ReadLine();
                                    validNum = int.TryParse(item, out delNum);
                                }

                            taskList.RemoveAt(delNum-1);

                            Console.WriteLine("Item deleted! Delete another? (y/n)");
                            another = Console.ReadLine();
                            while (another.ToLower() != "y" && another.ToLower() != "n")
                            {
                                Console.WriteLine("Error: That was not an option");
                                Console.WriteLine("Delete another? (y/n)");
                                another = Console.ReadLine();
                            }
                        }
                        Menu();
                        input = Console.ReadLine();
                        valid = int.TryParse(input, out num);
                        break;
                    case 4://mark task complete
                        Console.WriteLine("MARK ITEM COMPLETE: ");
                        Console.WriteLine("====================");
                        string again = "y";
                        while(again.ToLower() == "y")
                        {
                            Console.WriteLine($"Enter the number of the item you want to mark complete: 1-{taskList.Count}");
                            string item = Console.ReadLine();
                            int completedNum;
                            bool validCom = int.TryParse(item, out completedNum);
                            while (!validCom || completedNum > taskList.Count || completedNum < 0) //while loop to test whether number of item to delete is valid
                            {
                                Console.WriteLine("Error: That was not a valid number. Please try again.");
                                Console.WriteLine($"Enter the number of the item you want to enter: 1-{taskList.Count}");
                                item = Console.ReadLine();
                                validCom = int.TryParse(item, out completedNum);
                            }

                            taskList[completedNum - 1].completed = true;

                            Console.WriteLine("Item marked complete! Mark another? (y/n)");
                            again = Console.ReadLine();
                            while (again.ToLower() != "y" && again.ToLower() != "n")
                            {
                                Console.WriteLine("Error: That was not an option");
                                Console.WriteLine("Mark another? (y/n)");
                                again = Console.ReadLine();
                            }
                        }
                        Menu();
                        input = Console.ReadLine();
                        valid = int.TryParse(input, out num);
                        break;
                    default:
                        Console.WriteLine("Error: You entered an invalid option. Please try again.");
                        Menu();
                        input = Console.ReadLine();
                        valid = int.TryParse(input, out num);
                        break;
                

                }

            }
            
            
            //Pause before Close
            Console.WriteLine("Press any key to exit. .");
            Console.ReadKey();

        }
        static void Menu()
        {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("=============");
            Console.WriteLine("1 - List Tasks");
            Console.WriteLine("2 - Add Task");
            Console.WriteLine("3 - Delete Task");
            Console.WriteLine("4 - Mark Task Complete");
            Console.WriteLine("5 - Quit");

        }


    }
}
