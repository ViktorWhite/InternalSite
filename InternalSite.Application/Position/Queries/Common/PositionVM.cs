namespace InternalSite.Application.Position.Queries.Common
{
    /// <summary>
    /// View-model должности
    /// </summary>
    public class PositionVM
    {
        /// <summary>
        /// Идентификатор должности
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование должности
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Идентификатор структурного подразделения
        /// </summary>
        public int CategoryId { get; set; }
    }
}
