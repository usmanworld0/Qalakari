using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Qalakar.Data;

namespace Qalakar.Data
{
    public class OpportunityService
    {
        private readonly string _connectionString;

        public OpportunityService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") 
                ?? throw new ArgumentNullException(nameof(configuration), "Connection string 'DefaultConnection' not found.");
        }

        public async Task<(bool Success, string? ErrorMessage)> AddOpportunityAsync(Opportunity opportunity)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand(
                        @"INSERT INTO Opportunities (Title, Description, Budget, EventType, Location, ContactEmail, UserId, EventDates, UserName)
                          VALUES (@Title, @Description, @Budget, @EventType, @Location, @ContactEmail, @UserId, @EventDates, @UserName);
                          SELECT SCOPE_IDENTITY();",
                        connection);

                    command.Parameters.AddWithValue("@Title", opportunity.Title);
                    command.Parameters.AddWithValue("@Description", opportunity.Description);
                    command.Parameters.AddWithValue("@Budget", opportunity.Budget);
                    command.Parameters.AddWithValue("@EventType", opportunity.EventType);
                    command.Parameters.AddWithValue("@Location", opportunity.Location);
                    command.Parameters.AddWithValue("@ContactEmail", opportunity.ContactEmail);
                    command.Parameters.AddWithValue("@UserId", opportunity.UserId);
                    command.Parameters.AddWithValue("@EventDates", opportunity.EventDates ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@UserName", opportunity.UserName ?? (object)DBNull.Value);

                    var newId = await command.ExecuteScalarAsync();
                    opportunity.Id = newId != null ? Convert.ToInt32(newId) : 0;

                    if (opportunity.Id <= 0)
                    {
                        return (false, "Failed to insert opportunity into the database.");
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

        public async Task<List<Opportunity>> GetOpportunitiesByUserIdAsync(int userId)
        {
            var opportunities = new List<Opportunity>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand(
                        @"SELECT Id, Title, Description, Budget, EventType, Location, ContactEmail, UserId, EventDates, UserName
                          FROM Opportunities
                          WHERE UserId = @UserId",
                        connection);

                    command.Parameters.AddWithValue("@UserId", userId);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            opportunities.Add(new Opportunity
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                Budget = reader.GetDecimal(reader.GetOrdinal("Budget")),
                                EventType = reader.GetString(reader.GetOrdinal("EventType")),
                                Location = reader.GetString(reader.GetOrdinal("Location")),
                                ContactEmail = reader.GetString(reader.GetOrdinal("ContactEmail")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                EventDates = reader.IsDBNull(reader.GetOrdinal("EventDates")) ? "" : reader.GetString(reader.GetOrdinal("EventDates")),
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

            return opportunities;
        }

        public async Task<List<Opportunity>> GetAllOpportunitiesAsync()
        {
            var opportunities = new List<Opportunity>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand(
                        @"SELECT Id, Title, Description, Budget, EventType, Location, ContactEmail, UserId, EventDates, UserName
                          FROM Opportunities",
                        connection);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            opportunities.Add(new Opportunity
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                Budget = reader.GetDecimal(reader.GetOrdinal("Budget")),
                                EventType = reader.GetString(reader.GetOrdinal("EventType")),
                                Location = reader.GetString(reader.GetOrdinal("Location")),
                                ContactEmail = reader.GetString(reader.GetOrdinal("ContactEmail")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                EventDates = reader.IsDBNull(reader.GetOrdinal("EventDates")) ? "" : reader.GetString(reader.GetOrdinal("EventDates")),
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
            return opportunities;
        }

        public async Task<Opportunity?> GetOpportunityByIdAsync(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand(
                        @"SELECT Id, Title, Description, Budget, EventType, Location, ContactEmail, UserId, EventDates, UserName
                          FROM Opportunities
                          WHERE Id = @Id",
                        connection);

                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Opportunity
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                Budget = reader.GetDecimal(reader.GetOrdinal("Budget")),
                                EventType = reader.GetString(reader.GetOrdinal("EventType")),
                                Location = reader.GetString(reader.GetOrdinal("Location")),
                                ContactEmail = reader.GetString(reader.GetOrdinal("ContactEmail")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                EventDates = reader.IsDBNull(reader.GetOrdinal("EventDates")) ? "" : reader.GetString(reader.GetOrdinal("EventDates")),
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