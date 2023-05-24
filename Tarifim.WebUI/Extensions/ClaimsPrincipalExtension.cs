using System.Security.Claims;
using Tarifim.Data.Enums;

namespace Tarifim.WebUI.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            return Convert.ToInt32(user.Claims.FirstOrDefault(x => x.Type == "id")?.Value);
        }
        public static string GetUserName(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(x => x.Type == "name")?.Value;
        }
        public static string GetUserSurName(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(x => x.Type == "surname")?.Value;
        }
        public static string GetUserEmail(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(x => x.Type == "email")?.Value;
        }
        public static bool IsLogged(this ClaimsPrincipal user)
        {
            //  id diye bir cookie tutuluyorsa , oturum açık demektir.
            if (user.Claims.FirstOrDefault(x => x.Type == "id") != null)
                return true;
            else
                return false;
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            if (user.Claims.FirstOrDefault(x => x.Type == "usertype")?.Value == UserTypeEnum.admin.ToString())
                return true;
            else
                return false;
        }

    }
}
