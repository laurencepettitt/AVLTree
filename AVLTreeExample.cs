using System;
using static System.Console;

namespace AVLTreeExample
{
	class EmployeeRegister
	{
		public static void Main()
		{
			AVLTree<int> sortedSet = new AVLTree<int>();

			while (true)
			{
				string s = ReadLine();
				WriteLine(s);
				if (string.IsNullOrEmpty(s)) break;
				char command = s[0];
				if (!"IPQDR".Contains(command.ToString())) continue; // invalid command
				if (command == 'P')
				{
					WriteLine(sortedSet);
					continue;
				}
				string argString;
				try
				{
					argString = s.Substring(2);
				}
				catch (ArgumentOutOfRangeException)
				{
					continue; // invalid argument
				}
				if (!int.TryParse(argString, out int arg))
					continue; // invalid argument
				switch (command)
				{
					case 'I':
						if (sortedSet.Insert(arg))
							WriteLine("Element inserted");
						else
							WriteLine("Element was already in the tree");
						break;
					case 'D':
						if (sortedSet.Delete(arg))
							WriteLine("Element deleted");
						else
							WriteLine("Element was not in the tree");
						break;
					case 'Q':
						if (sortedSet.Contains(arg))
							WriteLine("Present");
						else
							WriteLine("Absent");
						break;
				}
			}
		}
	}
}
