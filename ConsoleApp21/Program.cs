using System;
using System.Text;
using System.IO;


namespace ConsoleApp21
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				string abc = "";
				Console.Write("Введите путь к файлу: ");
				string fileName = Console.ReadLine();
				Console.WriteLine("Введите текст: ");
				string s = Convert.ToString(Console.ReadLine());
				Console.Write("Введите букву: ");
				char b = Convert.ToChar(Console.ReadLine());
				var text = s.ToLower().Split(new[] { ' ', '.', ',', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
				FileStream f = new FileStream(fileName, FileMode.Create);
				BinaryWriter fOut = new BinaryWriter(f);

				fOut.Write(s);
				fOut.Close();

				f = new FileStream(fileName, FileMode.Open);
				BinaryReader fIn = new BinaryReader(f);

				string str = "";
				int a = 0;

				while (fIn.PeekChar() > 0)
				{
					abc = fIn.ReadString();
					Console.WriteLine("Содержимое файла: "+abc);
				}

				for (int i = 0; i < text.Length; ++i)
				{
					if (text[i][0] == b)
					{
						str += (text[i] + " ");
						a = 1;
					}
				}
				if (a == 1)
					Console.Write("Слова, начинающиеся с буквы [" + b + "]: " + str);
				else Console.Write("Слов, начинающихся на букву - " + b + ", в файле нет!");
				fIn.Close();
				f.Close();
			}
			catch { Console.Write("Некорректный ввод!"); }
		}

	}
}
	

