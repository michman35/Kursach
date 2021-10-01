using System;
using System.Collections.Generic;
using System.IO;
using static System.Net.WebRequestMethods;

namespace meneger
{
	class Program
	{
		static void Main(string[] args)
		{
			string dirname = "C:\\";

			if(Directory.Exists(dirname))
			{
				Console.WriteLine("подкаталоги");
				string[] dirs = Directory.GetDirectories(dirname);
				var filesData = new List<DirictoryData>();
				var root = new DirictoryData
				{
					Path = dirname,
					Files = new List<FileData>(),
				};
				filesData.Add(root);
				GetFiletree(dirs, filesData); 
				GetFiles(dirname, root.Files);
				foreach(var file in filesData)
				{
					Console.WriteLine(file.Path);
					foreach(var item in file.Files) 
					{
						Console.WriteLine(item.Path);
					}
				}
				while(true) // цикл позволяющий приложению не закрываться после выполнение оперций 
				{
					Console.WriteLine("==================================================================");
					Console.WriteLine("1.Delete");
					Console.WriteLine("2.Copy");
					Console.WriteLine("3.Info size ");
					Console.WriteLine("4.Exit ");

					Console.WriteLine("==================================================================");
					string comment = Console.ReadLine();

					if(comment == "1")
					{
						Console.WriteLine("введите путь до файла/папки котрый хотите удалить");
						string path = Console.ReadLine();
						Delete delete = new Delete();//создание обьекта 
						delete.deleteFile(path);//вывоз метода удаления по указоному пути
					}
					if(comment == "2")
					{
						Console.WriteLine("введите путь до файла/папки котрый хотите скопировать ");
						string path = Console.ReadLine();
						Console.WriteLine("введите путь куда копировать ");
						string newpath = Console.ReadLine();
						Copy copy = new Copy();//создание обьекта 
						copy.copyFile(path, newpath);//вывоз метода копирования по указоному пути
					}
					if(comment == "3")
					{
						Console.WriteLine("введите путь до файла/папки о котором хотите узнать информацию ");
						string path = Console.ReadLine();
						Info info = new Info();//создание обьекта 
						info.infoFile(path);//вывоз метода запроса информации по указоному пути
					}
					if (comment=="4")
					{
						Environment.Exit(0);
						
					}
				}
			}
		}
		static void GetFiletree(string[] dirs, List<DirictoryData> folders)//метод определяющий каталоги 
		{
			foreach(string dir in dirs)
			{
				Console.WriteLine(dir);
				Console.WriteLine("файлы");
				var folderData = new DirictoryData
				{
					Path = dir,
					Files = new List<FileData>(),
				};
				GetFiles(dir, folderData.Files);
				folders.Add(folderData);
				var childDirs= Directory.GetDirectories(dir);
				if (childDirs.Length>0)
				{
					GetFiletree(childDirs, folders);
				}
			}
			
		}

		static void GetFiles(string dir, List<FileData> filesData)// метод определяющий файлы 
		{

			string[] files = Directory.GetFiles(dir);
			foreach(string file in files)
			{
				filesData.Add(new FileData { Path = file }); 
			}
		}


	}
}

