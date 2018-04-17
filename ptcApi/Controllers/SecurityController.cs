using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ptcApi.Model;
using PtcApi.Controllers;

namespace ptcApi.Controllers {
    [Route ("api/[controller]")]
    public class SecurityController : BaseApiController {
        [HttpPost ("login")]
        public IActionResult Login ([FromBody] AppUser user) {
            IActionResult result = null;
            AppUserAuth userAuth = new AppUserAuth ();
            SecurityManager securityManager = new SecurityManager ();

            userAuth = securityManager.ValidateUser (user);
            if (userAuth.IsAuthenticated) {
                result = StatusCode (StatusCodes.Status200OK, userAuth);
            } else {
                result = StatusCode (StatusCodes.Status404NotFound, "Invalid username or password.");
            }
            return result;
        }
    }
}