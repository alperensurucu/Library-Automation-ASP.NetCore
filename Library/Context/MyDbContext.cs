using Library.Configurations;
using Library.Initializer;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace Library.Context
{
    public class MyDbContext : DbContext
    {
		/*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableSensitiveDataLogging();
		}*/

		public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT APİ İLE İŞLEMLER.//

            DataInitializer.Seed(modelBuilder);

            modelBuilder.ApplyConfiguration(new OperationConfiguration());

			modelBuilder.ApplyConfiguration(new AuthorConfiguration());

			modelBuilder.ApplyConfiguration(new StudentConfiguration());

			modelBuilder.ApplyConfiguration(new BookConfiguration());


		}
		
		public DbSet<Student> Studens { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookType> BookTypes { get; set; }

        public DbSet<Operation> Operations { get; set; }

        public DbSet<Author> Authors { get; set; }
		public DbSet<AppUser> Users { get; set; }



	/*	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//optionsBuilder.UseSqlServer("connection string")    //hatanın nereede olduğunu gösteriyor galiba 
			//.EnableSensitiveDataLogging();
			optionsBuilder.EnableSensitiveDataLogging();
		}
	*/



	}
}
