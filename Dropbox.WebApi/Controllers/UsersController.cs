using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dropbox.DataAccess;
using Dropbox.DataAccess.Sql;
using Dropbox.Model;

namespace Dropbox.WebApi.Controllers
{
	public class UsersController : ApiController
	{
		private const string ConnectionString = "Data Source=106SV0013.digdes.com;Initial Catalog=dropbox;Integrated Security=False;User ID=sa; Password=";
		private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
		private readonly IFilesRepository _filesRepository;

		public UsersController()
		{
			_filesRepository = new FilesRepository(ConnectionString, _usersRepository);
		}

		/// <summary>
		/// Create s
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		[HttpPost]
		public User CreateUser([FromBody]User user)
		{
			return _usersRepository.Add(user.Name, user.Email);
		}

		[HttpGet]
		[Route("api/users/{id}")]
		public User GetUser(Guid id)
		{
			return _usersRepository.Get(id);
		}

		[HttpDelete]
		public void DeleteUser(Guid id)
		{
			Log.Logger.ServiceLog.Info("Delete user with id: {0}", id);
			_usersRepository.Delete(id);
		}

		[Route("api/users/{id}/files")]
		[HttpGet]
		public IEnumerable<File> GetUserFiles(Guid id)
		{
			return _filesRepository.GetUserFiles(id);
		}

		[HttpPut]
		[Route("api/users/{id}")]
		public User UpdateUser(Guid id, [FromBody] User user)
		{
			return null;
		}
	}
}
