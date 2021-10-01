using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meneger
{
	class Info
	{
		public void infoFile(string path)// Метод описывающий функцию запроса информации
		{
			try
			{
				var ext = Path.GetExtension(path);
				var fileName = Path.GetFileName( path);
				var time = File.GetCreationTime(path);
				var dirName = Path.GetDirectoryName(path);
			 
				if(!string.IsNullOrWhiteSpace(ext))//условие проверяющие наличие  файл/папка 
				{
					Console.WriteLine("Имя файла: " + fileName );
					Console.WriteLine("Размер файла: " + new FileInfo(path).Length);
					Console.WriteLine("Время создания файла: " + time.ToString() );
				}
				else
				{
					var s = new DirectoryInfo(path).GetFiles().Sum(x => x.Length);
					Console.WriteLine("Имя каталога: " + dirName);
					Console.WriteLine("Размер каталога: " + s );
					Console.WriteLine("Время создания каталога: " + time.ToString());
				}

				Console.WriteLine("Информация о файле/каталоге");
				
			} 
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

		}
	
	}
}
