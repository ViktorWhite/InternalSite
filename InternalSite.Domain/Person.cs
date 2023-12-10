namespace InternalSite.Domain
{
    /// <summary>
    /// Информация о сотруднике, также содержит в себе информацию навыках, которыми обладает, с оценкой по 10 бальной шкале
    /// </summary>
    public class Person
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
        /// Дата рождения сотрудника
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Номер телефона сотрудника
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Идентификатор структурного подразделения, в котором работает сотрудник
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Идентификатор должности сотрудника
        /// </summary>
        public int PositionId { get; set; }

        /// <summary>
        /// Коллекция навыков сотрудника с их оценкой по 10 шкале
        /// </summary>
        public List<SkillOfPerson> SkillsOfPerson { get; set; } = new List<SkillOfPerson>();
    }
}
