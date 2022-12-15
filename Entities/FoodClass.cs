namespace ZooAPI.Entities;

public class Food
{
    public int FoodId {get; set;}
    public string? foodName {get; set;}
    public double weight {get; set;}


    // Foreign Key AnimalId 
    public int ProviderId {get; set;}
    public Provider? Provider {get; set;}

    public virtual ICollection<MenuFood>? MenuFoods {get; set;}
}