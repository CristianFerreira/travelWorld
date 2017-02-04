
using ModernWebStore.Domain.Entities;
using System.Collections.Generic;

namespace ModernWebStore.Domain.Services
{
    public interface ICategoryApplicationService
    {
        List<Category> Get();
        List<Category> Get(int skip, int take);
        Category Get(int id);
        Category Create(Category category);
        Category Update(Category category);
        Category Delete(int id);
        List<Category> DeleteAlot(List<Category> categories);
    }
}
