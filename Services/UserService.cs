using Microsoft.AspNetCore.Identity;
using Hired1stTest.Services.Interfaces;
using Hired1stTest.Models;
using MongoDB.Driver;
using Hired1stTest.DTO;

namespace Hired1stTest.Services
{
    public class UserService : IUser
    {
        private readonly MongoDBService _mongoDBService;

        public UserService(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        public bool CreateUser(RegisterDTO newUser)
        {
            bool result = false;
            if (newUser == null || newUser.Password != newUser.PasswordConfrim)
            {
                result = false;
            }
            else
            {
                User user = new User() 
                {
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Email = newUser.Email
                };
                user.SetPassword(newUser.Password);
                _mongoDBService._usersCollection.InsertOne(user);
                result = true;
            }
            return result;
        }

        public int DeleteUser(string email)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Email, email);

            if (filter != null)
            {
                var result = _mongoDBService._usersCollection.DeleteOne(filter);

                if (result.IsAcknowledged)
                {
                    return 1;
                }
                return -1;
            }
            return 1;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = _mongoDBService._usersCollection.Find(_ => true).ToList();
            return users;
        }

        public User GetUserByEmail(string email)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Email, email);
            var user = _mongoDBService._usersCollection.Find(filter).FirstOrDefault() ?? null;
            return user;
        }

        public int UpdateUser(User user)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Email, user.Email);
            var userExist = _mongoDBService._usersCollection.Find(x => x.Email == user.Email).FirstOrDefault() ?? null;
            if (userExist != null)
            {
                userExist.FirstName = user.FirstName;
                userExist.LastName = user.LastName;
                userExist.SetPassword(user.Password);

                var result = _mongoDBService._usersCollection.ReplaceOne(filter, userExist);

                if (result.IsAcknowledged && result.ModifiedCount > 0)
                {
                    return 1;
                }
                return -1;
            }
            return -1;
        }

        public User LoginUser(LoginDTO cred) 
        {
            var filter = Builders<User>.Filter.Eq(r => r.Email, cred.Email);
            User user = _mongoDBService._usersCollection.Find(filter).FirstOrDefault();

            return user;
        }

        public int UpdatePassword(ForgotPassDTO dto) 
        {
            var filter = Builders<User>.Filter.Eq(r => r.Email, dto.Email);
            var update
        }
    }
}
