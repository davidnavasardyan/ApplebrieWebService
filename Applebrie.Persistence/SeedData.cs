using Applebrie.Domain;

namespace Applebrie.Persistence
{
    public class SeedData
    {
        public static async Task SeedUser(ApplebrieDbContext dbContext)
        {
            if (!dbContext.UserTypes.Any())
            {
                dbContext.UserTypes.AddRange(new List<UserType>
                {
                    new UserType
                    {
                        TypeName = "General",
                        Descr = "Employee with UI login only",
                    },
                    new UserType
                    {
                        TypeName = "API",
                        Descr = "API User",
                    },
                    new UserType
                    {
                        TypeName = "Sales",
                        Descr = "Sales Employee",
                    },
                    new UserType
                    {
                        TypeName = "Unrestricted",
                        Descr = "Unrestricted External User",
                    }
                });
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Users.Any())
            {
                List<User> users = new List<User>()
                {
                    new User
                    {
                        Title = UserTitle.Mr,
                        UserTypeId = 1,
                        FirstName = "Maxwell",
                        LastName = "Baker",
                        PhoneNbr = "+1 (777) 345-2246",
                        Email = "mbaker@revisiontwo.com",
                        Country = "US",
                        City = "Kirkland",
                        State = "WA",
                        PostalCode = "98034",
                    },
                    new User
                    {
                        Title = UserTitle.Ms,
                        UserTypeId = 1,
                        FirstName = "Layla",
                        LastName = "Beauvoir",
                        PhoneNbr = "+1 (777) 765-2577",
                        Email = "lbeauvoir@revisiontwo.com",
                        Country = "US",
                        City = "Renton",
                        State = "WA",
                        PostalCode = "98057",
                    },
                    new User
                    {
                        Title = UserTitle.Ms,
                        UserTypeId = 1,
                        FirstName = "Pam",
                        LastName = "Brawner",
                        PhoneNbr = "+1 (777) 234-2200",
                        Email = "pbrawner@revisiontwo.com",
                        Country = "US",
                        City = "Renton",
                        State = "WA",
                        PostalCode = "98059",
                    },
                    new User
                    {
                        UserTypeId = 2,
                        FirstName = "Michal",
                        LastName = "Bujacek",
                        PhoneNbr = "206-321-0942",
                        Email = "mbujacek@revisiontwo.com",
                        Country = "US",
                        City = "Seattle",
                        State = "WA",
                        PostalCode = "98122",
                    },
                    new User
                    {
                        Title = UserTitle.Dr,
                        UserTypeId = 2,
                        FirstName = "David",
                        LastName = "Chubb",
                        PhoneNbr = "+1 (777) 896-8954",
                        Email = "dchubb@revisiontwo.com",
                        Country = "US",
                        City = "Seattle",
                        State = "WA",
                        PostalCode = "98122",
                    },
                    new User
                    {
                        Title = UserTitle.Dr,
                        UserTypeId = 2,
                        FirstName = "Steve",
                        LastName = "Church",
                        PhoneNbr = "+1 (777) 885-7336",
                        Email = "dchubb@revisiontwo.com",
                        Country = "US",
                        City = "Seattle",
                        State = "WA",
                        PostalCode = "98122",
                    },
                    new User
                    {
                        Title = UserTitle.Dr,
                        UserTypeId = 3,
                        FirstName = "Rick",
                        LastName = "Domenico",
                        PhoneNbr = "+1 (777) 126-4538",
                        Email = "dchubb@revisiontwo.com",
                        Country = "US",
                        City = "Bellevue",
                        State = "WA",
                        PostalCode = "98008",
                    },
                    new User
                    {
                        Title = UserTitle.Mr,
                        UserTypeId = 4,
                        FirstName = "Alberto",
                        LastName = "Jimenez",
                        PhoneNbr = "+1 (777) 678-4980",
                        Email = "ajimenez@revisiontwo.com",
                        Country = "US",
                        City = "Sammamish",
                        State = "WA",
                        PostalCode = "98074",
                    },
                    new User
                    {
                        Title = UserTitle.Mr,
                        UserTypeId = 4,
                        FirstName = "Anna",
                        LastName = "Johnson",
                        PhoneNbr = "",
                        Email = "ajohnson@revisiontwo.com",
                        Country = "US",
                        City = "Woodinville",
                        State = "WA",
                        PostalCode = "98072",
                    },
                    new User
                    {
                        Title = UserTitle.Mr,
                        UserTypeId = 4,
                        FirstName = "Eric",
                        LastName = "Killian",
                        PhoneNbr = "+1 (777) 898-4254",
                        Email = "ajohnson@revisiontwo.com",
                        Country = "US",
                        City = "Reston",
                        State = "VA",
                        PostalCode = "20190",
                    },
                    new User
                    {
                        Title = UserTitle.Mr,
                        UserTypeId = 4,
                        FirstName = "John",
                        LastName = "Kinne",
                        PhoneNbr = "+1 (777) 898-4254",
                        Email = "ajohnson@revisiontwo.com",
                        Country = "US",
                        City = "Puyallup",
                        State = "WA",
                        PostalCode = "98374",
                    },
                };
                dbContext.Users.AddRange(users);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
