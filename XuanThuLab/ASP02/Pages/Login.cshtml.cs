using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ASP02.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]// cái này dùng cho các trường gán trực tiếp từ model của view với name input trùng với tên trường
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()// Phương thức này đặt theo quy tắc OnPost, OnGet, OnPostAsync, OnGetAsync,... theo method của form gửi ở view.Nếu không theo quy tắc phải sử dụng Ajax
        {
            if (Username == "admin" && Password == "password") 
            {
                //Claim được sử dụng trong bối cảnh xác thực(authentication) và phân quyền(authorization)
                //Tạo danh sách Clain
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Username),
                    new Claim(ClaimTypes.Role, "Admin")
                };
                
                //tạo danh tính người dùng
                var identity = new ClaimsIdentity(claims, "CookieAuth");
                var principal = new ClaimsPrincipal(identity);

                //Đăng nhập người dùng
                await HttpContext.SignInAsync("CookieAuth", principal);


                //Điều hướng tới trang chủ hoặc một trang khác
                return RedirectToPage("Index");
            }

            //Nếu đăng nhập thất bại
            ModelState.AddModelError(string.Empty, "Invalid username or password");
            return Page();
        }
    }
}
