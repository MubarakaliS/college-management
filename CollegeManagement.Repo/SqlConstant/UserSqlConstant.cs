namespace CollegeManagement.Repo.SqlConstant
{
    public class UserSqlConstant
    {
        public const string SELECT_USER_LIST = "SELECT * FROM users";

        public const string SELECT_USER = "SELECT * FROM users WHERE Id = @Id";

        public const string INSERT_USER = @"INSERT INTO users(Name, RegisterNumber, Email, Department,Password) VALUES (@Name,@RegisterNumber,@Email,@Department,@Password);";
    }
}
