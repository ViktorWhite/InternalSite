namespace InternalSite.Application.Person.Queries.Common
{
    /// <summary>
    /// View-model сотрудника
    /// </summary>
    public class PersonVM
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Отчество сотрудника
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// День рождения сотрудника
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Телефонный номер сотрудника
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Идентификатор структурного подразделения сотрудника
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Идентификатор должности сотрудника
        /// </summary>
        public int PositionId { get; set; }

        /// <summary>
        /// Список навыков сотрудника
        /// </summary>
        public List<SkillOfPersonVM>? SkillsOfPersonVM { get; set; }
    }
}
