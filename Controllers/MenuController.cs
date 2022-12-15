using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooAPI.Entities;
using ZooAPI.Context;

namespace ZooAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class MenuController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public MenuController(ApplicationDBContext dbContext){
        _context = dbContext;
    }

    [HttpGet]
    [Route("GetMenus")]
    public async Task<IActionResult> GetMenus()
    {
        try{
            return Ok(await _context.Menus.ToListAsync());
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("CreateMenu")]
    public async Task<ActionResult<Menu>> CreateMenu([FromBody] Menu menu)
    { 
        try{
            // Ajouter l'animal au contexte de la base de données
            await _context.Menus.AddAsync(menu);
            
            // Sauvegarder les changements dans la base de données
            await _context.SaveChangesAsync();

            // Retourner l'animal avec l'ID généré par la base de données
            return CreatedAtAction(nameof(CreateMenu), new { id = menu.MenuId }, menu);
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
}