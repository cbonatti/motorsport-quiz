using System;

namespace MotorsportQuiz.Domain.Base
{
    public abstract class EntityBase
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public void SetId(Guid id) => Id = id;
        public void SetName(string name) => Name = name;
    }
}
