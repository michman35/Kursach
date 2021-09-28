using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meneger
{
	class Copy
	{
		public void copyFile(string path, string newpath)
		{
			try
			{
				var ext = Path.GetExtension(path);
				var ext1 = Path.GetExtension(newpath);

				if(!string.IsNullOrWhiteSpace(ext))
				{
					File.Copy(path,newpath);
				}
				else
				{
					
					Directory.Move(path,newpath);
				}
				Console.WriteLine("файл/Каталог скопирован");
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

	}

}

