using static System.Net.Mime.MediaTypeNames;
Console.WriteLine("HOW TEXTFILTERING WORKS\n");
Console.WriteLine("The program will ask for 2 textfiles:");
Console.WriteLine("1: The text file you want filtering for");
Console.WriteLine("2: A clean, fresh textfile where your new data will be\n");
Console.WriteLine("After the textfiles, you write what will get filtered in your textfile");
Console.WriteLine("Do you understand? y/n");
string yesno = Console.ReadLine();
Console.Clear();
yesno = yesno.ToUpper();
if (yesno != "Y")
{
	if (yesno == "N")
	{
        Environment.Exit(0);
    }
    Console.WriteLine("Wrong input. Try again!");
    Environment.Exit(5000);
}
Console.WriteLine("Give me the full directory of the file you WANT to get FILTERED:");
string filterFile = Console.ReadLine();
Console.Clear();
Console.WriteLine("Give me the full directory of the EMTPY FILE:");
string emptyFile = Console.ReadLine();
Console.WriteLine("Write the EXACT Characters of the word/line you want to get filtered:");
string filter = Console.ReadLine();

filterFile = filterFile.Substring(1, filterFile.Length - 2);
emptyFile = emptyFile.Substring(1, emptyFile.Length - 2);
try
{
    var text = File.ReadLines($@"{filterFile}");
    string tempFile = Path.GetTempFileName();
    StreamWriter sw = new StreamWriter(tempFile);
    foreach (var line in text)
    {
        if (line.Contains(filter))
        {
            sw.WriteLine(line);
        }
    }
    sw.Close();
    File.Delete(emptyFile);
    File.Move(tempFile, emptyFile);
}
catch (Exception)
{
    Console.WriteLine("The directory of the files are incorrect! Try again!");
    Environment.Exit(0);
}


