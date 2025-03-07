namespace AppTest.Models
{
    public class ReponseQCM : BaseReponse
    {
        public int Id { get; set; }
        public List<int>? reponse_candidat { get; set; }

    }
}
