using System.Reflection;
using LR4.Music;

class Program
{
    static void Main(string[] args)
    {
        Music song1 = new Music(1, "Bohemian Rhapsody", true, 4.5, 'A');
        Music song2 = new Music(2, "Stairway to Heaven", false, 4.8, 'A');

        Console.WriteLine(song1.GetFullRating());
        Console.WriteLine(song2.GetInfo(song1));

        Type musicType = typeof(Music);
        TypeInfo musicTypeInfo = musicType.GetTypeInfo();

        Console.WriteLine($"Type Name: {musicType.Name}");

        Console.WriteLine("\nMembers:");
        foreach (MemberInfo member in musicTypeInfo.GetMembers())
        {
            Console.WriteLine($"Name: {member.Name}({member.ReflectedType}), {member.MemberType} ");
        }

        Console.WriteLine("\nFields:");
        foreach (FieldInfo fieldInfo in musicTypeInfo.DeclaredFields)
        {
            Console.WriteLine($"Name: {fieldInfo.Name}({fieldInfo.Attributes}), FieldType: {fieldInfo.FieldType}");
        }

        Console.WriteLine("\nMethods:");
        foreach (MethodInfo methodInfo in musicTypeInfo.DeclaredMethods)
        {
            Console.WriteLine($"Name: {methodInfo.Name}({methodInfo.Attributes}), MethodType: {methodInfo.ReturnType}");
        }

        Console.WriteLine("\nReflection:");
        MethodInfo reflectionMethod = musicType.GetMethod("GetInfo");
        if (reflectionMethod != null)
        {
            Music song3 = new Music(3, "Highway to hell", true, 14.5, 'B');
            Music song4 = new Music(4, "Coco jambo", false, 24.8, 'C');
            Console.WriteLine(reflectionMethod.Invoke(song4, new object[] { song3 }));
        }
        Console.ReadLine();
    }
}