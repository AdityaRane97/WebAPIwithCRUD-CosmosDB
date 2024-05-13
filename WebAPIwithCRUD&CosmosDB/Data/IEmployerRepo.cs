using WebAPIwithCRUDCosmosDB.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIwithCRUDCosmosDB.Data
{
    public interface IEmployerRepo
    {
        Task<ApplicationFormModel> Insert(ApplicationFormModel model);
        Task<ApplicationFormModel> Update(ApplicationFormModel model);
        Task<ApplicationFormModel> GetbyID(string programid);
    }
}
