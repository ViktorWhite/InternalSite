namespace InternalSite.Application.Category.Queries.Common
{
    /// <summary>
    /// View-model структурного подразделения
    /// </summary>
    public class CategoryVM
    {
        /// <summary>
        /// Идентификатор структурного подразделения
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование структурного подразделения
        /// </summary>
        public string? Name { get; set; }
    }
}
