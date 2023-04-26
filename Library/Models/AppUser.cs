using Library.Enum;
using System.Collections.Generic;
using Library.Models;
using System.Threading.Tasks;



namespace Library.Models
{ 
	public class AppUser:BaseEntity
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public Role Role { get; set; }
		
	}
}
