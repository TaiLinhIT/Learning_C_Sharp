using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP02.Pages
{
    public class LogoutModel : PageModel
    {
        public async Task OnGet()
        {
            // Đăng xuất người dùng
            await HttpContext.SignOutAsync("CookieAuth");

            // Chuyển về trang đăng nhập
            Response.Redirect("/Login");
        }
    }
}
