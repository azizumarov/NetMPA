using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetMPA.Catalog.Bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Dal.Configuration
{
    public  class CategoryConfiguration: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(category => category.Id);

            builder.Property(category => category.Id);
            builder.Property(category => category.Name).IsRequired().HasMaxLength(50);
            builder.Property(category => category.Image);
            
        }
    }
}
