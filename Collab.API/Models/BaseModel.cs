using System;

namespace Collab.API.Models
{
    /// <summary>
    /// Abstract model representing a data entity.
    /// </summary>
    public abstract class BaseModel
    {
        public int Id { get; set; }
    }
}