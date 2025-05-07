namespace Domain.Logics;

public static class Nickname
{
    private readonly static string[] FirstNames = "apple,bridge,sunshine,whisper,mountain,river,pencil,lightning,butterfly,guitar,window,flower,ocean,clock,book,camera,banana,mirror,elephant,chair,cloud,computer,forest,dream,snow,star,fire,balloon,shadow,song,tree,cup,hat,moon,candle,bird,train,stone,glass,car,pillow,key,paper,door,skate,umbrella,puzzle,street,rain,frog,plane".Split(",");
    private readonly static string[] LastNames = "sand,waterfall,rope,desert,jacket,horse,bicycle,cookie,ring,suitcase,bridge,vase,ice,laptop,pearl,notebook,volcano,fountain,chocolate,diamond,shelf,garden,island,ship,feather,towel,piano,stadium,socks,spoon,ladder,pocket,road,shell,tower,fan,doorbell,bottle,sword,brush,tent,flame,anchor,compass,lantern,coin,motorcycle,crown,paint,radio,bench,skull".Split(",");
    public static string Generate()
    {
        string first = Capitalize(FirstNames[Random.Shared.Next(FirstNames.Length)]);
        string last = Capitalize(LastNames[Random.Shared.Next(LastNames.Length)]);
        string digits = Random.Shared.Next(100, 1000).ToString();
        return $"{first}{last}{digits}";
    }

    private static string Capitalize(string name)
    {
        var firstChar = name[0].ToString().ToUpper();
        var remain = name[1..];
        return $"{firstChar}{remain}";
    }
}
