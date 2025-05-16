using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Data.Seeds
{
    public static class UserSeed
    {
        public static DataBuilder GenarateUserSeed(this EntityTypeBuilder entity)
        {
            User[] userSeed = [
                new User { Id = 1, Email = "admin@gmail.com", Password = "$2a$11$9fTuPgb6tL/saLLyhCR./O9NgrSBDBf0MuXSu7RFQM4XE1j1fc90u", Role = RoleEnum.Admin, CreationDate = new DateTime(2004, 10, 30)},
                new User { Id = 2, Email = "user@gmail.com", Password = "$2a$11$Od59WmYFG6dpjt.E0F8l8eM50Ggmu4HtPsEM289XmemO2dw8a1CLe", Role = RoleEnum.User, CreationDate = new DateTime(2025, 04, 22)},
            ];
            return entity.HasData(userSeed);
        }
    }
}
