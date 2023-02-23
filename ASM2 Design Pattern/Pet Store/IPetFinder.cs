using ASM2_Design_Pattern.Product;

namespace ASM2_Design_Pattern.Pet_Store;

public interface IPetFinder
{
    List<IPet> FindPets(string name);
}