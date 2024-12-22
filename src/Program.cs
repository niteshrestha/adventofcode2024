using adventofcode.Puzzle;

namespace adventofcode;

class Program
{
    static void Main(string[] args)
    {
        if(args.Length > 0)
        {
            if(args[0] == "1"){
                Day1 day1 = new();
                day1.GetTotalDistance();
                day1.GetSimilarityScore();
            }
            if(args[0] == "2"){
                Day2.GetSafeReports();
            }
        }
    }
}
