namespace WebAPIwithCRUDCosmosDB.Model
{
    public class QuestionDetails
    {
        public string name { get; set; }
        public QuestionType type { get; set; }
        public string[] choice { get; set; }
        public Boolean? otheroption { get; set; }
        public Int16? maxchoice { get; set; }
    }
}
