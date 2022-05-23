using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public void GenerateId() => Id = new Guid();
    }
}
