namespace Domain.Logics;

public static class Nickname
{
    private static string firstNameList = "apple,bridge,sunshine,whisper,mountain,river,pencil,lightning,butterfly,guitar,window,flower,ocean,clock,book,camera,banana,mirror,elephant,chair,cloud,computer,forest,dream,snow,star,fire,balloon,shadow,song,tree,cup,hat,moon,candle,bird,train,stone,glass,car,pillow,key,paper,door,skate,umbrella,puzzle,street,rain,frog,plane";
    private static string lastNameList = "sand,waterfall,rope,desert,jacket,horse,bicycle,cookie,ring,suitcase,bridge,vase,ice,laptop,pearl,notebook,volcano,fountain,chocolate,diamond,shelf,garden,island,ship,feather,towel,piano,stadium,socks,spoon,ladder,pocket,road,shell,tower,fan,doorbell,bottle,sword,brush,tent,flame,anchor,compass,lantern,coin,motorcycle,crown,paint,radio,bench,skull";
    private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public static string Get()
    {
        string[] firsts = firstNameList.Split(",");
        string[] lasts = lastNameList.Split(",");
        string first = firsts[Random.Shared.Next(0, firsts.Length - 1)];
        string last = lasts[Random.Shared.Next(0, lasts.Length - 1)];
        string[] intValue = numbers.OrderBy(a => Guid.NewGuid()).Take(3).Select(a => a.ToString()).ToArray();
        string upperFirst = GetFormatName(first);
        string upperLast = GetFormatName(last);
        string nickname = $"{upperFirst}{upperLast}{string.Join("", intValue)}";
        return nickname;
    }

    private static string GetFormatName(string name)
    {
        var firstChar = name[0].ToString().ToUpper();
        var remain = name[1..];
        return $"{firstChar}{remain}";
    }
}
