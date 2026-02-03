string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };
int periodLocation = 0;

foreach (var myString in myStrings)
{
    var currentString = myString;
    periodLocation = currentString.IndexOf('.');
    
    while (periodLocation != -1)
    {
        Console.WriteLine(currentString.Substring(0, periodLocation).TrimStart());
        currentString = currentString.Remove(0, periodLocation + 1);
        periodLocation = currentString.IndexOf('.');
    }
    Console.WriteLine(currentString.Trim());
}