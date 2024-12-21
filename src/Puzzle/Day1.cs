namespace adventofcode.Puzzle;

public class Day1
{
    private readonly List<int> leftList = [];
    private readonly List<int> rightList = [];

    public Day1()
    {
        // read from csv input and store in two lists
        string csvPath = "Puzzle/input/day1input.csv";

        using StreamReader reader = new(csvPath);
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] values = line.Split(',');

            // since we know the format of the csv file and know there will
            // only be 2 values in the string array we will assign it.
            leftList.Add(int.Parse(values[0]));
            rightList.Add(int.Parse(values[1]));
        }
    }

    // Part 1
    public void GetTotalDistance()
    {
        int totalDistance = 0;

        // just sort the number to later substract to get the distance on each node
        leftList.Sort();
        rightList.Sort();

        int length = leftList.Count;

        // just making sure that I don't hit index out of bound
        if(leftList.Count != rightList.Count)
        {
            throw new InvalidOperationException("Length doesn't match");
        }

        // lets loop through each node in both list to get the distance
        // between them and add to get the total distance
        for(int i = 0; i < length; i++){
            totalDistance += Math.Abs(leftList[i] - rightList[i]);
        }

        Console.WriteLine($"Total Distance: {totalDistance}");
    }

    // Part 2
    public void GetSimilarityScore()
    {
        int similarityScore = 0;

        // find the occurence of numbers if the right list
        var rightListOccurence = rightList.GroupBy(x=>x)
            .Select(n => new { Element = n.Key, Count = n.Count()});

        foreach(var leftListItem in leftList)
        {
            var occurence = rightListOccurence
                .Where(x => x.Element == leftListItem)
                .Select(x=>x.Count)
                .FirstOrDefault();

            similarityScore += leftListItem * occurence;
        }

        Console.WriteLine($"Similarity Score: {similarityScore}");
    }
}
