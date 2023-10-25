using Entities;
using Resorces;


namespace Services
{
    public class UserServices
    {
        public int checkPassword (string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }

        private Repository repository = new Repository();

        public User addUser(User user)
        {
            int res = checkPassword(user.Password);
            if(res>2)
                repository.addUser(user);
            else return null;
            return user;
        }

        public void update(int id, User user)
        {
            repository.update(id, user);
        }

        public User GetUserByUsarNameAndPassword(string userName, string password)
        {
            return repository.GetUserByUsarNameAndPassword(userName, password);
        }

    }
}