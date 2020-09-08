﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskTwoSecurePrivacy
{
	class Program
	{
		static void Main(string[] args)
		{
			var binarystring = Console.ReadLine();
			var retVal = processData(binarystring);
			Console.WriteLine("Input string is " + retVal + " binary");
			Console.ReadLine();
		}

		private static string processData(string binarystring)
		{
			var isGoodBinary = "bad";
			var isbinary = Regex.IsMatch(binarystring.Trim(), "^[01]+$");
			if(isbinary == false)
			{
				return "bad";
			}
			else
			{
				int zeroCount = 0, oneCount = 0; 
				foreach(char a in binarystring)
				{
					if(a == '0')
					{
						zeroCount++;
					}
					else if(a == '1')
					{
						oneCount++;
					}
				}
				if(zeroCount == oneCount)
				{
					
					//take substring prefixes now
					var prefixes = Enumerable.Range(1, binarystring.Length)
						 .Select(p => binarystring.Substring(0, p));
					int zeroPreCount = 0, onePreCount = 0;
					foreach (var pre in prefixes)
					{
						if(pre.Length == 1)
						{
							if(pre != "1")
							{
								isGoodBinary = "bad";
							}
						}
						foreach(char a in pre)
						{
							if (a == '0')
							{
								zeroPreCount++;
							}
							else if (a == '1')
							{
								onePreCount++;
							}
						}
						if(zeroPreCount > onePreCount)
						{
							isGoodBinary = "bad";
							break;
						}
						else
						{
							isGoodBinary = "good";
						}
					}
				}
			}
			return isGoodBinary;
		}

	}
}
