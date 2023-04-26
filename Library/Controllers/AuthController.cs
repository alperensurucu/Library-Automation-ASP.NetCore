using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Library.Context;
using Library.RepositoryPattern.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Library.Controllers
{
	public class AuthController : Controller
	{
		IRepository<AppUser> _repoUser;
		public AuthController(IRepository<AppUser> repoUser)
		{
			_repoUser = repoUser;

		}
		public IActionResult Login() 
		{
			return View();
		}

		//Veri tabanında ilgili kullanıcı var mı ?
		//Kullanıcının bilgileri cekme 
		//Kullanıcının şifresi kripta veriyle eşleşiyor mu kontrolü
		//Kullanıcının rolüne göre sayfa yönlendirmesi yapıcam 

		[HttpPost]
		public async Task<IActionResult> Login(AppUser user)
		{
			if (_repoUser.Any(x => x.UserName == user.UserName && x.Status != Enum.DataStatus.Deleted)) 
			{
				AppUser selectedUser = _repoUser.Default(x => x.UserName == user.UserName && x.Status  != Enum.DataStatus.Deleted);
				bool isValid= BCrypt.Net.BCrypt.Verify(user.Password,selectedUser.Password);
				if (isValid)
				{
					List<Claim> claims = new List<Claim>()
					{
						new Claim("userName",selectedUser.UserName),
						new Claim("userId", selectedUser.ID.ToString()),
						new Claim("role",selectedUser.Role.ToString())
					};
					ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					ClaimsPrincipal principal = new ClaimsPrincipal(identity);
					await HttpContext.SignInAsync(principal);
					if (selectedUser.Role == Enum.Role.admin)
					{
						return RedirectToAction("Index", "Home", new { area = "Management" });
					}else if(selectedUser.Role == Enum.Role.user)
					{
						return RedirectToAction("Index", "Home");
					}
				}
			}
			return View();
		}
		public async Task<IActionResult> LogOut()
		{
			await HttpContext.SignOutAsync();
			return RedirectToAction("Login");
		}
	}
}
