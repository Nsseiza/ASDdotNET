using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    public class Attendance
    {
        public Gig Gig { get; set; }
        public ApplicationUser Attende { get; set; }

        [Key]
        [Column(Order = 1)]
        public int Gigid { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }
    }
}