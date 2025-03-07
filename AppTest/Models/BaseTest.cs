namespace AppTest.Models
{
    public class BaseTest
    {
        public int Id { get; set; }
        public string? nom { get; set; }
        public List<BaseResultat>? liste_resultats { get; set; }
        public List<Candidat>? liste_candidats { get; set; }
        public int? fk_id_entreprise { get; set; }
    }
}
