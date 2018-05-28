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

        public async override Task<bool> UpdateAsync(int id, Group updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ArgumentNullException(nameof(updatedEntity));
            }

            Group groupToBeUpdated = await GetByIdAsync(id);
            if (groupToBeUpdated == null)
            {
                throw new KeyNotFoundException(IncorrectKeyMessage(id, nameof(Group)));
            }

            db.Entry(updatedEntity).State = EntityState.Modified;
            int rowsAffected = await db.SaveChangesAsync();

            return rowsAffected > 0;
        }
        
        public async override Task<bool> DeleteAsync(int id)
        {
            Group groupToBeDeleted = await GetByIdAsync(id);
            if (groupToBeDeleted == null)
            {
                throw new KeyNotFoundException(IncorrectKeyMessage(id, nameof(Group)));
            }

            db.Groups.Remove(groupToBeDeleted);
            int rowsAffected = await db.SaveChangesAsync();

            return rowsAffected > 0;
        }
    }
}