using System;
using System.IO;
using System.Xml;


/// @author savevalo
/// @version 16.2.2024
/// <summary>
/// sovellus hakee pelaajan mmr pisteiden määrän
/// </summary>
public class huntmmr
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    private static XmlDocument doc = new XmlDocument();
    private static XmlNode attribuuttiNode;
    public static void Main()
    {
        // loading the document and node
        //XmlDocument doc = new XmlDocument();
        doc.Load("K:\\Steam\\steamapps\\common\\Hunt Showdown\\user\\profiles\\default\\attributes.xml");
        attribuuttiNode = doc.SelectSingleNode("/Attributes[@Version='37']/Attr[@name='MissionBagPlayer_11_0_mmr']/@value");

        // adding a file watcher
        using var watcher = new FileSystemWatcher("K:\\Steam\\steamapps\\common\\Hunt Showdown\\user\\profiles\\default\\");
        watcher.NotifyFilter = NotifyFilters.LastWrite;
        watcher.Changed += OnChanged;
        watcher.Filter = "attributes.xml";
        watcher.EnableRaisingEvents = true;


        if (attribuuttiNode != null)
        {
            // Tulostetaan attribuutin arvo
            string attribuutinArvo = attribuuttiNode.Value;
            Console.WriteLine("MMR pisteiden määrä: " + attribuutinArvo);
        }
        else
        {
            Console.WriteLine("MMR pisteiden määrää ei löytynyt.");
        }

        Console.WriteLine("Press enter / Crtl+C to exit.");
        Console.ReadLine();

    }

    private static void OnChanged(object sender, FileSystemEventArgs e)
    {
        if (e.ChangeType != WatcherChangeTypes.Changed)
        {
            return;
        }
        if (attribuuttiNode != null)
        {
            // Tulostetaan attribuutin arvo
            string attribuutinArvo = attribuuttiNode.Value;
            Console.WriteLine("MMR pisteiden määrä: " + attribuutinArvo);
        }
        else
        {
            Console.WriteLine("MMR pisteiden määrää ei löytynyt.");
        }

    }

}
