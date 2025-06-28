using System;
using System.Collections.Generic;

namespace WEB_API_CRUD_ASPCORE.Models
{
    public partial class StudentCrud
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Language { get; set; }
    }
}
