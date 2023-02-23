using ASM2_Design_Pattern.Product;

namespace ASM2_Design_Pattern.Factory;

public interface IPetFactory
{
    public IPet CreatePet(string type, string name, int age, string gender);
}