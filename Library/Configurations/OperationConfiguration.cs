using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Library.Configurations
{
	public class OperationConfiguration : IEntityTypeConfiguration<Operation>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Operation> builder)
		{
			builder.Ignore(x => x.ID);
			builder.HasKey(x => new { x.StudentID, x.BookID });
			builder.ToTable("Operasyonlar");
			builder.Property(x => x.StartDate).HasColumnType("datetime");
			builder.HasOne(o => o.Book).WithMany(b => b.Operations).HasForeignKey(o => o.BookID);
			builder.HasOne(o => o.Student).WithMany(s => s.Operations).HasForeignKey(o => o.StudentID);

		}
	}
}
