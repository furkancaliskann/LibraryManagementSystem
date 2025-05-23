﻿using Entities.Abstract;

namespace Entities.Concrete
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
