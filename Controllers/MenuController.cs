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

    [HttpGet]
    [Route("GetMenu/{id}")]
    public async Task<IActionResult> GetMenu(int id)
    {
        try{
            return Ok(await _context.Menus.FindAsync(id));
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("CreateMenu")]
    public async Task<ActionResult<Menu>> CreateMenu([FromBody] MenuRequestDTO requestDTO)
    { 
        try{
            Menu menu = new Menu() {
                menuName = requestDTO.menuName,
            };

            // Ajouter menu au contexte de la base de données
            await _context.Menus.AddAsync(menu);
            
            // Sauvegarder les changements dans la base de données
            await _context.SaveChangesAsync();

            // Retourner menu avec l'ID généré par la base de données
            return CreatedAtAction(nameof(CreateMenu), new { id = menu.MenuId }, menu);
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }

     [HttpDelete]
    [Route("/DeleteMenu/{id}")]
    public async Task<ActionResult<Menu>> DeleteMenu(int id)
    {

        //Récupération Menu via l'id dans l'url
        var menu = await _context.Menus.FindAsync(id);

        if (menu == null)
        {
            return NotFound("Menu not Found");
        }
        _context.Remove(menu);

        await _context.SaveChangesAsync();
        return Ok(menu.MenuId + " Menu has been deleted !");
    }

    [HttpPatch()]
    [Route("/UpdateMenu/{id}")]
    public async Task<ActionResult<Menu>> UpdateMenu(int id,[FromBody] MenuRequestDTO requestDTO)
    {
        try{
            //Récupération du menu via l'id dans l'url
            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound("Menu not found.");
            }

            //Modification du Menu
            menu.menuName = requestDTO.menuName;

            //Sauvegarde des modifications
            await _context.SaveChangesAsync();

            return Ok(menu.MenuId + " Menu has been updated !");
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
}