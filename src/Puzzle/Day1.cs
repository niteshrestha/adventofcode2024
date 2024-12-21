namespace adventofcode.Puzzle;

public static class Day1{
    public static void Execute(){

        // Input puzzle
        var firstList = new List<int>();
        var secondList = new List<int>();

        // read from csv input and store in two lists

        string csvPath = "Puzzle/input/day1input.csv";
        using(StreamReader reader = new StreamReader(csvPath))
        {
            string line;
            while((line = reader.ReadLine()) != null){
                string[] values = line.Split(',');

                // since we know the format of the csv file and know there will
                // only be 2 values in the string array we will assign it.
                firstList.Add(int.Parse(values[0])); 
                secondList.Add(int.Parse(values[1])); 
            }
        }

        int totalDistance = 0;

        // just sort the number to later substract to get the distance on each node
        firstList.Sort();
        secondList.Sort();

        int length = firstList.Count;

        // just making sure that I don't hit index out of bound
        if(firstList.Count != secondList.Count)
        {
            throw new InvalidOperationException("Length doesn't match");
        }

        // lets loop through each node in both list to get the distance
        // between them and add to get the total distance
        for(int i = 0; i < length; i++){
            totalDistance += Math.Abs(firstList[i] - secondList[i]);
        }
        
        Console.WriteLine($"Total Distance: {totalDistance}");
    }
}
