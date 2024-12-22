namespace adventofcode.Puzzle
{
    public static class Day2
    {
        private const int LowerBound = 1;
        private const int UpperBound = 3;
        
        public static void GetSafeReports()
        {
            var safeReport = 0;
            try
            {
                // read from csv input and store in two lists
                var csvPath = "Puzzle/input/day2input.csv";

                // parse the input 
                using StreamReader reader = new(csvPath);
                string? report;
                while ((report = reader.ReadLine()) != null)
                {
                    safeReport += IsReportSafe(report) ? 1 : 0;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine($"Safe Reports: {safeReport}");
            }
        }

        private static bool IsReportSafe(string report)
        {
            var levels = report.Split(',')
                .Select(int.Parse)
                .ToList();
            var reportLevels = levels.Count - 1;

            // find the distance between 2 adjacent levels in the report
            List<int> distance = [];
            for(var i = 0; i < reportLevels; i++)
            {
                distance.Add(levels[i] - levels[i+1]);
            }

            // all levels have to be either all increasing or decreasing
            var isReportSafe = 
                distance.All(x=> x>0) || 
                distance.All(x=> x<0);
            if(!isReportSafe){
                return isReportSafe;
            }

            // two adjacent levels must differ by at least 1 
            // and at most 3
            isReportSafe = 
                distance.All(x=> Math.Abs(x) >= LowerBound) && 
                distance.All(x=> Math.Abs(x) <= UpperBound);
            return isReportSafe;
        }
    }
}
