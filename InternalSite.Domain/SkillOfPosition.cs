namespace InternalSite.Domain
{
    /// <summary>
    /// Навык конкретной должности
    /// </summary>
    public class SkillOfPosition
    {
        /// <summary>
        /// Идентификатор навыка конкретной должности
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор навыка
        /// </summary>
        public int SkillId { get; set; }

        /// <summary>
        /// Идентинификтор должности
        /// </summary>
        public int PositionId { get; set; }

        /// <summary>
        /// Навигационное поле для EF core
        /// </summary>
        public Skill Skill { get; set; }
    }
}
