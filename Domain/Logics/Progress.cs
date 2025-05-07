namespace Domain.Logics;

public static class Progress
{
    public static int CalculateValue(int? current, int? total)
    {
        if (current == null || total == null || total == 0)
        {
            return 0;
        }
        double percent = (double)current.Value / total.Value * 100;
        return (int)Math.Round(percent);
    }
}
