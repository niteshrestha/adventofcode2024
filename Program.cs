namespace adventofcode;

class Program
{
    static void Main(string[] args)
    {
        if(args.Length > 0){
            if(args[0] == "1"){
                Day1.Execute();
            }
        }
    }
}
