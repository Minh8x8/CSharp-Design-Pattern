using ASM2_Design_Pattern.Factory;
using ASM2_Design_Pattern.Product;

namespace ASM2_Design_Pattern.Pet_Store;

public class PetInventory : IPetFinder
{
    public List<IPet> PetList;
    public PetStoreFactory PetStoreFactory;
    
    // Constructor

    public PetInventory()
    {
        PetList = new List<IPet>();
        PetStoreFactory = new PetStoreFactory();
        using (StreamReader reader = new StreamReader
                   (@"C:\Users\Minh\OneDrive\Desktop\ASM2 Design Pattern\ASM2 Design Pattern\database.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] fields = line.Split(',');
                IPet pet = PetStoreFactory.CreatePet(fields[0], fields[1], int.Parse(fields[2]), fields[3]);
                PetList.Add(pet);
            }
        }
    }
    
    // Methods
    public IPet CreatePet(string type, string name, int age, string gender)
    {
        return PetStoreFactory.CreatePet(type, name, age, gender);
    }
    public void AddPet(IPet pet)
    {
        PetList.Add(pet);
    }

    public void EditPet(IPet oldPet, IPet newPet)
    {
        int idx = PetList.FindIndex(p => p.Equals(oldPet));
        if (idx != -1)
        {
            PetList[idx] = newPet;
            Console.WriteLine("Edited!!!");
        }
        else
        {
            Console.WriteLine("Don't have that pet");
        }
    }

    public void RemovePet(IPet pet)
    {
        PetList.RemoveAll(p => pet.Equals(p));
    }

    public void ViewPetList()
    {
        Console.WriteLine($"{"Type",-10}|{"Name", -15}|{"Age", -10}|{"Gender"}");
        foreach (var pet in PetList)
        {
            pet.PrintPetInformation();
        }
    }

    public List<IPet> FindPets(string name)
    {
        return PetList.FindAll(p => p.Name == name)!;
    }

    public void SaveFile()
    {
        using (StreamWriter writer = new StreamWriter
                   (@"C:\Users\Minh\OneDrive\Desktop\ASM2 Design Pattern\ASM2 Design Pattern\database.txt"))
        {
            foreach (IPet pet in PetList)
            {
                writer.WriteLine($"{pet.GetType().Name},{pet.Name},{pet.Age},{pet.Gender}");
            }
        }
    }
}
