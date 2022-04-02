using System;
using System.Collections.Generic;

namespace Data.Entries
{
    public partial class EmployeeEntry
    {
        public Guid Id { get; set; }
        public Guid? AutorizedData { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string EmployeeSurname { get; set; } = null!;
        public string? EmployeePatronymic { get; set; }
        public string EmployeePhone { get; set; } = null!;
        public string EmployeeEmail { get; set; } = null!;

        public virtual AuthorizationUserEntry? AutorizedDataNavigation { get; set; }
    }
}
