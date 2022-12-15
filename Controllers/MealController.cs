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

    [HttpPost]
    [Route("CreateMeal")]
    public async Task<ActionResult<Meal>> CreateMeal([FromBody] MealRequestDTO requestDTO)
    { 
        try{
            Meal meal = new Meal() {
                mealTime = requestDTO.MealDate,
                AnimalId = requestDTO.AnimalId,
                MenuId = requestDTO.MenuId
            };

            // Ajouter Meal au contexte de la base de données
            await _context.Meals.AddAsync(meal);
            
            // Sauvegarder les changements dans la base de données
            await _context.SaveChangesAsync();

            // Retourner Meal avec l'ID généré par la base de données
            return Ok("L'animal a bien été ajouter" + meal);
            //return CreatedAtAction(nameof(CreateMeal), new { id = meal.MealId }, meal);
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
}