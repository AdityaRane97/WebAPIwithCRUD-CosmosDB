using WebAPIwithCRUDCosmosDB.Data;
using WebAPIwithCRUDCosmosDB.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;


namespace WebAPIwithCRUDCosmosDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerRepo _employerRepo;

        public EmployerController(IEmployerRepo employerRepo)
        {
            _employerRepo = employerRepo;
        }

        [HttpPost]        
        public async Task<ActionResult<ApplicationFormModel>> Insert(ApplicationFormModel model)
        {
            model.id = Guid.NewGuid().ToString();            
            var task = await _employerRepo.Insert(model);
            return Ok(task.ProgramID);
        }
        [HttpPut("{programid}")]
        public async Task<ActionResult<ApplicationFormModel>> Update(string programid, ApplicationFormModel model)
        {
            var exist = await _employerRepo.GetbyID(programid);
            if (exist == null) { 
                return NotFound();
            }
            model.ProgramID = exist.ProgramID;
            model.id = exist.id;

            var task = await _employerRepo.Update(model);
            return Ok(task);
        }
        [HttpGet("{programid}")]
        public async Task<ActionResult<ApplicationFormModel>> GetFormDetail(string programid)
        {
            var exist = await _employerRepo.GetbyID(programid);
            if (exist == null)
            {
                return NotFound();
            }
            else {
                return Ok(exist);
            }                        
        }
    }
}
