using System;

namespace PeopleManagement.Data
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public Group Group { get; set; }
    }
}
