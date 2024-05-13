using WebAPIwithCRUDCosmosDB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace WebAPIwithCRUDCosmosDB.Data
{
    public class EmployerRepo : IEmployerRepo
    {
        private readonly CosmosClient _client;
        private readonly IConfiguration _configuration;
        private readonly Container _container;
        public EmployerRepo(CosmosClient cosmosClient,IConfiguration configuration) 
        {
            _client = cosmosClient;
            _configuration = configuration;
            var databasename = configuration["CosmosDB:DatabaseName"];
            var taskcontainername = "Program";
            _container = cosmosClient.GetContainer(databasename,taskcontainername);
        }
        public async Task<ApplicationFormModel> Insert(ApplicationFormModel model) 
        {
            var query = await _container.CreateItemAsync<ApplicationFormModel>(model);
            return query.Resource;
        }
        public async Task<ApplicationFormModel> Update(ApplicationFormModel model) {
            var response = await _container.ReplaceItemAsync(model, model.id);
            return response.Resource;
        }
        public async Task<ApplicationFormModel> GetbyID(string programid) {
            var query = _container.GetItemLinqQueryable<ApplicationFormModel>().Where(x=>x.ProgramID == programid).Take(1).ToQueryDefinition();
            var response = await _container.GetItemQueryIterator<ApplicationFormModel>(query.QueryText).ReadNextAsync();
            return response.FirstOrDefault();
        }
    }
}
