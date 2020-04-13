using System.Collections.Generic;

namespace PeopleManagement.Data
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> People { get; set; }
    }
}
