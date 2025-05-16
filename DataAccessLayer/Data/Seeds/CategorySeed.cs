using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Data.Seeds
{
    public static class CategorySeed
    {
        public static DataBuilder GenerateCategorySeed(this EntityTypeBuilder entity)
        {
            var categorySeed = Enum
                .GetValues(typeof(CategoryEnum))
                .Cast<CategoryEnum>()
                .Select(x => new Category
                {
                    Id = (int)x,
                    Name = x.ToString()
                });
            return entity.HasData(categorySeed);
        }
    }
}
