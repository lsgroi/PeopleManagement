using PeopleManagement.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PeopleManagement.Models
{
    public class AddPerson
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a group")]
        public int GroupId { get; set; }
        public List<Group> Groups { get; set; }
    }

}
