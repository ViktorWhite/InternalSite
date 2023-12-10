namespace InternalSite.Domain
{
    /// <summary>
    /// Структурные подразделения компании
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Идентификатор структурного подразделения
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название структурного подразделения
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Должности структурного подразделения
        /// </summary>
        public List<Position>? Positions { get; set; }
    }
}
