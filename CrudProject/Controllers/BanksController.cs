using CrudProject.Data;
using CrudProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BanksController : Controller
    {
        private readonly FullStackDbContext _fullStackDbContext;
       

        public BanksController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetBanks()
        {
            var banks = await _fullStackDbContext.Banks.ToListAsync();
            return Ok(banks);
        }

        [HttpPost]
        public async Task<IActionResult> AddBanks([FromBody] Banks banksRquest)
        {
            banksRquest.Id = Guid.NewGuid();
            await _fullStackDbContext.Banks.AddAsync(banksRquest);
            await _fullStackDbContext.SaveChangesAsync();
            
            return Ok(banksRquest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBanks([FromRoute] Guid id) {
            var banks = await _fullStackDbContext.Banks.FirstOrDefaultAsync(bank => bank.Id == id);
            if (banks == null)
            {
                return NotFound();
            }
            return Ok(banks);  
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBanks([FromRoute] Guid id, Banks updateBanksRequest)
        {
            var banks = await _fullStackDbContext.Banks.FindAsync(id);
            if (banks == null)
            {
                return NotFound();        
            }
            banks.name = updateBanksRequest.name;
            banks.ref_code = updateBanksRequest.ref_code;
            banks.short_name = updateBanksRequest.short_name;
            banks.updated_at = updateBanksRequest.updated_at;

            await _fullStackDbContext.SaveChangesAsync();

            return Ok(banks);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBanks([FromRoute] Guid id)
        {
            var banks = await _fullStackDbContext.Banks.FindAsync(id);
            if (banks == null)
            {
                return NotFound();
            }
             _fullStackDbContext.Banks.Remove(banks);

            await _fullStackDbContext.SaveChangesAsync();


            var banksDel = await _fullStackDbContext.Banks.ToListAsync();
            return Ok(banksDel);
        }

        
    }
}
