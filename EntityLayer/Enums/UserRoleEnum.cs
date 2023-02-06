using System.ComponentModel;

namespace EntityLayer.Enums
{
    public enum UserRoleEnum
    {
        [Description("Admin")]
        Admin,
        [Description("User")]
        User,
        [Description("Guest")]
        Guest
    }
}