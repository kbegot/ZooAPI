namespace ZooAPI.Entities;

public class Menu
{
    public int MenuId {get; set;}
    public string? menuName {get; set;}
    

    // Relations

    public virtual ICollection<MenuFood>? MenuFoods {get; set;}

}