namespace ZooAPI.Entities;

public class Meal
{
    public int MealId {get; set;}
    public DateTime mealTime {get; set;}
   
    // Foreign Key AnimalId 
    public int AnimalId {get; set;}
    public Animal? Animal{get; set;} 

    // Foreign Key MenuId
    public int MenuId {get; set;}
    public Menu? Menu  {get; set;}

    // Relation
}