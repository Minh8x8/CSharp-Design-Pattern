using ASM2_Design_Pattern.Product;

namespace ASM2_Design_Pattern.Factory;

public class PetStoreFactory : IPetFactory
{
    public IPet CreatePet(string type, string name, int age, string gender)
    {
        switch (type)
        {
            case "Dog":
                return new Dog(name, age, gender);
            case "Cat":
                return new Cat(name, age, gender);
            case "Bird":
                return new Bird(name, age, gender);
            default:
                return new Pet(name, age, gender);
        }
    }
}