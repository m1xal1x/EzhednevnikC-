using Ezhednevnik;

namespace ezhednevnik
{
    class Ezhednevnik
    {
        static ConsoleKeyInfo key;
        static int position = 2;
        static DateTime Datavmenu = new DateTime();
        static Note Note1014 = new Note() { title = "Одежда", description = "Купить себе новую пару кроссовок", DateNote = new DateTime(2023, 10, 14) };
        static Note Note10141 = new Note() { title = "Футбол", description = "Сходить с друзьями на футбольную площадку и поиграть", DateNote = new DateTime(2023, 10, 14) };
        static Note Note10142 = new Note() { title = "Домашнее задание", description = "Сделать практическую работу по C#", DateNote = new DateTime(2023, 10, 14) };
        static Note Note10151 = new Note() { title = "Выходной", description = "Время, чтобы отдохнуть и ничего не делать", DateNote = new DateTime(2023, 10, 15) };
        static Note Note1016 = new Note() { title = "Пойти погулять", description = "Позвать Славу и отправиться в Москва-сити", DateNote = new DateTime(2023, 10, 16) };
        static Note Note10161 = new Note() { title = "Суицид", description = "Скинуться с крыши (по возможности)", DateNote = new DateTime(2023, 10, 16) };
        static List<Note> notes = new List<Note> { Note1014, Note10141, Note10142, Note10151, Note1016, Note10161 };
        static void Main(string[] args)
        {
            Datavmenu = DateTime.Today;
            DateChange(key);
        }
        static void Strelki(ConsoleKeyInfo key, int numnote)
        {
            while (key.Key != ConsoleKey.Escape)
            {
                Console.SetCursorPosition(0, position);
                Console.Write("  ");
                if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.LeftArrow)
                {
                    Console.Clear();
                    DateChange(key);
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (position == 2)
                    {
                        position = numnote;
                    }
                    else
                    {
                        position--;
                    }
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (position == numnote)
                    {
                        position = 2;
                    }
                    else
                    {
                        position++;
                    }
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    PolnoeMenu(key);
                }
                Console.SetCursorPosition(0, position);
                Console.Write("->");
                key = Console.ReadKey();
            }
        }
        static void DateChange(ConsoleKeyInfo key)
        {
            int numnote = 1;
            Console.WriteLine("Дата: " + Datavmenu.ToShortDateString());
            Console.WriteLine("Ваши заметки:");
            List<Note> sorted = notes.Where(item => item.DateNote.Date == Datavmenu.Date).ToList();
            foreach (Note item in sorted)
            {
                Console.WriteLine("  " + numnote + ". " + item.title);
                numnote++;
            }
            key = Console.ReadKey();
            while (key.Key != ConsoleKey.Escape)
            {
                if (key.Key == ConsoleKey.RightArrow)
                {
                    Console.Clear();
                    Datavmenu = Datavmenu.AddDays(1);
                    DateChange(key);
                }
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    Console.Clear();
                    Datavmenu = Datavmenu.AddDays(-1);
                    DateChange(key);
                }
                if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.UpArrow)
                {
                    Strelki(key, numnote);
                }
            }
        }
        static void PolnoeMenu(ConsoleKeyInfo key)
        {
            var a = notes.Where(item => item.DateNote.Date == Datavmenu.Date).ToList()[position - 2];
            Console.WriteLine(a.title);
            Console.WriteLine("Описание: " + a.description);
            Console.WriteLine("Дата: " + a.DateNote);
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                DateChange(key);
            }
        }
    }
}
