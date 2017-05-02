using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Model;

namespace Dropbox.DataAccess.Sql
{
	public class UsersRepository : IUsersRepository
	{
		private readonly string _connectionString;

		public UsersRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		public User Add(string name, string email)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				using (var command = connection.CreateCommand())
				{
					var userId = Guid.NewGuid();
					command.CommandText = "insert into users values (@id, @name, @email)";
					command.Parameters.AddWithValue("@id", userId);
					command.Parameters.AddWithValue("@name", name);
					command.Parameters.AddWithValue("email", email);
					command.ExecuteNonQuery();
					return new User
					{
						Id = userId,
						Email = email,
						Name = name
					};
				}
			}
		}

		public void Delete(Guid id)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText = "delete from users where id = @id";
					command.Parameters.AddWithValue("@id", id);
					command.ExecuteNonQuery();
				}
			}
		}

		public User Get(Guid id)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				using (var command = connection.CreateCommand())
				{
					command.CommandText = "select id, name, email from users where id = @id";
					command.Parameters.AddWithValue("@id", id);
					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							return new User
							{
								Email = reader.GetString(reader.GetOrdinal("email")),
								Id = reader.GetGuid(reader.GetOrdinal("id")),
								Name = reader.GetString(reader.GetOrdinal("name"))
							};
						}
						throw new ArgumentException("user not found");
					}
				}
			}
		}
	}
}
