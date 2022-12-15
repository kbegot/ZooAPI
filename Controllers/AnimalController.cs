using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooAPI.Entities;
using ZooAPI.Context;

namespace ZooAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class AnimalController : ControllerBase
{   
    private readonly ApplicationDBContext _context;

    public AnimalController(ApplicationDBContext dbContext){
        _context = dbContext;
    }
    
    [HttpGet]
    [Route("GetAnimals")]
    public async Task<IActionResult> GetAnimals()
    {
        try
        {
        return Ok(await _context.Animals.ToListAsync());
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("GetAnimal/{id}")]
    public async Task<IActionResult> GetAnimal(int id)
    {
        try{
            return Ok(await _context.Animals.FindAsync(id));
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("CreateAnimal")]
    public async Task<ActionResult<Animal>> CreateAnimal([FromBody] AnimalRequestDTO requestDTO)
    { 
        try{
            Animal animal = new Animal() {
                name = requestDTO.Name,
                dateBirth = requestDTO.BirthDate
            };
            // Ajouter l'animal au contexte de la base de données
            await _context.Animals.AddAsync(animal);
            
            // Sauvegarder les changements dans la base de données
            await _context.SaveChangesAsync();

            // Retourner l'animal avec l'ID généré par la base de données
            return Ok("L'animal a bien été ajouter" + animal);
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("/DeleteAnimal/{id}")]
    public async Task<ActionResult<Animal>> DeleteAnimal(int id)
    {

        //Récupération du animal via l'id dans l'url
        var animal = await _context.Animals.FindAsync(id);

        if (animal == null)
        {
            return NotFound("Animal not Found");
        }
        _context.Remove(animal);

        await _context.SaveChangesAsync();
        return Ok(animal.AnimalId + " Animal has been deleted !");
    }

    [HttpPatch()]
    [Route("/UpdateAnimal/{id}")]
    public async Task<ActionResult<Animal>> UpdateAnimal(int id,[FromBody] AnimalRequestDTO requestDTO)
    {
        try{

            //Récupération du animal via l'id dans l'url
            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound("Animal not found.");
            }

            //Modification de l'animal
            animal.name = requestDTO.Name;
            animal.dateBirth = requestDTO.BirthDate;

            //Sauvegarde des modifications
            await _context.SaveChangesAsync();

            return Ok(animal.AnimalId + " Animal has been updated !");
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
}