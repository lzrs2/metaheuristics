using System;
using Metaheuristics;

namespace Test
{
	public class MainClass
	{
		public static void Main(string[] args)
		{
			string fileInput = "../../../Problems/2SP/Instances/inst1.in";
			string fileOutput = "../../../Problems/2SP/Instances/inst1.out";
			UMDA2OptBest42SP.Start(fileInput, fileOutput, 25000);
		}
	}
}
