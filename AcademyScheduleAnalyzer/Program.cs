using System.ComponentModel.Design;
using System.Text;
//***************** part 1  ***********************
string[] sessionNames =
{
    "C# Basics",
    "Arrays",
    "Functions",
    "Date and Time",
    "Exception Handling"
};

DateTime[] sessionDates =
{
    new DateTime(2026, 9, 10, 18, 0, 0),
    new DateTime(2026, 9, 13, 18, 0, 0),
    new DateTime(2026, 9, 17, 18, 0, 0),
    new DateTime(2026, 9, 20, 18, 0, 0),
    new DateTime(2026, 9, 24, 18, 0, 0)
};

int[] sessionDurations =
{
    180,
    240,
    180,
    240,
    180
};
//***************** part 2  ***********************
void DisplaySessions(string[] names, DateTime[] dates, int[] durations)
{
    for (int i = 0; i < names.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {names[i]}");
        Console.WriteLine($"Date: {dates[i]:yyyy-MM-dd}");
        Console.WriteLine($"Start Time: {dates[i]:hh:mm:ss tt}");
        Console.WriteLine($"Duration: {durations[i]} minutes");
        Console.WriteLine("-------------------------");
    }
}
DisplaySessions(sessionNames, sessionDates, sessionDurations);
//***************** part 3  ***********************

void SearchSession(string[] names, DateTime[] dates, int[] durations)
{
    Console.Write("Enter session name: ");
    string searchName = Console.ReadLine();

    int index = Array.IndexOf(names, searchName);

    if (index != -1)
    {
        Console.WriteLine($"Session: {names[index]}");
        Console.WriteLine($"Date: {dates[index]:yyyy-MM-dd}");
        Console.WriteLine($"Start Time: {dates[index]:hh:mm tt}");
        Console.WriteLine($"Duration: {durations[index]} minutes");
    }
    else
    {
        Console.WriteLine("Session not found.");
    }
}
SearchSession(sessionNames, sessionDates, sessionDurations);
//***************** part 4  ********************************
string[] sortedNames = new string[sessionNames.Length];

Array.Copy(sessionNames, sortedNames, sessionNames.Length);

Array.Sort(sortedNames);

Console.WriteLine("\nSorted Session Names:");

foreach (string name in sortedNames)
{
    Console.WriteLine(name);
}

string[] reversedNames = new string[sessionNames.Length];

Array.Copy(sessionNames, reversedNames, sessionNames.Length);

Array.Reverse(reversedNames);

Console.WriteLine("\nReversed Session Names:");

foreach (string name in reversedNames)
{
    Console.WriteLine(name);
}

Console.Write("\nEnter session name: ");
string searchName = Console.ReadLine();

int index = Array.IndexOf(sessionNames, searchName);

Console.WriteLine($"Index: {index}");
//***************** part 5  ***********************
int GetTotalDuration(int[] durations)
{
    int total = 0;

    for (int i = 0; i < durations.Length; i++)
    {
        total += durations[i];
    }

    return total;
}

double GetAverageDuration(int[] durations)
{
    return (double)GetTotalDuration(durations) / durations.Length;
}

int GetShortestDuration(int[] durations)
{
    int shortest = durations[0];

    for (int i = 1; i < durations.Length; i++)
    {
        if (durations[i] < shortest)
        {
            shortest = durations[i];
        }
    }

    return shortest;
}

int GetLongestDuration(int[] durations)
{
    int longest = durations[0];

    for (int i = 1; i < durations.Length; i++)
    {
        if (durations[i] > longest)
        {
            longest = durations[i];
        }
    }

    return longest;
}

Console.WriteLine($"Total Duration: {GetTotalDuration(sessionDurations)} minutes");
Console.WriteLine($"Average Duration: {GetAverageDuration(sessionDurations)} minutes");
Console.WriteLine($"Shortest Duration: {GetShortestDuration(sessionDurations)} minutes");
Console.WriteLine($"Longest Duration: {GetLongestDuration(sessionDurations)} minutes");

int[] sortedDurations = new int[sessionDurations.Length];

Array.Copy(sessionDurations, sortedDurations, sessionDurations.Length);

Array.Sort(sortedDurations);

Console.WriteLine("Sorted Durations:");


foreach (int d in sortedDurations)
{
    Console.WriteLine(d);
}
//******************** part 6 ****************************
void DisplaySessionDetails(string name, DateTime date, int duration)
{
    Console.WriteLine($"Session: {name}");
    Console.WriteLine($"Date: {date:yyyy-MM-dd}");
    Console.WriteLine($"Start Time: {date:hh:mm tt}");
    Console.WriteLine($"Duration: {duration} minutes");
}

DateTime GetSessionEndTime(DateTime startTime, int duration)
{
    return startTime.AddMinutes(duration);
}
DateTime ReadSessionDate()
{
    Console.Write("Enter date (yyyy-MM-dd HH:mm): ");
    return DateTime.Parse(Console.ReadLine());
}
string BuildReportUsingString(string[] names, DateTime[] dates, int[] durations)
{
    string report = "";

    for (int i = 0; i < names.Length; i++)
    {
        report += $"{names[i]} - {dates[i]:yyyy-MM-dd} - {durations[i]} minutes\n";
    }

    return report;
}
string BuildReportUsingStringBuilder(string[] names, DateTime[] dates, int[] durations)
{
    StringBuilder report = new StringBuilder();

    for (int i = 0; i < names.Length; i++)
    {
        report.AppendLine($"{names[i]} - {dates[i]:yyyy-MM-dd} - {durations[i]} minutes");
    }

    return report.ToString();
}
//******************** part 7 ****************************
// 7.1 - ref
static void ChangeValue(ref int number)
{
    number = 100;
}
int number = 10;
Console.WriteLine("7.1 - ref");
Console.WriteLine($"Before: {number}");
Console.WriteLine($"After: {number}");
ChangeValue(ref number);
// 7.2 - out
static bool FindSession(
    string sessionName,
    string[] sessionNames,
    int[] sessionDurations,
    out int index,
    out int duration)
{
    for (int i = 0; i < sessionNames.Length; i++)
    {
        if (sessionNames[i].Equals(sessionName, StringComparison.OrdinalIgnoreCase))
        {
            index = i;
            duration = sessionDurations[i];
            return true;
        }
    }

    index = -1;
    duration = 0;
    return false;
}
Console.WriteLine("\n7.2 - out");
Console.Write("Enter session: ");
string input = Console.ReadLine()!;

if (FindSession(
        input,
        sessionNames,
        sessionDurations,
        out  index,
        out int duration))
{
    Console.WriteLine($"Index: {index}");
    Console.WriteLine($"Duration: {duration} minutes");
}
else
{
    Console.WriteLine("Session not found.");
}
// 7.3 - Reference Type Without ref
static void ChangeFirstSession(string[] sessionNames)
{
    sessionNames[0] = "Updated C# Basics";
}

Console.WriteLine("\n7.3 - Reference Type Without ref");

Console.WriteLine($"Before: {sessionNames[0]}");

ChangeFirstSession(sessionNames);

Console.WriteLine($"After: {sessionNames[0]}");
//*************************** Part 8 *****************************
static int CalculateTotalDuration(params int[] durations)
{
    int total = 0;

    foreach (int duration in durations)
    {
        total += duration;
    }

    return total;
}
// Example calls
int total1 = CalculateTotalDuration(120, 180);
Console.WriteLine($"Total Duration: {total1} minutes");

int total2 = CalculateTotalDuration(120, 180, 240);
Console.WriteLine($"Total Duration: {total2} minutes");

int total3 = CalculateTotalDuration(60, 90, 120, 180, 240);
Console.WriteLine($"Total Duration: {total3} minutes");
//************************ Part 9 *********************************
static void DisplaysessionDetails(
    string[] sessionNames,
    DateTime[] sessionDates,
    int[] sessionDurations,
    int index)
{
    DateTime date = sessionDates[index];
    int duration = sessionDurations[index];
    DateTime endTime = date.AddMinutes(duration);

    Console.WriteLine();
    Console.WriteLine($"Session: {sessionNames[index]}");
    Console.WriteLine($"Date: {date:dd MMMM yyyy}");
    Console.WriteLine($"Day: {date.DayOfWeek}");
    Console.WriteLine($"Year: {date.Year}");
    Console.WriteLine($"Month: {date.Month}");
    Console.WriteLine($"Day Number: {date.Day}");
    Console.WriteLine($"Start Time: {date:hh:mm tt}");
    Console.WriteLine($"Duration: {duration} minutes");
    Console.WriteLine($"End Time: {endTime:hh:mm tt}");
}
Console.Write("Enter session: ");
 input = Console.ReadLine()!;

  index= -1;

for (int i = 0; i < sessionNames.Length; i++)
{
    if (sessionNames[i].Equals(input, StringComparison.OrdinalIgnoreCase))
    {
        index = i;
        break;
    }
}

if (index != -1)
{
    DisplaysessionDetails(
        sessionNames,
        sessionDates,
        sessionDurations,
        index);
}
else
{
    Console.WriteLine("Session not found.");
}
//************************ Part 10 *********************************
static int FindSessionIndex(string sessionName, string[] sessionNames)
{
    for (int i = 0; i < sessionNames.Length; i++)
    {
        if (sessionNames[i].Equals(
                sessionName,
                StringComparison.OrdinalIgnoreCase))
        {
            return i;
        }
    }

    return -1;
}

Console.Write("First Session: ");
string firstSession = Console.ReadLine()!;
Console.Write("Second Session: ");
string secondSession = Console.ReadLine()!;
int firstIndex = FindSessionIndex(firstSession, sessionNames);
int secondIndex = FindSessionIndex(secondSession, sessionNames);
if (firstIndex == -1 || secondIndex == -1)
{
    Console.WriteLine("One or both sessions were not found.");
}
else
{
   
    DateTime firstDate = sessionDates[firstIndex];
    DateTime secondDate = sessionDates[secondIndex];
    TimeSpan difference = secondDate - firstDate;

    Console.WriteLine("Difference:");
    Console.WriteLine($"{difference.TotalDays} days");
    Console.WriteLine($"{difference.TotalHours} hours");
}
//************************ Part 11 *********************************
for (int i = 0; i < sessionNames.Length; i++)
{
    if (sessionDates[i] < DateTime.Now)
    {
        Console.WriteLine($"{sessionNames[i]} - Past");
    }
    else
    {
        Console.WriteLine($"{sessionNames[i]} - Upcoming");
    }
}
//************************ Part 12 *********************************
DateTime now = DateTime.Now;

DateTime nearestDate = DateTime.MaxValue;
int nearestIndex = -1;
for (int i = 0; i < sessionDates.Length; i++)
{
    if (sessionDates[i] > now)
    {
        if (sessionDates[i] < nearestDate)
        {
            nearestDate = sessionDates[i];
            nearestIndex = i;
        }
    }
}

if (nearestIndex != -1)
{
    TimeSpan remainingTime = nearestDate - now;

    Console.WriteLine("Next Session:");
    Console.WriteLine(sessionNames[nearestIndex]);
    Console.WriteLine($"Date: {nearestDate:dd MMMM yyyy}");
    Console.WriteLine($"Start Time: {nearestDate:hh:mm tt}");

    Console.WriteLine("Time Remaining:");
    Console.WriteLine($"{(int)remainingTime.TotalDays} days");
    Console.WriteLine($"{remainingTime.Hours} hours");
}
else
{
    Console.WriteLine("There are no upcoming sessions.");
}
//************************ Part 13 *********************************
Console.Write("Enter session: ");
 input = Console.ReadLine()!;

 index = FindSessionIndex(input, sessionNames);

if (index != -1)
{
    DateTime date = sessionDates[index];

    Console.WriteLine();
    Console.WriteLine($"Session: {sessionNames[index]}");

    Console.WriteLine(date.ToString("yyyy-MM-dd"));

    Console.WriteLine(date.ToString("dd/MM/yyyy"));

    Console.WriteLine(date.ToString("dd MMMM yyyy"));

    Console.WriteLine(date.ToString("dddd, dd MMMM yyyy"));

    Console.WriteLine(date.ToString("hh:mm tt"));
}
else
{
    Console.WriteLine("Session not found.");
}
//************************* Part 14 *********************************
static DateTime ReadValidDate()
{
    while (true)
    {
        Console.Write("Enter date (yyyy-MM-dd HH:mm): ");
        string input = Console.ReadLine()!;

        if (DateTime.TryParseExact(
                input,
                "yyyy-MM-dd HH:mm",
                null,
                System.Globalization.DateTimeStyles.None,
                out DateTime date))
        {
            return date;
        }

        Console.WriteLine("Invalid date. Please try again.");
    }
}

DateTime validDate = ReadValidDate();

Console.WriteLine($"Valid Date: {validDate}");
//************************* Part 15 ********************************
