using Khudmadad_Backend.EfCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Khudmadad_Backend.Efcore
{
    [Table("Offers")]  
    public class Offers
    {
        //foreign keys
        public int gigId { get; set; }
        public Gig gig { get; set; }

        public int freelancerId { get; set; }
        public Users freelancer { get; set; }

        [DataType(DataType.Currency)]
        public double pay { get; set; }

        [AllowNull]
        public bool status { get; set; }
    }
}
