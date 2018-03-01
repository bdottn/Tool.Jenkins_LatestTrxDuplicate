using System;
using System.IO;
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

                DuplicateTrx(argument);
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

        private static void DuplicateTrx(TrxDuplicateArgument argument)
        {
            var testResultsDirectory = Path.Combine(argument.Workspace, argument.TestResultsFolder);

            var targetFilePath = Path.Combine(testResultsDirectory, argument.OutputFileName);

            if (Directory.Exists(testResultsDirectory) == false)
            {
                throw new DirectoryNotFoundException(string.Format("資料夾錯誤：資料夾【{0}】不存在！", testResultsDirectory));
            }
            else
            {
                var sourceTrxFile = Directory.GetFiles(testResultsDirectory, "*.trx", SearchOption.TopDirectoryOnly).OrderByDescending(f => File.GetLastWriteTime(f)).FirstOrDefault();

                if (File.Exists(sourceTrxFile))
                {
                    File.Copy(sourceTrxFile, targetFilePath, true);

                    Console.WriteLine(string.Format("複製檔案：【{0}】→【{1}】。", sourceTrxFile, targetFilePath));
                }
                else
                {
                    throw new FileNotFoundException(string.Format("檔案錯誤：檔案【{0}】不存在！", sourceTrxFile));
                }
            }
        }
    }
}