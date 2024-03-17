using System.ComponentModel;

namespace Domain.Enums;

public enum PermissionOptions
{
    [Description("الفهرسه")]
    List = 1,
    [Description("الاضافه")]
    Create = 2,
    [Description("التعديل")]
    Update = 3,
    [Description("المسح")]
    Delete = 4,
}
