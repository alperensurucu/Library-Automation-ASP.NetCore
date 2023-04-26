using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
//using System.Reflection.Emit;


namespace Library.Initializer
{
	public static class DataInitializer
	{  
		public static void Seed(ModelBuilder modelBuilder)
		{
			string password1 = BCrypt.Net.BCrypt.HashPassword("123");
			string password2 = BCrypt.Net.BCrypt.HashPassword("1234");
			modelBuilder.Entity<AppUser>().HasData(
				new AppUser() { ID=1, UserName="administrator", Password=password1, Role=Enum.Role.admin },
				new AppUser() { ID=2, UserName="alperen", Password=password2, Role=Enum.Role.user }
			);
			modelBuilder.Entity<Student>().HasData(
				new Student() { ID=1, FirstName="Emirhan", LastName="sürücü",Gender=Enum.Gender.Erkek },
				new Student() { ID=2, FirstName="Seden", LastName="sürücü", Gender=Enum.Gender.Kız },
				new Student() { ID=3, FirstName="İbrahim", LastName="sürücü", Gender=Enum.Gender.Erkek },
				new Student() { ID=4, FirstName="Emine", LastName="sürücü", Gender=Enum.Gender.Kız }

			);
			modelBuilder.Entity<StudentDetail>().HasData(
				new StudentDetail() { ID= 1 ,StudentID= 1, SchoolNumber= "100", BirthDay= new DateTime(1997, 11, 30)},
				new StudentDetail() { ID= 2, StudentID= 2, SchoolNumber= "101", BirthDay= new DateTime(1992, 11, 30) },
				new StudentDetail() { ID= 3, StudentID= 3, SchoolNumber= "102", BirthDay= new DateTime(1997, 11, 30) },
				new StudentDetail() { ID= 4, StudentID= 4, SchoolNumber= "103", BirthDay= new DateTime(1990, 11, 30) }

				);

		}
	}
}
