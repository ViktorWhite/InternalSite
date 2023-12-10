namespace InternalSite.WebApi.Models
{
    /// <summary>
    /// Dto-model изменяемого сотрудника
    /// </summary>
    public class UpdatePersonDto
    {
        /// <summary>
        /// Идентификатор изменяемого сотрудника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Измененное имя сотрудника
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Измененное фамилия сотрудника
        /// </summary>
        public string Surname { get; set; } = string.Empty;

        /// <summary>
        /// Измененное отчество сотрудника
        /// </summary>
        public string Patronymic { get; set; } = string.Empty;

        /// <summary>
        /// Измененная дата рождения сотрудника
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Измененный номер телефона сотрудника
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Измененный идентификатор структурного подразделения
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Измененный идентификатор должности сотрудника
        /// </summary>
        public int PositionId { get; set; }

        /// <summary>
        /// Измененный список навыков сотрудника
        /// </summary>
        public List<UpdateSkillOfPersonDto> UpdateSkillsOfPersonDto { get; set; } = new List<UpdateSkillOfPersonDto>();
    }

    /// <summary>
    /// Измененный навык сотрудника
    /// </summary>
    public class UpdateSkillOfPersonDto
    {
        /// <summary>
        /// Идентификатор инфомрации об измененном навыке
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Измененный идентификатор навыка 
        /// </summary>
        public int SkillId { get; set; }

        /// <summary>
        /// Измененный уровень навыка по 10 шкале
        /// </summary>
        public int Level { get; set; }
    }
}
