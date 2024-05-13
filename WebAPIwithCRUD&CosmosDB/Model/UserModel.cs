using Newtonsoft.Json;

namespace WebAPIwithCRUDCosmosDB.Model
{
    public class UserModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public IDictionary<string, string> PersonalDetail { get; set; }
        public List<DropdownModel> AdditionalDetail { get; set; }
    }
}
