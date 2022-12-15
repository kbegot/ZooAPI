namespace ZooAPI.Entities;

public class Menu
{
    public int MenuId {get; set;}
    public string? menuName {get; set;}
    

    // Relations
    public List<Meal>? Meals{get; set;} 

    public virtual ICollection<MenuFood>? MenuFoods {get; set;}

}