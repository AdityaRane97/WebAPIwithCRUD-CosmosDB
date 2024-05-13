using Newtonsoft.Json;

namespace WebAPIwithCRUDCosmosDB.Model
{
    public class ApplicationFormModel
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        [JsonProperty(PropertyName = "programid")]
        public string ProgramID { get; set; }
        public string ProgramTitle { get; set; }
        public string ProgramDescription { get; set; }
        public List<QuestionDetails> SelectedQuestions { get; set; }
    }
}
