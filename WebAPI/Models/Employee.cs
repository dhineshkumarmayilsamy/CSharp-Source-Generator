using SourceGenSampleAPI.Attributes;
using System;

namespace SourceGenSampleAPI.Models
{
    [MapModel]
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }

        [MapModelIgnore]
        public int MyProperty { get; set; }
    }

}
