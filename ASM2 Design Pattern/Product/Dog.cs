﻿namespace ASM2_Design_Pattern.Product;

public class Dog : IPet
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }

    public Dog()
    {
    }

    public Dog(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public void MakeSound()
    {
        Console.WriteLine("Bark!!!");
    }

    public void PrintPetInformation()
    {
        Console.WriteLine($"{this.GetType().Name,-10}|{Name, -15}|{Age, -10}|{Gender}");
    }
    public bool Equals(IPet pet)
    {
        return pet.Name == this.Name && pet.Age == this.Age && pet.Gender == this.Gender;
    }
}