using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzmoonGaj.Domain.DTOs
{
    public class CreateUserDto
    {
        public string Name { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string? City { get; set; }
        public int Old { get; set; }
        public DateTime ExamDate { get; set; }
        public int Duration { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? BirthDate { get; set; }
    }
}
