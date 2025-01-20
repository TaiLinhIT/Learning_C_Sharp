using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP02.Pages
{
    [Authorize(Roles = "Admin")]// để đảm bảo đăng nhập đã trải qua xác thực
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
