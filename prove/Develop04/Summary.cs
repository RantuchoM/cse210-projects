public class Summary
/* I created this class to keep a track of the activities done during this session.
It holds a list of Activity elements, it has its own constructor, and an "AddActivity" method that pushes elements into the list.
Then a method to display the summary by looping through its elements.
*/
{
    List <Activity> _activities; 

    public Summary()
    {
        _activities = new();
    }

    public void AddActivity(Activity activity)
    {
        _activities.Add(activity);
    }

    public void DisplayActivities()
    {
        int index = 0;
        int count = _activities.Count();
        int totalDuration = 0;
        Console.WriteLine("\nThis is the Summary of this session: \n");
        foreach(Activity activity in _activities)
        {
            index++;
            totalDuration += activity.GetDuration();
            Console.WriteLine($"    {index}. {activity.GetName()} - {activity.GetDuration()} seconds.");
        }
        Console.WriteLine($"\nYou did a total number of {count} activities with a total duration of {totalDuration} seconds.\nCongratulations!");
        Console.WriteLine("\nPress Enter to continue.");
        Console.ReadLine();
    }
}