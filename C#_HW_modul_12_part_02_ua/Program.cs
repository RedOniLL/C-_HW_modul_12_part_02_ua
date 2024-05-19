namespace C__HW_modul_12_part_02_ua
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PoemCollection collection = new PoemCollection();
            ReportGenerator reportGenerator = new ReportGenerator();


            collection.AddPoem(new Poem { Title = "Title1", Author = "Author1", Year = 2000, Text = "Text1", Theme = "Theme1" });
            collection.AddPoem(new Poem { Title = "Title2", Author = "Author2", Year = 2005, Text = "Text2", Theme = "Theme2" });

            var poemsWithTitle = collection.SearchByTitle("Title1");
            reportGenerator.GenerateTitleReport(poemsWithTitle);

            var poemsWithAuthor = collection.SearchByAuthor("Author1");
            reportGenerator.GenerateAuthorReport(poemsWithAuthor);

            var poemsWithTheme = collection.SearchByTheme("Theme1");
            reportGenerator.GenerateThemeReport(poemsWithTheme);

            collection.SaveToFile("poems.txt");

            collection.LoadFromFile("poems.txt");
        }
    }
}
