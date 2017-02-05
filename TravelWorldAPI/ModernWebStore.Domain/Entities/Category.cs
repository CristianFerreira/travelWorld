
using ModernWebStore.Domain.Scopes;
using System.Collections.Generic;

namespace ModernWebStore.Domain.Entities
{
    public class Category
    {
  
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }

        public void Register()
        {
            if (!this.CreateCategoryScopeIsValid())
                return;
        }

        public void UpdateCategory(string name)
        {
            if (!this.UpdateCategoryScopeIsValid(name))
                return;
            this.Name = name;
        }
    }
}
