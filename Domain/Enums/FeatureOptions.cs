using System.ComponentModel;

namespace Domain.Enums;

public enum FeatureOptions
{
    [Description("الهويه")]
    Identity = 1,
    [Description("الكتب")]
    Books = 2,
}
