using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTestWork.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
    private readonly DataContext _context;

    public GamesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Games>>> Get()
    {
        
        return Ok(await _context.propGames.ToListAsync());
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<Games>> Get(int id)
    {
        var game = await _context.propGames.FindAsync(id);
        if (game == null)
            return BadRequest("Game not found.");
        return Ok(game);
    }

    [HttpPost]
    public async Task<ActionResult<List<Games>>> AddGame(Games game)
    {
        _context.propGames.Add(game);
        await _context.SaveChangesAsync();
        return Ok(await _context.propGames.ToListAsync());
    }

    [HttpPut]

    public async Task<ActionResult<List<Games>>> UpdateGame(Games request)
    {
        var dbGame = await _context.propGames.FindAsync(request.Id);
        if (dbGame == null)
            return BadRequest("Game not found."); ;

        dbGame.Name = request.Name;
        dbGame.DevStudio = request.DevStudio;
        dbGame.Genre = request.Genre;

        await _context.SaveChangesAsync();

        return Ok(await _context.propGames.ToListAsync());
    }

    [HttpDelete("{id}")]

    public async Task<ActionResult<List<Games>>> Delete(int id)
    {
        var dbGame = await _context.propGames.FindAsync(id);
        if (dbGame == null)
            return BadRequest("Game not found.");

        _context.propGames.Remove(dbGame);
        await _context.SaveChangesAsync();
        return Ok(await _context.propGames.ToListAsync());
    }
}
