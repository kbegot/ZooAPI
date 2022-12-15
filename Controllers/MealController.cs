using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooAPI.Entities;
using ZooAPI.Context;

namespace ZooAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class MealController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public MealController(ApplicationDBContext dbContext){
        _context = dbContext;
    }

    [HttpGet]
    [Route("GetMeals")]
    public async Task<IActionResult> GetMeals()
    {
        try{
            return Ok(await _context.Meals.ToListAsync());
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("GetMeal/{id}")]
    public async Task<IActionResult> GetMeal(int id)
    {
        try{
            return Ok(await _context.Meals.FindAsync(id));
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("CreateMeal")]
    public async Task<ActionResult<Meal>> CreateMeal([FromBody] MealRequestDTO requestDTO)
    { 
        try{
            Meal meal = new Meal() {
                mealTime = requestDTO.mealTime,
                AnimalId = requestDTO.AnimalId,
                MenuId = requestDTO.MenuId
            };

            var animal = await _context.Animals.FindAsync(requestDTO.AnimalId);
            if (animal == null)
            {
                return BadRequest("Animal non trouvé");
            }
            
            var menu = await _context.Menus.FindAsync(requestDTO.MenuId);
            if (menu == null)
            {
                return BadRequest("Menu non trouvé");
            }

            // Ajouter Meal au contexte de la base de données
            await _context.Meals.AddAsync(meal);
            
            // Sauvegarder les changements dans la base de données
            await _context.SaveChangesAsync();

            // Retourner Meal avec l'ID généré par la base de données
            //return Ok("L'animal a bien été ajouter" + meal);
            return CreatedAtAction(nameof(CreateMeal), new { id = meal.MealId }, meal);
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("/DeleteMeal/{id}")]
    public async Task<ActionResult<Meal>> DeleteMeal(int id)
    {

        //Récupération Meal via l'id dans l'url
        var meal = await _context.Meals.FindAsync(id);

        if (meal == null)
        {
            return NotFound("Meal not Found");
        }
        _context.Remove(meal);

        await _context.SaveChangesAsync();
        return Ok(meal.MealId + " Meal has been deleted !");
    }

    // Je n'ai pas eu le temps de finir mais la pour pouvoir modifier la table Meal il fallait 
    // que je modifie aussi toutes les relations avec meal pour eviter les problèmes.
    //
    // [HttpPatch()]
    // [Route("/UpdateMeal/{id}")]
    //  public async Task<ActionResult<Meal>> UpdateMeal(int id,[FromBody] MealRequestDTO requestDTO)
    // {
    //     try{
    //         //Récupération du meal via l'id dans l'url
    //         var meal = await _context.Meals.FindAsync(id);
    //         if (meal == null)
    //         {
    //             return NotFound("Meals not found.");
    //         }

    //         //Modification du Meal
    //         meal.mealTime = requestDTO.mealTime;
    //         meal.AnimalId = requestDTO.AnimalId;
    //         meal.MealId = requestDTO.MenuId;

    //         //Sauvegarde des modifications
    //         await _context.SaveChangesAsync();

    //         return Ok(meal.MealId + " Meal has been updated !");
    //     }
    //     catch(Exception ex){
    //         return BadRequest(ex.Message);
    //     }
    // }
}