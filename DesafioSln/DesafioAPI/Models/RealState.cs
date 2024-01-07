using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAPI.Models
{
    public class RealState
    {
        // Atributos do modelo 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(64, MinimumLength = 4)]
        public string Title { get; set; }

        [Required]
        public double Value { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(40, MinimumLength = 4)]
        public string Neighborhood { get; set; }

        [Required]
        public int BedroomQuantity { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string BusinessType { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(300, MinimumLength = 4)]
        public string Adress { get; set; }


        // Relacionamento
        public virtual List<RealStateImage> RealStateImages { get; set; }
    }
}