using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dropbox.Model;
using File = System.IO.File;

namespace Dropbox.WinForms
{
	public partial class MainForm : Form
	{
		private readonly Guid _userId = new Guid("ef084461-c009-4613-89c4-6e27699970b1");
		private readonly ServiceClient _client;

		public MainForm()
		{
			InitializeComponent();
			_client = new ServiceClient("http://localhost:62315/api/", _userId);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			RefreshFileList();
			lbUserName.Text = _client.GetUser().Name;
		}

		private void RefreshFileList()
		{
			lbFiles.DataSource = _client.GetUserFiles();
		}

		private void btAddFile_Click(object sender, EventArgs e)
		{
			try
			{
				using (var dialog = new OpenFileDialog())
				{
					if (dialog.ShowDialog() == DialogResult.OK)
					{
						var fileContent = File.ReadAllBytes(dialog.FileName);
						var file = new Model.File
						{
							Name = Path.GetFileName(dialog.FileName),
							Owner = new User
							{
								Id = _userId
							}
						};
						var fileId = _client.CreateFile(file);
						_client.UploadFileContent(fileId, fileContent);
						RefreshFileList();
						MessageBox.Show($"Файл {file.Name} успешно загружен", "Загрузка файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show($"Не удалось загрузить файл, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btDeleteFile_Click(object sender, EventArgs e)
		{
			try
			{
				var item = lbFiles.SelectedItem as Model.File;
				if (item != null)
				{
					_client.DeleteFile(item.Id);
					RefreshFileList();
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show($"Не удалось удалить файл, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btDownload_Click(object sender, EventArgs e)
		{
			try
			{
				var item = lbFiles.SelectedItem as Model.File;
				if (item != null)
				{
					using (var dialog = new SaveFileDialog())
					{
						dialog.FileName = item.Name;
						if (dialog.ShowDialog() == DialogResult.OK)
						{
							var content = _client.DownloadFile(item.Id);
							File.WriteAllBytes(dialog.FileName, content);
						}
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show($"Не удалось скачать файл, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
