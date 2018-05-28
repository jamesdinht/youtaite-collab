using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collab.API.DAL;
using Collab.API.Models;
using Collab.API.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Collab.API.BLL
{
    public class GroupRepository : ARepository<Group>
    {
        public GroupRepository(CollabContext db)
            : base(db)
        { }
        
        public async override Task<bool> DeleteAsync(int id)
        {
            Group groupToBeDeleted = await GetByIdAsync(id);
            if (groupToBeDeleted == null)
            {
                throw new KeyNotFoundException(IncorrectKeyMessage(id));
            }

            db.Groups.Remove(groupToBeDeleted);
            int rowsAffected = await db.SaveChangesAsync();

            return rowsAffected > 0;
        }
    }
}