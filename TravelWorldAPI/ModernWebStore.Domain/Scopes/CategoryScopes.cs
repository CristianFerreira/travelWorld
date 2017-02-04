
using ModernWebStore.Domain.Entities;
using ModernWebStore.SharedKernel.Validation;

namespace ModernWebStore.Domain.Scopes
{
    public static class CategoryScopes
    {
        public static bool CreateCategoryScopeIsValid(this Category category)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotEmpty(category.name, "O nome é obrigatório"),
                AssertionConcern.AssertLength(category.name, 3, 45,"Nome deve ter entre 3 a 45 caracteres")
        
             );
        }

        public static bool UpdateCategoryScopeIsValid(this Category category, string name)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotEmpty(name, "O nome é obrigatório"),
               AssertionConcern.AssertLength(name, 3, 45, "Nome deve ter entre 3 a 45 caracteres")
            );
        }
    }
}
