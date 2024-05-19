using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__HW_modul_12_part_02_ua
{
    class Poem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Text { get; set; }
        public string Theme { get; set; }
    }

    class PoemCollection
    {
        private List<Poem> poems = new List<Poem>();

        public void AddPoem(Poem poem)
        {
            poems.Add(poem);
        }

        public void RemovePoem(string title)
        {
            poems.RemoveAll(p => p.Title == title);
        }

        public void UpdatePoem(string title, Poem updatedPoem)
        {
            var poemToUpdate = poems.Find(p => p.Title == title);
            if (poemToUpdate != null)
            {
                poemToUpdate.Author = updatedPoem.Author;
                poemToUpdate.Year = updatedPoem.Year;
                poemToUpdate.Text = updatedPoem.Text;
                poemToUpdate.Theme = updatedPoem.Theme;
            }
        }

        public List<Poem> SearchByTitle(string title)
        {
            return poems.Where(p => p.Title.Contains(title)).ToList();
        }

        public List<Poem> SearchByAuthor(string author)
        {
            return poems.Where(p => p.Author.Contains(author)).ToList();
        }

        public List<Poem> SearchByTheme(string theme)
        {
            return poems.Where(p => p.Theme.Contains(theme)).ToList();
        }

        public List<Poem> SearchByWord(string word)
        {
            return poems.Where(p => p.Text.Contains(word)).ToList();
        }

        public List<Poem> SearchByYear(int year)
        {
            return poems.Where(p => p.Year == year).ToList();
        }

        public List<Poem> SearchByLength(int length)
        {
            return poems.Where(p => p.Text.Split(' ').Length == length).ToList();
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (var poem in poems)
                {
                    sw.WriteLine($"{poem.Title},{poem.Author},{poem.Year},{poem.Theme},{poem.Text}");
                }
            }
        }

        public void LoadFromFile(string filename)
        {
            poems.Clear();
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    poems.Add(new Poem
                    {
                        Title = parts[0],
                        Author = parts[1],
                        Year = int.Parse(parts[2]),
                        Theme = parts[3],
                        Text = parts[4]
                    });
                }
            }
        }
    }

    class ReportGenerator
    {
        public void GenerateTitleReport(List<Poem> poems)
        {
            foreach (var poem in poems)
            {
                Console.WriteLine($"Title: {poem.Title}, Author: {poem.Author}, Year: {poem.Year}, Theme: {poem.Theme}");
            }
        }

        public void GenerateAuthorReport(List<Poem> poems)
        {
            foreach (var poem in poems)
            {
                Console.WriteLine($"Author: {poem.Author}, Title: {poem.Title}, Year: {poem.Year}, Theme: {poem.Theme}");
            }
        }

        public void GenerateThemeReport(List<Poem> poems)
        {
            foreach (var poem in poems)
            {
                Console.WriteLine($"Theme: {poem.Theme}, Title: {poem.Title}, Author: {poem.Author}, Year: {poem.Year}");
            }
        }
    }
}
