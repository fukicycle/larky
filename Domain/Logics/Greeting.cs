namespace Domain.Logics;

public static class Greeting
{
    public static string GetGreeting(TimeSpan? time = null)
    {
        var currentTime = time ?? DateTime.Now.TimeOfDay;
        if (currentTime >= TimeSpan.FromHours(5) && currentTime < TimeSpan.FromHours(10)) // 5:00 ~ 9:59
        {
            return "おはよう";
        }
        if (currentTime >= TimeSpan.FromHours(10) && currentTime < TimeSpan.FromHours(18)) // 10:00 ~ 17:59
        {
            return "こんにちは";
        }
        return "こんばんは"; // 深夜〜早朝を含む
    }
}
