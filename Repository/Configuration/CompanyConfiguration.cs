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
    //This handles creating initial data to be populated to the database. For class "Company"
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData
                (
                    new Company
                    {
                        Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                        Name = "Archeons Enterprises",
                        Address = "Ndulue's Compound< Ifite Village, Nkwelle Ezunaka, Anambra",
                        Country = "Nigeria"
                    }
                );
        }
    }
}
