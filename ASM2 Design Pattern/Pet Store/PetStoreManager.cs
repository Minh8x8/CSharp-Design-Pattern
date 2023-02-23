using System.Text.RegularExpressions;
using ASM2_Design_Pattern.Product;

namespace ASM2_Design_Pattern.Pet_Store;

public class PetManager
{
    private PetInventory _petInventory;

    public PetManager()
    {
        _petInventory = new PetInventory();
    }
    

    public void AddPet(string type, string name, int age, string gender)
    {
        IPet pet = _petInventory.CreatePet(type, name, age, gender);
        _petInventory.AddPet(pet);
    }

    public void EditPet(string oldPetInformation, string newPetInformation)
    {
        string[] oldPetInfor = Regex.Split(oldPetInformation,@" +");	
        string[] newPetInfor = Regex.Split(newPetInformation,@" +");
        if (oldPetInfor.Length != 4 || newPetInfor.Length != 4) Console.WriteLine("Incorrect input format");
        else
        {
            try
            {
                IPet oldPet = _petInventory.CreatePet(oldPetInfor[0], oldPetInfor[1], int.Parse(oldPetInfor[2]), oldPetInfor[3]);
                IPet newPet = _petInventory.CreatePet(newPetInfor[0], newPetInfor[1], int.Parse(newPetInfor[2]), newPetInfor[3]);
                _petInventory.EditPet(oldPet, newPet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public void RemovePet(string type, string name, int age, string gender)
    {
        IPet pet = _petInventory.CreatePet(type, name, age, gender);
        _petInventory.RemovePet(pet);
    }

    public void FindPet(string name)
    {
        List<IPet> findPets = _petInventory.FindPets(name);
        foreach (var pet in findPets)
        {
            Console.WriteLine("Finding pet...");
            Console.WriteLine("Result:");
            pet.PrintPetInformation();
        }
    }
    
    public void ViewPetList()
    {
        _petInventory.ViewPetList();
    }

    public void SaveFile()
    {
        _petInventory.SaveFile();
    }
}