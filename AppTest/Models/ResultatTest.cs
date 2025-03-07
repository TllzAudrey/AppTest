namespace AppTest.Models
{
    public class ResultatTest : BaseResultat
    {
        public int Id { get; set; }
        public int? fk_id_test { get; set; }
        public List<BaseReponse>? list_reponse { get; set; }


    }
}
