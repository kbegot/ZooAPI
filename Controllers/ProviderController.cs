using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooAPI.Entities;
using ZooAPI.Context;

namespace ZooAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class ProviderController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public ProviderController(ApplicationDBContext dbContext){
        _context = dbContext;
    }

    [HttpGet]
    [Route("GetProviders")]
    public async Task<IActionResult> GetProviders()
    {
        try{
            return Ok(await _context.Providers.ToListAsync());
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("GetProvider/{id}")]
    public async Task<IActionResult> GetProvider(int id)
    {
        try{
            return Ok(await _context.Providers.FindAsync(id));
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("CreateProvider")]
    public async Task<ActionResult<Provider>> CreateProvider([FromBody] ProviderRequestDTO requestDTO)
    { 
        try{
            Provider provider = new Provider() {
                ProviderName = requestDTO.ProviderName,
                ProviderSiret = requestDTO.ProviderSiret
            };

            // Ajouter provider au contexte de la base de données
            await _context.Providers.AddAsync(provider);
            
            // Sauvegarder les changements dans la base de données
            await _context.SaveChangesAsync();

            // Retourner provider avec l'ID généré par la base de données
            return CreatedAtAction(nameof(CreateProvider), new { id = provider.ProviderId }, provider);
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete]
    [Route("/DeleteProvider/{id}")]
    public async Task<ActionResult<Provider>> DeleteProvider(int id)
    {
        try{
            //Récupération du animal via l'id dans l'url
            var provider = await _context.Providers.FindAsync(id);

            if (provider == null)
        {
            return NotFound("Provider not Found");
        }
            _context.Remove(provider);

            await _context.SaveChangesAsync();
            return Ok(provider.ProviderId + " Provider has been deleted !");
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch()]
    [Route("/UpdateProvider/{id}")]
    public async Task<ActionResult<Provider>> UpdateProvider(int id,[FromBody] ProviderRequestDTO requestDTO)
    {
        try{
            //Récupération du provider via l'id dans l'url
            var provider = await _context.Providers.FindAsync(id);
            if (provider == null)
            {
                return NotFound("Provider not found.");
            }

            //Modification du Provider
            provider.ProviderName = requestDTO.ProviderName;
            provider.ProviderSiret = requestDTO.ProviderSiret;

            //Sauvegarde des modifications
            await _context.SaveChangesAsync();

            return Ok(provider.ProviderId + " Provider has been updated !");
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
}