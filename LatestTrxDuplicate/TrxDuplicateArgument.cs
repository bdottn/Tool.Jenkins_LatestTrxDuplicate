namespace LatestTrxDuplicate
{
    sealed class TrxDuplicateArgument
    {
        public string Workspace { get; set; }

        public string TestResultsFolder { get; set; }

        public string OutputFileName { get; set; }
    }
}