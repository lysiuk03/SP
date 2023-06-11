
AnaliseFile analise=new AnaliseFile();
analise.Start();

class AnaliseFile
{
    Statistic stat = new Statistic();
    string[] files;
    public AnaliseFile()
    {
        files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"/folder");
    }
    public void Start()
    {
        foreach (var file in files)
        {
            string text = File.ReadAllText(file);
            Thread thread = new Thread(Analyze);
            thread.Start((object)text);
            thread.Join();
        }
        Console.WriteLine("Letter count: " + stat.LetterCount);
        Console.WriteLine("Digit count: " + stat.DigitCount);
        Console.WriteLine("Space count: " + stat.SpaceCount);
    }
    void Analyze(object text)
    {
        string txt = (string)text;
        Statistic localStat = new Statistic();
        foreach (char c in txt)
        {
            lock (this)
            {
                if (char.IsLetter(c))
                    stat.LetterCount++;
                else if (char.IsDigit(c))
                    stat.DigitCount++;
                else if (char.IsWhiteSpace(c))
                    stat.SpaceCount++;
            }
        }
    }
}
class Statistic
{
    public int LetterCount { get; set; }
    public int DigitCount { get; set; }
    public int SpaceCount { get; set; }
}
