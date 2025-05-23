using System;
using System.Xml.Serialization;

namespace StudentApp
{
    [Serializable]
    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Group { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName} - {Group}";
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}