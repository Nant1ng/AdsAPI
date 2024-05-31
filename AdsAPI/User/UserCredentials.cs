namespace AdsAPI.User
{
    public class UserCredentials
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel()
            {
                UserName = "ThaRealest",
                EmailAddress = "andressantana99@hotmail.se",
                Password = "admin",
                GivenName = "Andrés",
                SurName = "Santana",
                Role = "Admin",
            },
            new UserModel()
            {
                UserName = "richard_admin",
                EmailAddress = "richard_admin@email.se",
                Password = "passwordAdmin",
                GivenName = "Richard",
                SurName = "Chalk",
                Role = "Admin",
            },
            new UserModel()
            {
                UserName = "richard_user",
                EmailAddress = "richard_user@email.se",
                Password = "passwordUser",
                GivenName = "Richard",
                SurName = "Chalk",
                Role = "User",
            }
        };
    }
}
