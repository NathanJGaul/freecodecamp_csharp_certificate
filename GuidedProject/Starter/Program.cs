using System;

int examCount = 5;
string[] names = new string[] { "Sophia", "Andrew", "Emma", "Logan" };
int[][] studentScores = new int[][] {
    [ 90, 86, 87, 98, 100, 94, 90 ],
    [ 92, 89, 81, 96, 90, 89 ],
    [ 90, 85, 87, 98, 68, 89, 89, 89 ],
    [ 90, 95, 87, 88, 96, 96 ]
};

Console.WriteLine("Student\t\tExam Score\tOverall\tGrade\tExtra Credit\n");

for (int i = 0; i < names.Length; i++)
{
    int examSum = studentScores[i][..examCount].Sum();
    int extraCreditSum = studentScores[i][examCount..].Sum();
    int extraCreditCount = studentScores[i].Length - examCount;

    decimal examAvg = (decimal)examSum / examCount;
    decimal extraCreditAvg = (decimal)extraCreditSum / extraCreditCount;
    decimal extraCreditPts = (extraCreditSum * 0.1m) / examCount;
    decimal finalScore = (examSum + (extraCreditSum * 0.1m)) / examCount;

    Console.WriteLine($"{names[i]}:\t\t{examAvg}\t\t{finalScore}\t{GetGrade(finalScore)}\t{extraCreditAvg} ({extraCreditPts} pts)");
}

/*
 * This function determines the grade resulting from
 * a given score
 */
string GetGrade(decimal score) => score switch
{
    >= 97 => "A+", >= 93 => "A", >= 90 => "A-",
    >= 87 => "B+", >= 83 => "B", >= 80 => "B-",
    >= 77 => "C+", >= 73 => "C", >= 70 => "C-",
    >= 67 => "D+", >= 63 => "D", >= 60 => "D-",
    _ => "F"
};