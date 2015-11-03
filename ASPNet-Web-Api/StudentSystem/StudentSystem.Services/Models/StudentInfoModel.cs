using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Services.Models
{
    public class StudentInfoModel
    {
        [Column("Email")]
        public string Email { get; set; }

        [Column("Address")]
        public string Address { get; set; }
    }
}