using Entities;
using System.Reflection.Metadata;
using System.Text.Json;

namespace Resorces
{
    public class Repository
    {
        private static string pathFile = "M:/Web Api/WebApiProject/Resorces/user.txt";

        public User addUser(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(pathFile).Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(pathFile, userJson + Environment.NewLine);
            return user;
        }

        public User GetUserByUsarNameAndPassword(string userName, string password)
        {
            using (StreamReader reader = System.IO.File.OpenText(pathFile))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserName == userName && user.Password == password)
                        return user;
                }
            }
            return null;
        }

        public void update(int id, User userUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(pathFile))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(pathFile);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userUpdate));
                System.IO.File.WriteAllText(pathFile, text);
            }
        }

    }
   
}