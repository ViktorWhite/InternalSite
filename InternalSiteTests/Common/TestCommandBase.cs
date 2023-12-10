using InternalSite.Persistence;

namespace InternalSiteTests.Common
{
    /// <summary>
    /// Класс создает экземпляр тестовой базы данных
    /// </summary>
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly InternalSiteDbContext Context;

        public TestCommandBase()
        {
            Context = InternalSiteContextFactory.Create();
        }

        public void Dispose()
        {
            InternalSiteContextFactory.Destroy(Context);
        }
    }
}
