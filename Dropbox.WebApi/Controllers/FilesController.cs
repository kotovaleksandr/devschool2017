using System;
using System.Threading.Tasks;
using System.Web.Http;
using Dropbox.DataAccess;
using Dropbox.DataAccess.Sql;
using File = Dropbox.Model.File;

namespace Dropbox.WebApi.Controllers
{
	public class FilesController : ApiController
	{
		private const string ConnectionString = "Data Source=106SV0013.digdes.com;Initial Catalog=dropbox;Integrated Security=False;User ID=sa; Password=";
		private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
		private readonly IFilesRepository _filesRepository;

		public FilesController()
		{
			_filesRepository = new FilesRepository(ConnectionString, _usersRepository);
		}

		[HttpPost]
		public File CreateFile(File file)
		{
			return _filesRepository.Add(file);
		}

		[HttpPut]
		[Route("api/files/{id}/content")]
		public async Task UpdateFileContent(Guid id)
		{
			var bytes = await Request.Content.ReadAsByteArrayAsync();
			_filesRepository.UpdateContent(id, bytes);
		}

		[HttpDelete]
		[Route("api/files/{id}")]
		public void Delete(Guid id)
		{
			_filesRepository.Delete(id);
		}

		[HttpGet]
		[Route("api/files/{id}/content")]
		public byte[] GetFileContent(Guid id)
		{
			return _filesRepository.GetContent(id);
		}
	}
}
