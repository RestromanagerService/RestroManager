using System.ComponentModel;

namespace Restromanager.Backend.Enums
{
    public enum OrderStatus
    {
        [Description("Nuevo")]
        New,

        [Description("Preparado")]
        Prepared,

        [Description("Entregado")]
        Delivered,

        [Description("Pagado")]
        Payed
    }
}
