using System.Text.RegularExpressions;
using ASM2_Design_Pattern.Pet_Store;

namespace ASM2_Design_Pattern;

public class PetStore
{
    public const int CLEAR_SCR = 0;
    public const int ADD_PET = 1;
    public const int EDIT_PET = 2;
    public const int REMOVE_PET = 3;
    public const int FIND_PET = 4;
    public const int VIEW_PETLIST = 5;
    public const int EXIT = 6;
    public static PetManager petManager;
    
    public static void Main(string[] args)
    {
        petManager = new PetManager();
        int command = 0;
        while (command != EXIT)
        {
            PrintCommandMenu();
            
            if (int.TryParse(Console.ReadLine(), out command)) {
                switch (command) {
                    case CLEAR_SCR:
                        Console.Clear();
                        break;
                    case ADD_PET:
                        // Add a new pet to the store
                        AddPet();
                        break;
                    case EDIT_PET:
                        // Edit an existing pet in the store
                        EditPet();
                        break;
                    case REMOVE_PET:
                        // Remove a pet from the store
                        RemovePet();
                        break;
                    case FIND_PET:
                        // Find a pet in the store
                        FindPet();
                        break;
                    case VIEW_PETLIST:
                        // View the list of pets in the store
                        ViewPetList();
                        break;
                    case 6:
                        // Exit the loop and the application
                        Exit();
                        Console.WriteLine("Exiting the Pet Store application...");
                        break;
                    default:
                        // Invalid command entered
                        Console.WriteLine("Invalid command. Please choose a valid command.");
                        break;
                }
            } else {
                Console.WriteLine("Invalid input. Please enter a valid command number.");
            }
        }
    }

    public static void PrintCommandMenu()
    {
        Console.WriteLine("-------------------*-------------------");
        Console.WriteLine("Please choose a command:");
        Console.WriteLine("1 - Add a pet");
        Console.WriteLine("2 - Edit a pet");
        Console.WriteLine("3 - Remove a pet");
        Console.WriteLine("4 - Find a pet");
        Console.WriteLine("5 - View the list of pets");
        Console.WriteLine("6 - Exit");
        Console.WriteLine("-------------------*-------------------");
    }

    public static void AddPet()
    {
        try
        {
            Console.WriteLine("Please enter: type name age gender");
            string[] input = Regex.Split(Console.ReadLine().Trim(),(@"\s+"));
            petManager.AddPet(input[0], input[1], int.Parse(input[2]), input[3]);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public static void EditPet()
    {
        Console.WriteLine("Please Enter Old Pet Information");
        string oldInformation = Console.ReadLine();;
        Console.WriteLine("Please Enter New Pet Information");
        string newInformation = Console.ReadLine();
        petManager.EditPet(oldInformation, newInformation);
    }

    public static void RemovePet()
    {
        Console.WriteLine("Please enter: type name age gender");
        string[] input = Regex.Split(Console.ReadLine().Trim(),(@"\s+"));
        petManager.RemovePet(input[0], input[1], int.Parse(input[2]), input[3]);
    }

    public static void FindPet()
    {
        Console.WriteLine("Please enter name to find:");
        string name = Console.ReadLine();
        petManager.FindPet(name);
    }

    public static void ViewPetList()
    {
        petManager.ViewPetList();
    }

    public static void Exit()
    {
        petManager.SaveFile();
    }

    public static void SaveFile()
    {
        petManager.SaveFile();
    }
}