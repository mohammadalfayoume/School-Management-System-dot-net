using AutoMapper;
using EntityLayer.DTOs.AccountDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;

namespace MvcWebLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountServices _accountServices;
        private readonly UniversityServices _universityServices;
        private readonly TokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(AccountServices accountServices,
            UniversityServices universityServices,
            TokenService tokenService,
            IMapper mapper)
        {
            _accountServices = accountServices;
            _universityServices = universityServices;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginDto loginDto)
        {
            var user = await _accountServices.LoginAsync(loginDto);
            var encrypterToken = _tokenService.CreateToken(user);
            HttpContext.Response.Cookies.Append("token", encrypterToken,
                new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(7),
                    HttpOnly = true,
                    Secure = true,
                    IsEssential = true,
                    SameSite = SameSiteMode.None
                });
            
            return RedirectToAction("Index", "User", user);
        }
        public async Task<IActionResult> SignUp()
        {
            var universities = await _universityServices.GetAllUniversitiesAsync();
            ViewBag.Universities = universities;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterDto registerDto)
        {
            var user = await _accountServices.CreateAccountAsync(registerDto);
            var token = _tokenService.CreateToken(user);
            return RedirectToAction("Index", "User");
        }
    }
}
