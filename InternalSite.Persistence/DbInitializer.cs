namespace InternalSite.Persistence
{
    /// <summary>
    /// Класс инициализации базы данных
    /// </summary>
    public class DbInitializer
    {
        /// <summary>
        /// Метод запускается на старте приложения и проверяет создана ли база данных, и если нет - то она 
        /// будет создана на основе context
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(InternalSiteDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
