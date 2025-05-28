using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qalakar.Data
{
    public class PhotoService
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;

        public PhotoService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _connectionString = _configuration.GetConnectionString("DefaultConnection") 
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public async Task AddPhotoAsync(Photo photo)
        {
            using SqlConnection conn = new(_connectionString);
            string query = "INSERT INTO Photos (UserId, Title, Description, ImageUrl, UploadedAt) VALUES (@UserId, @Title, @Description, @ImageUrl, @UploadedAt)";
            SqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@UserId", photo.UserId);
            command.Parameters.AddWithValue("@Title", photo.Title);
            command.Parameters.AddWithValue("@Description", photo.Description);
            command.Parameters.AddWithValue("@ImageUrl", photo.ImageUrl);
            command.Parameters.AddWithValue("@UploadedAt", photo.UploadedAt);
            await conn.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<Photo>> GetAllPhotosAsync()
        {
            List<Photo> photos = new();
            using SqlConnection conn = new(_connectionString);
            string query = @"
                SELECT p.Id, p.UserId, p.Title, p.Description, p.ImageUrl, p.UploadedAt, u.FirstName, u.LastName
                FROM Photos p
                INNER JOIN Users u ON p.UserId = u.Id
                ORDER BY p.UploadedAt DESC";
            SqlCommand command = new(query, conn);
            await conn.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                photos.Add(new Photo
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    UserId = Convert.ToInt32(reader["UserId"]),
                    Title = reader["Title"].ToString() ?? "",
                    Description = reader["Description"].ToString() ?? "",
                    ImageUrl = reader["ImageUrl"].ToString() ?? "",
                    UploadedAt = Convert.ToDateTime(reader["UploadedAt"]),
                    UploadedBy = $"{reader["FirstName"]} {reader["LastName"]}".Trim()
                });
            }
            return photos;
        }
    }

    public class Photo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public DateTime UploadedAt { get; set; }
        public string UploadedBy { get; set; } = "";
    }
}