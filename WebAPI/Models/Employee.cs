using SourceGenSampleAPI.Attributes;
using System;

namespace SourceGenAPI.Models
{
    [MapModel]
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }

        [MapModelPropertyName("Email")]
        public string Email2 { get; set; }

        [MapModelIgnore]
        public int MyProperty { get; set; }
    }

}
