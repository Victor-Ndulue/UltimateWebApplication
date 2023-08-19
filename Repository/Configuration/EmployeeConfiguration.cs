using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData
                (
                  //This handles creating initial data to be populated to the database. For class "Employee"
                    new Employee
                    {
                        Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                        Name = "Victor Ndulue",
                        DateOfBirth = DateTime.Now,
                        Position = "Software Dev",
                        CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                    }
                );
        }
    }
}
