using System;
using System.Linq;

namespace LatestTrxDuplicate
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null && args.Length == 0)
            {
                throw new ArgumentNullException("參數錯誤：未傳入參數！");
            }
            else
            {
                var argument = GenerateTrxDuplicateArgument(args);
            }
        }

        private static TrxDuplicateArgument GenerateTrxDuplicateArgument(string[] args)
        {
            var argument = new TrxDuplicateArgument();

            foreach (var arg in args.Select(a => a.Split('=')))
            {
                switch (arg[0].ToLower())
                {
                    // Workspace Path
                    case "-workspace":

                        argument.Workspace = arg[1];

                        break;

                    // TestResultsFolder
                    case "-testresultsfolder":

                        argument.TestResultsFolder = arg[1];

                        break;

                    // Output FileName
                    case "-outputfilename":

                        argument.OutputFileName = arg[1];

                        break;
                }
            }

            return argument;
        }
    }
}