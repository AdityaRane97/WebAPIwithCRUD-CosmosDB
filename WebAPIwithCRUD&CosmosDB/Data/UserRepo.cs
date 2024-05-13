using WebAPIwithCRUDCosmosDB.Model;
using Microsoft.Azure.Cosmos;

namespace WebAPIwithCRUDCosmosDB.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly CosmosClient _client;
        private readonly IConfiguration _configuration;
        private readonly Container _container;
        public UserRepo(CosmosClient cosmosClient, IConfiguration configuration)
        {
            _client = cosmosClient;
            _configuration = configuration;
            var databasename = configuration["CosmosDB:DatabaseName"];
            var taskcontainername = "UserDetail";
            _container = cosmosClient.GetContainer(databasename, taskcontainername);
        }
        public async Task<UserModel> Insert(UserModel model)
        {
            var query = await _container.CreateItemAsync<UserModel>(model);
            return query.Resource;
        }
    }
}
