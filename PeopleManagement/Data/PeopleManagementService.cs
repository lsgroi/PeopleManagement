using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Data
{
    public interface IPeopleManagementService
    {
        Task<List<Group>> GetGroups();
        Task<Person> AddPerson(string name, int groupId);
        Task<List<Person>> Search(string name);
        Task<List<Person>> Search(string name, int groupId);
    }

    public class PeopleManagementService : IPeopleManagementService
    {
        private readonly PeopleManagementContext _context;

        public PeopleManagementService(PeopleManagementContext context)
        {
            _context = context;
        }

        public async Task<Person> AddPerson(string name, int groupId)
        {
            var group = _context.Groups.Single(x => x.Id == groupId);

            var result = await _context.AddAsync(new Person { Name = name, Group = group });

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<List<Group>> GetGroups()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<List<Person>> Search(string name)
        {
            return await _context.People
                .Include(x => x.Group)
                .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .ToListAsync();
        }

        public async Task<List<Person>> Search(string name, int groupId)
        {
            return await _context.People
                .Include(x => x.Group)
                .Where(x => x.Name.ToLower().Contains(name.ToLower()) && x.Group.Id == groupId)
                .ToListAsync();
        }
    }
}
