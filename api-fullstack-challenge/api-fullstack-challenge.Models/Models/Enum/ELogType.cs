using System.ComponentModel;

namespace api_fullstack_challenge.Models.Models.Enum
{
    public enum ELogType
    {
        [Description("Sync")]
        Sync = 0,
        [Description("Delete")]
        Delete = 1,
        [Description("Error")]
        Error = 2
    }
}
