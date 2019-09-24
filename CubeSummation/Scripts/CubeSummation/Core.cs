using System;
using System.Collections.Generic;
using CubeSummation.Utils;

namespace CubeSummation
{
    /// <summary>
    /// Provides the cube summation problem logic
    /// </summary>
    public class Core
    {
        #region Properties

        private CustomInput customInput;

        #endregion

        #region Class functions

        public void MainLoop(CustomInput customInput = null)
        {
            this.customInput = customInput;

            if (customInput != null)
                ConsoleExtentions.SetTestData(customInput.data);

            // Reads 'T' from user input...
            int t = Convert.ToInt32(GetInput()).Clamp(Constraints.MIN_T, Constraints.MAX_T);

            ConsoleExtentions.TryWriteLine(string.Format("T: {0}", t));

            // Creates a TestCase collection...
            List<TestCase> testCases = new List<TestCase>();

            // Iterates for the number of test cases...
            for (int i = 0; i < t; i++)
            {
                // Creates a new TestCase...
                TestCase currentTestCase = new TestCase();

                var cachedInputData = GetInput().Split(' ');

                // Reads 'N' & 'M' from user input...
                int n = Convert.ToInt32(cachedInputData[0]).Clamp(Constraints.MIN_N, Constraints.MAX_N);
                int m = Convert.ToInt32(cachedInputData[1]).Clamp(Constraints.MIN_M, Constraints.MAX_M);

                ConsoleExtentions.TryWriteLine(string.Format("N: {0}", n));
                ConsoleExtentions.TryWriteLine(string.Format("M: {0}", m));

                // Creates a new Cube & a new Result collection for the current test case...
                currentTestCase.cube = new Cube(n);
                currentTestCase.results = new List<Result>();

                // Iterates for the number of operations...
                for (int j = 0; j < m; j++)
                {
                    cachedInputData = GetInput().Split(' ');

                    switch (cachedInputData[0])
                    {
                        case "UPDATE":
                            PerformUpdateCase(
                                // Cube...
                                currentTestCase.cube,
                                // 'x', 'y' & 'z' arguments...
                                cachedInputData[1], cachedInputData[2], cachedInputData[3],
                                // 'W' argument...
                                cachedInputData[4]);
                            break;

                        case "QUERY":
                            PerformQueryCase(
                                // Cube...
                                currentTestCase.cube,
                                // 'x1', 'y1' & 'z1' arguments...
                                cachedInputData[1], cachedInputData[2], cachedInputData[3],
                                // 'x2', 'y2' & 'z2' arguments...
                                cachedInputData[4], cachedInputData[5], cachedInputData[6],
                                // Output...
                                ref currentTestCase.results);
                            break;

                        default:
                            return;
                    }
                }

                // Adds the current test case to the TestCase collection...
                testCases.Add(currentTestCase);
            }

            // Prints on console each result value...
            foreach (var testCase in testCases)
            {
                foreach (var result in testCase.results)
                {
                    Console.WriteLine(result.value.ToString());
                }
            }

            Console.ReadLine();
        }

        private void PerformUpdateCase(Cube cube, string xArg, string yArg, string zArg, string wArg)
        {
            ConsoleExtentions.TryWriteLine(string.Format("UPDATE {0} {1} {2} {3}", xArg, yArg, zArg, wArg));

            try
            {
                if (cube != null)
                    cube.Update(
                        // x...                                     y...                                        z...
                        Convert.ToInt32(xArg).Clamp(1, cube.n) - 1, Convert.ToInt32(yArg).Clamp(1, cube.n) - 1, Convert.ToInt32(zArg).Clamp(1, cube.n) - 1,
                        // W...
                        Convert.ToInt32(wArg).Clamp(Constraints.MIN_W, Constraints.MAX_W));
            }
            catch (Exception)
            {
                // Err...
                Console.WriteLine("An error has ocurred in UPDATE");
            }
        }

        private void PerformQueryCase(Cube cube, string x1Arg, string y1Arg, string z1Arg, string x2Arg, string y2Arg, string z2Arg, ref List<Result> results)
        {
            ConsoleExtentions.TryWriteLine(string.Format("QUERY {0} {1} {2} {3} {4} {5}", x1Arg, y1Arg, z1Arg, x2Arg, y2Arg, z2Arg));

            try
            {
                if (cube != null)
                {
                    var currentResult = cube.Query(
                        // x1...                                        y1...                                           z1...
                        Convert.ToInt32(x1Arg).Clamp(1, cube.n) - 1, Convert.ToInt32(y1Arg).Clamp(1, cube.n) - 1, Convert.ToInt32(z1Arg).Clamp(1, cube.n) - 1,
                        // x2...                                        y2...                                           z2...
                        Convert.ToInt32(x2Arg).Clamp(1, cube.n) - 1, Convert.ToInt32(y2Arg).Clamp(1, cube.n) - 1, Convert.ToInt32(z2Arg).Clamp(1, cube.n) - 1);

                    // Adds the current result to the Result collection...
                    results.Add(new Result(currentResult));
                }
            }
            catch (Exception)
            {
                // Err...
                Console.WriteLine("An error has ocurred in QUERY");
            }
        }

        private string GetInput()
        {
            if (customInput != null)
                return string.IsNullOrEmpty(customInput.data) ? Console.ReadLine() : ConsoleExtentions.ReadData();
            else
                return Console.ReadLine();
        }

        #endregion
    }
}
