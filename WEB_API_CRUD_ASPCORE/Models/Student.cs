using System;
using System.Collections.Generic;

namespace WEB_API_CRUD_ASPCORE.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? English { get; set; }
        public int? Math { get; set; }
    }
}
