using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Qalakar.Data;

namespace Qalakar.Data
{
    public class GigService
    {
        private readonly string _connectionString;

        public GigService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") 
                ?? throw new ArgumentNullException(nameof(configuration), "Connection string 'DefaultConnection' not found.");
        }

        public async Task<(bool Success, string? ErrorMessage)> AddGigAsync(Gig gig)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand(
                        @"INSERT INTO Gigs (Title, Description, Price, ServiceType, City, ImageUrl, UserId, PhoneNumber, Availability, UserName)
                          VALUES (@Title, @Description, @Price, @ServiceType, @City, @ImageUrl, @UserId, @PhoneNumber, @Availability, @UserName);
                          SELECT SCOPE_IDENTITY();",
                        connection);

                    command.Parameters.AddWithValue("@Title", gig.Title);
                    command.Parameters.AddWithValue("@Description", gig.Description);
                    command.Parameters.AddWithValue("@Price", gig.Price);
                    command.Parameters.AddWithValue("@ServiceType", gig.ServiceType);
                    command.Parameters.AddWithValue("@City", gig.City);
                    command.Parameters.AddWithValue("@ImageUrl", gig.ImageUrl);
                    command.Parameters.AddWithValue("@UserId", gig.UserId);
                    command.Parameters.AddWithValue("@PhoneNumber", gig.PhoneNumber);
                    command.Parameters.AddWithValue("@Availability", gig.Availability ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@UserName", gig.UserName ?? (object)DBNull.Value);

                    var newId = await command.ExecuteScalarAsync();
                    gig.Id = newId != null ? Convert.ToInt32(newId) : 0;

                    if (gig.Id <= 0)
                    {
                        return (false, "Failed to insert gig into the database.");
                    }

                    return (true, null);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
                return (false, $"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return (false, $"Unexpected error: {ex.Message}");
            }
        }

        public async Task<List<Gig>> GetGigsByUserIdAsync(int userId)
        {
            var gigs = new List<Gig>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand(
                        @"SELECT Id, Title, Description, Price, ServiceType, City, ImageUrl, UserId, PhoneNumber, Availability, UserName
                          FROM Gigs
                          WHERE UserId = @UserId",
                        connection);

                    command.Parameters.AddWithValue("@UserId", userId);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            gigs.Add(new Gig
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                ServiceType = reader.GetString(reader.GetOrdinal("ServiceType")),
                                City = reader.GetString(reader.GetOrdinal("City")),
                                ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                Availability = reader.IsDBNull(reader.GetOrdinal("Availability")) ? "" : reader.GetString(reader.GetOrdinal("Availability")),
                                UserName = reader.IsDBNull(reader.GetOrdinal("UserName")) ? "" : reader.GetString(reader.GetOrdinal("UserName"))
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }

            return gigs;
        }

        public async Task<List<Gig>> GetAllGigsAsync()
        {
            var gigs = new List<Gig>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand(
                        @"SELECT Id, Title, Description, Price, ServiceType, City, ImageUrl, UserId, PhoneNumber, Availability, UserName
                          FROM Gigs",
                        connection);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            gigs.Add(new Gig
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                ServiceType = reader.GetString(reader.GetOrdinal("ServiceType")),
                                City = reader.GetString(reader.GetOrdinal("City")),
                                ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                Availability = reader.IsDBNull(reader.GetOrdinal("Availability")) ? "" : reader.GetString(reader.GetOrdinal("Availability")),
                                UserName = reader.IsDBNull(reader.GetOrdinal("UserName")) ? "" : reader.GetString(reader.GetOrdinal("UserName"))
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
            return gigs;
        }

        public async Task<Gig?> GetGigByIdAsync(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand(
                        @"SELECT Id, Title, Description, Price, ServiceType, City, ImageUrl, UserId, PhoneNumber, Availability, UserName
                          FROM Gigs
                          WHERE Id = @Id",
                        connection);

                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Gig
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                ServiceType = reader.GetString(reader.GetOrdinal("ServiceType")),
                                City = reader.GetString(reader.GetOrdinal("City")),
                                ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                Availability = reader.IsDBNull(reader.GetOrdinal("Availability")) ? "" : reader.GetString(reader.GetOrdinal("Availability")),
                                UserName = reader.IsDBNull(reader.GetOrdinal("UserName")) ? "" : reader.GetString(reader.GetOrdinal("UserName"))
                            };
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
            return null;
        }
    }
}