namespace StudentSystem.Services.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CourseModel
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public virtual ICollection<StudentModel> Students { get; set; }

        public virtual ICollection<HomeworkModel> Homeworks { get; set; }
    }
}