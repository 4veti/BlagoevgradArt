using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlagoevgradArt.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
