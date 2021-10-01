using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meneger
{
	class Delete
	{
		
		public void deleteFile(string path)// Метод описывающий функцию удаления
		{
			try
			{
				var ext = Path.GetExtension(path);
				if(!string.IsNullOrWhiteSpace(ext))//условие проверяющие наличие  файл/папка 
				{
					File.Delete(path);

				}
				else
				{
					Directory.Delete(path);
				}

				Console.WriteLine("файл/каталог удален");
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

		}


		



	}
}
