using CrudProject.Data;
using CrudProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchesController : Controller
    {
        private readonly FullStackDbContext _fullStackDbContext;
        

        public BranchesController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetBranches()
        {
            var branches = await _fullStackDbContext.Branches.ToListAsync();
            return Ok(branches);
        }

        [HttpPost]
        public async Task<IActionResult> AddBranches([FromBody] Branches branchesRquest)
        {
            branchesRquest.id = Guid.NewGuid();
            //branchesRquest.ifsc = string;
            await _fullStackDbContext.Branches.AddAsync(branchesRquest);
            await _fullStackDbContext.SaveChangesAsync();

            return Ok(branchesRquest);
        }

        

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBranches([FromRoute] Guid id)
        {
            var branches = await _fullStackDbContext.Branches.FirstOrDefaultAsync(branche => branche.id == id);
            if (branches == null)
            {
                return NotFound();
            }
            return Ok(branches);
        }

        /*[HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBranches([FromRoute] Guid id, Branches updateBranchesRequest)
        {
            var branches = await _fullStackDbContext.Branches.FindAsync(id);
            if (branches == null)
            {
                return NotFound();
            }
            branches.name = updateBranchesRequest.name;
            branches.ref_code = updateBranchesRequest.ref_code;
            branches.address = updateBranchesRequest.address;
            branches.ifsc = updateBranchesRequest.ifsc;
            branches.bank_id = updateBranchesRequest.bank_id;

            await _fullStackDbContext.SaveChangesAsync();

            return Ok(branches);
        }*/


        //public async Task<IActionResult> UpdateBranches([FromRoute] string ifsc, Branches updateBranchesRequest)
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBranches([FromRoute] Guid id, Branches updateBranchesRequest)
        {
            //var branches = await _fullStackDbContext.Branches.FindAsync(ifsc);
            var branches = await _fullStackDbContext.Branches.FindAsync(id);
            if (branches == null)
            {
                return NotFound();
            }
            branches.name = updateBranchesRequest.name;
            branches.ref_code = updateBranchesRequest.ref_code;
            branches.address = updateBranchesRequest.address;
            branches.ifsc = updateBranchesRequest.ifsc;
            branches.bank_id = updateBranchesRequest.bank_id;
            branches.updated_at = updateBranchesRequest.updated_at;
            await _fullStackDbContext.SaveChangesAsync();

            return Ok(branches);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBranches([FromRoute] Guid id)
        {
            var branches = await _fullStackDbContext.Branches.FindAsync(id);
            if (branches == null)
            {
                return NotFound();
            }
            _fullStackDbContext.Branches.Remove(branches);

            await _fullStackDbContext.SaveChangesAsync();


            var branchesDel = await _fullStackDbContext.Branches.ToListAsync();
            return Ok(branchesDel);
        }


    }
}

