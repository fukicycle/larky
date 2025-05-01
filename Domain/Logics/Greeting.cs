namespace Domain.Logics;

public static class Greeting
{
    public static string GetCreeting()
    {
        var currentTime = DateTime.Now.TimeOfDay;
        if (currentTime >= TimeSpan.FromHours(2) && currentTime <= TimeSpan.FromHours(10))
        {
            return "おはよう";
        }

        if (currentTime > TimeSpan.FromHours(10) && currentTime <= TimeSpan.FromHours(18))
        {
            return "こんにちは";
        }
        return "こんばんは";
    }
}
