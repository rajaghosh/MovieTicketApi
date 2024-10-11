using MovieTicketApi.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieTicketApi.Helper
{
    public class UserRoleAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var role = value.ToString();
            //return role.ToLower().Equals("theatre") || role.ToLower().Equals("user");
            return role.Equals(Roles.Admin) || role.ToLower().Equals(Roles.User);
        }
    }
}
