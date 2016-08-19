using SX.WebCore;

namespace LR.WebUI.Infrastructure
{
    public sealed class DbContext : SxDbContext
    {
        public DbContext() : base("DbContext") { }
    }
}