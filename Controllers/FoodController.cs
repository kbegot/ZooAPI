using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooAPI.Entities;
using ZooAPI.Context;

namespace ZooAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class FoodController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public FoodController(ApplicationDBContext dbContext){
        _context = dbContext;
    }

    [HttpGet]
    [Route("GetFoods")]
    public async Task<IActionResult> GetFoods()
    {
        try{
            return Ok(await _context.Foods.ToListAsync());
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("CreateFood")]
    public async Task<ActionResult<Food>> CreateFood([FromBody] FoodRequestDTO requestDTO)
    { 
        try{
            Food food = new Food() {
                foodName = requestDTO.foodName,
                weight = requestDTO.weight,
                ProviderId = requestDTO.ProviderId
            };

            // Ajouter l'animal au contexte de la base de données
            await _context.Foods.AddAsync(food);
            
            // Sauvegarder les changements dans la base de données
            await _context.SaveChangesAsync();

            // Retourner l'animal avec l'ID généré par la base de données
            return CreatedAtAction(nameof(CreateFood), new { id = food.FoodId }, food);
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }

}