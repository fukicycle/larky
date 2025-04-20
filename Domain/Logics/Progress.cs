namespace Domain.Logics;

public static class Progress
{
    public static double CalculateValue(int? current, int? total)
    {
        if (current == null || total == null)
        {
            return 0;
        }
        var currentDouble = Convert.ToDouble(current);
        var totalDouble = Convert.ToDouble(total);
        return Math.Round(currentDouble / totalDouble * 100.0);
    }
}
