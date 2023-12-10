namespace InternalSite.Domain
{
    /// <summary>
    /// Навык конкретного работника с оценкой по 10 шкале
    /// </summary>
    public class SkillOfPerson
    {
        /// <summary>
        /// Идентификатор навыка с оценкой конкретного работника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор работника
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Идентификатор навыка
        /// </summary>
        public int SkillId { get; set; }

        /// <summary>
        /// Навигационное поле для EF Core
        /// </summary>
        public Skill Skill { get; set; }

        /// <summary>
        /// Уровень навыка работника по 10 шкале
        /// </summary>
        public int Level { get; set; }
    }
}
