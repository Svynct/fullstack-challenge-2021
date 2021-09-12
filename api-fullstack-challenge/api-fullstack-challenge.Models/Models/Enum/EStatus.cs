using System.ComponentModel;

namespace api_fullstack_challenge.Models.Enum
{
    public enum EStatus
    {
        [Description("draft")]
        Draft = 0,
        [Description("imported")]
        Imported = 1
    }
}
