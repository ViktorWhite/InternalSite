namespace InternalSite.Application.Person.Queries.Common
{
    /// <summary>
    /// View-model списка навыков сотрудника
    /// </summary>
    public class SkillOfPersonVM
    { 
        /// <summary>
        /// Идентификатор информации о навыке сотрудника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор должности сотрудника
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Идентификатор навыка сотрудника
        /// </summary>
        public int SkillId { get; set; }

        /// <summary>
        /// Идентификатор уровня навыка сотрудника по 10 бальной шкале
        /// </summary>
        public int Level { get; set; }
    }
}
