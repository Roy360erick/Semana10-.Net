using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Semana10.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Numbre")]
        public int CourseID { get; set; }

        [StringLength(50,MinimumLength =3)]
        public string title_ { get; set; }

        [Range(0,5)]
        public int Credits { get; set; }

        public int DepartamentoID { get; set; }
        

        public virtual ICollection<Enrollment> Enrollment { get; set; }
    }
}