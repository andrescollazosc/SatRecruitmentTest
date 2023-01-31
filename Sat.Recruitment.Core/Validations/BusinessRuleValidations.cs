using Sat.Recruitment.Core.Abstractions;
using Sat.Recruitment.Core.Entities;
using Sat.Recruitment.Core.Enums;
using Sat.Recruitment.Core.Exceptions;
using System.Collections.Generic;
using System.IO;

namespace Sat.Recruitment.Core.Validations
{
    public class BusinessRuleValidations : IBusinessRuleValidations
    {
        private readonly List<User> _users;

        public BusinessRuleValidations()
        {
            _users = new List<User>();
            GetUsers();
        }

        public void ValidateIfUserExits(User entity)
        {
            foreach (var user in _users)
            {
                if (user.Email == entity.Email || user.Phone == entity.Phone ||
                    (user.Name == entity.Name && user.Address == entity.Address))
                {
                    throw new UserException("User is duplicated");
                }
            }
        }

        private void GetUsers()
        {
            var reader = ReadUsersFromFile();

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var user = new User
                {
                    Name = line.Split(',')[0].ToString(),
                    Email = line.Split(',')[1].ToString(),
                    Phone = line.Split(',')[2].ToString(),
                    Address = line.Split(',')[3].ToString(),
                    UserType = ConvertUserType(line.Split(',')[4].ToString()),
                    Money = decimal.Parse(line.Split(',')[5].ToString()),
                };
                _users.Add(user);
            }
            reader.Close();
        }

        private StreamReader ReadUsersFromFile()
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";
            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);

            return reader;
        }

        private UserType ConvertUserType(string userType)
        {
            return userType switch
            {
                "1" => UserType.Normal,
                "2" => UserType.Normal,
                "3" => UserType.Premium
            };
        }
    }
}
