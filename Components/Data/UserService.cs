using Microsoft.Data.SqlClient;

namespace Qalakar.Data
{
    public class UserService
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _connectionString = _configuration.GetConnectionString("DefaultConnection") 
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public async Task AddUserAsync(User user)
        {
            using SqlConnection conn = new(_connectionString);
            string query = "INSERT INTO Users (FirstName, LastName, Age, Email, Password) VALUES (@FirstName, @LastName, @Age, @Email, @Password)";
            SqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@FirstName", user.FirstName);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@Age", user.Age);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);
            await conn.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task<(bool IsValid, string? FullName)> ValidateUserAsync(string email, string password)
        {
            using SqlConnection conn = new(_connectionString);
            string query = "SELECT FirstName, LastName FROM Users WHERE Email = @Email AND Password = @Password";
            SqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", password);
            await conn.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                string firstName = reader["FirstName"].ToString() ?? "";
                string lastName = reader["LastName"].ToString() ?? "";
                string fullName = $"{firstName} {lastName}".Trim();
                return (true, fullName);
            }
            return (false, null);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            using SqlConnection conn = new(_connectionString);
            string query = "SELECT Id, FirstName, LastName, Age, Email FROM Users WHERE Email = @Email";
            SqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@Email", email);
            await conn.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new User
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    FirstName = reader["FirstName"].ToString() ?? "",
                    LastName = reader["LastName"].ToString() ?? "",
                    Age = Convert.ToInt32(reader["Age"]),
                    Email = reader["Email"].ToString() ?? ""
                };
            }
            return null;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            using SqlConnection conn = new(_connectionString);
            string query = "SELECT Id, FirstName, LastName, Age, Email FROM Users WHERE Id = @Id";
            SqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@Id", id);
            await conn.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new User
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    FirstName = reader["FirstName"].ToString() ?? "",
                    LastName = reader["LastName"].ToString() ?? "",
                    Age = Convert.ToInt32(reader["Age"]),
                    Email = reader["Email"].ToString() ?? ""
                };
            }
            return null;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            using SqlConnection conn = new(_connectionString);
            string query = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Age = @Age WHERE Email = @Email";
            SqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@FirstName", user.FirstName);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@Age", user.Age);
            command.Parameters.AddWithValue("@Email", user.Email);
            await conn.OpenAsync();
            int rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
    }
}