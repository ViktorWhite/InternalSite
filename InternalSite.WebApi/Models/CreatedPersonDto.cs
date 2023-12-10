namespace InternalSite.WebApi.Models
{
    /// <summary>
    /// Dto-model создаваемого сотрудника
    public class CreatedPersonDto
    {
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string Surname { get; set; } = string.Empty;

        /// <summary>
        /// Отчество сотрудника
        /// </summary>
        public string Patronymic { get; set; } = string.Empty;

        /// <summary>
        /// День рождения сотрудника
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Телефонный номер сотрудника
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор структурного подразделения сотрудника
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Идентификатор должности сотрудника
        /// </summary>
        public int PositionId { get; set; }

        /// <summary>
        /// Список  навыков сотрудника
        /// </summary>
        public List<CreatedSkillOfPersonDto> CreatedSkillsOfPersonDto { get; set; } = new List<CreatedSkillOfPersonDto>();
    }

    /// <summary>
    /// Навыки создаваемого сотрудника
    /// </summary>
    public class CreatedSkillOfPersonDto
    {
        /// <summary>
        /// Идентификатор навыка
        /// </summary>
        public int SkillId { get; set; }

        /// <summary>
        /// Уровень навыка по 10 бальной шкале
        /// </summary>
        public int Level { get; set; }
    }
}
