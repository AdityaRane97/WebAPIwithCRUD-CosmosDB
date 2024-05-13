using WebAPIwithCRUDCosmosDB.Model;

namespace WebAPIwithCRUDCosmosDB.Data
{
    public interface IUserRepo
    {
        Task<UserModel> Insert(UserModel model);
    }
}
