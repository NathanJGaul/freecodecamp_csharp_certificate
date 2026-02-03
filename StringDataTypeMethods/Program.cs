const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

string quantity = "";
string output = "";

string open = "<span>";
string close = "</span>";

int openPosition = input.IndexOf(open);
openPosition += open.Length;

int closePosition = input.IndexOf(close, openPosition);
int length = closePosition - openPosition;
quantity = input.Substring(openPosition, length);

open = "<div>";
close = "</div>";

openPosition = input.IndexOf(open);
openPosition += open.Length;

closePosition = input.IndexOf(close, openPosition);
length = closePosition - openPosition;
output = input.Substring(openPosition, length);

output = output.Replace("trade", "reg");

Console.WriteLine(quantity);
Console.WriteLine(output);