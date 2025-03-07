namespace AppTest.Models
{
    public class Gestionnaire : User
    {

        public List<BaseTest>? liste_test { get; set; }
        public List<Candidat>? liste_candidat { get; set; }
        public int? fk_id_entreprise { get; set; }
    }
}
