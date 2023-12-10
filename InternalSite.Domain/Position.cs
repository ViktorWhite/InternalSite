namespace InternalSite.Domain
{
    /// <summary>
    /// Должности сотрудников структурного подразделения
    /// </summary>
    public class Position
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
        /// Идентификатор структурного подразделения должности
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Сотрудники работающие по этой должности
        /// </summary>
        public List<Person>? Persons { get; set; } 

        /// <summary>
        /// Необходимые навыки, которые необходимы для данной должности
        /// </summary>
        public List<SkillOfPosition>? SkillsOfPosition { get; set; } 
    }
}
