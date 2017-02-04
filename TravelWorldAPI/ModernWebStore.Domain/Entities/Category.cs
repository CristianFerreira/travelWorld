
using ModernWebStore.Domain.Scopes;

namespace ModernWebStore.Domain.Entities
{
    public class Category
    {
  
        public int Id { get; set; }
        public string name { get; set; }

        public void Register()
        {
            if (!this.CreateCategoryScopeIsValid())
                return;
        }

        public void UpdateCategory(string name)
        {
            if (!this.UpdateCategoryScopeIsValid(name))
                return;
            this.name = name;
        }
    }
}
