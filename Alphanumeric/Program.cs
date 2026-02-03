string customerName = "Ms. Barros";

string currentProduct = "Magic Yield";
int currentShares = 2975000;
decimal currentReturn = 0.1275m;
decimal currentProfit = 55000000.0m;

string newProduct = "Glorious Future";
decimal newReturn = 0.13125m;
decimal newProfit = 63000000.0m;

Console.WriteLine($@"{customerName},
As a customer of our {currentProduct} offering we are excited to tell you about a new financial product that would dramatically increase your return.

Currently, you own {currentShares:N} shares at a return of {currentReturn:P}.

Our new product, {newProduct} offers a return of {newReturn:P}.  Given your current volume, your potential profit would be {newProfit:C}.
");

Console.WriteLine("Here's a quick comparison:\n");

string comparisonMessage = "";

comparisonMessage += currentProduct.PadRight(18);
comparisonMessage += $"{currentReturn:P2}".PadRight(12);
comparisonMessage += $"{currentProfit:C}";

comparisonMessage += '\n';
comparisonMessage += newProduct.PadRight(18);
comparisonMessage += $"{newReturn:P2}".PadRight(12);
comparisonMessage += $"{newProfit:C}";

// Your logic here

Console.WriteLine(comparisonMessage);