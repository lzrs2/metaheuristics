using System;

namespace Metaheuristics
{
	public class SSBL42SP : IMetaheuristic, ITunableMetaheuristic
	{
		protected int timePenalty = 250;
		public int poolSize = 200;
		public int refSetSize = 10;
		public double explorationFactor = 0.75;
		
		public void Start(string inputFile, string outputFile, int timeLimit)
		{
			TwoSPInstance instance = new TwoSPInstance(inputFile);
			DiscreteSS ss = new DiscreteSSBL42SP(instance, poolSize, refSetSize, explorationFactor);
			ss.Run(timeLimit - timePenalty);
			int[,] coordinates = TwoSPUtils.BLCoordinates(instance, ss.BestSolution);
			TwoSPSolution solution = new TwoSPSolution(instance, coordinates);
			solution.Write(outputFile);
		}

		public string Name {
			get {
				return "SS using the BL heuristic for 2SP";
			}
		}
		
		public MetaheuristicType Type {
			get {
				return MetaheuristicType.SS;
			}
		}
		
		public ProblemType Problem {
			get {
				return ProblemType.TwoSP;
			}
		}
		
		public string[] Team {
			get {
				return About.Team;
			}
		}
		
		public void UpdateParameters(double[] parameters)
		{
			timePenalty = (int) parameters[0];
			poolSize = (int) parameters[1];
			refSetSize = (int) parameters[2];
			explorationFactor = parameters[3];
		}
	}
}
