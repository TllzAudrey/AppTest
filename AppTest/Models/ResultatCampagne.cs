using Microsoft.AspNetCore.Identity;

namespace AppTest.Models
{
    public class ResultatCampagne : BaseResultat
    {
        public int Id { get; set; }
        public List<ResultatTest>? liste_resultat { get; set; }
        public int? fk_id_campagne { get; set; }
    }
}
