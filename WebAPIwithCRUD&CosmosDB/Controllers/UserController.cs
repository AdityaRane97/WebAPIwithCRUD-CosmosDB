using WebAPIwithCRUDCosmosDB.Data;
using WebAPIwithCRUDCosmosDB.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIwithCRUDCosmosDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userrepo;

        public UserController(IUserRepo userrepo)
        {
            _userrepo = userrepo;
        }
        [HttpPost]
        public async Task<ActionResult<UserModel>> Insert(UserModel model)
        {
            model.Id = Guid.NewGuid().ToString();
            var task = await _userrepo.Insert(model);
            return Ok(task.Id);
        }
    }
}
