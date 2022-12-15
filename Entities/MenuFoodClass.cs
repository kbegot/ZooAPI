namespace ZooAPI.Entities;

public class MenuFood
{
    public int FoodId {get; set;}
    public Food Food {get; set;}
    public int MenuId {get; set;}
    public Menu Menu {get; set;}

}