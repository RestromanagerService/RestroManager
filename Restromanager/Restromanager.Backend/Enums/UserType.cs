using System.ComponentModel;

namespace Restromanager.Backend.Enums
{
    public enum UserType
    {
        [Description("Administrador")]
        Admin,
        [Description("Cocinero")]
        Chef,
        [Description("Mesero")]
        Waiter,
        [Description("Usuario")]
        User
    }
}
