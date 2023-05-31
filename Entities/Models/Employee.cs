using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Employee
    {
        [Column("EmployeeId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Employee name cannot be left vacant")]
        [MaxLength(50, ErrorMessage ="Employee name cannot exceed 50 characters")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Age is a required field")]
        [DataType(DataType.DateTime, ErrorMessage ="Field requires date format")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage ="Position field is required")]
        [MaxLength(15, ErrorMessage ="Position cannot exceed 15 characters")]
        public string? Position { get; set; }
        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }

    }
}
