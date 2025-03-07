namespace AppTest.Models
{
    public class QuestionQCM : BaseQuestion
    {
        public int Id { get; set; }
        public List<string>? reponse_possible { get; set; }
        public List<int>? reponse_correct { get; set; }
    }
}
