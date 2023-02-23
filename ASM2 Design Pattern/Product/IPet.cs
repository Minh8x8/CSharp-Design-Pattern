namespace ASM2_Design_Pattern.Product;

public interface IPet
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }

    public void MakeSound();
    public void PrintPetInformation();
    public bool Equals(IPet pet);
}