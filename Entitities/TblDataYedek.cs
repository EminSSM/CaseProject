using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entitities
{
    public class TblDataYedek
    {
        public int Id { get; set; }

        [Column(TypeName = "NVarchar(50)"), StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "NVarchar(60)"), StringLength(60)]
        public string Surname { get; set; }

        [Column(TypeName = "NVarchar(50)"), StringLength(50)]
        public string City { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public short BirthYear { get; set; }
    }
}
