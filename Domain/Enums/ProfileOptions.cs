using System.ComponentModel;

namespace Domain.Enums;

public enum ProfileOptions
{
    [Description("مالك النظام")]
    Owner = 1,
    [Description("مدير النظام")]
    Admin = 2,
}
