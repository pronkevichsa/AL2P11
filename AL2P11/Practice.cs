using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using System.IO;



namespace AL2P11
{
    static class Practice
    {
        public static void AL2()
        {
            Console.WriteLine("input Text");

            var text = Console.ReadLine();

            Console.WriteLine("1 - console");
            Console.WriteLine("2 - file");
            Console.WriteLine("3 - picture");            
            
            var printerType = Console.ReadLine();
            Printer printer = GetPrinterByType(printerType);
            printer.Print(text);


        }

        private static Printer GetPrinterByType(string printingType)
        {
            switch (printingType)
            {
                case "1": return new ConsolePrinter(); break;
                case "2": return new FilePrinter(); break;
                case "3": return new PicturePrinter(); break;                
            }
            return null;
        }

    }

    public class ConsolePrinter:Printer
    {
        public override void Print(string text)
        {
            Console.WriteLine(text);
        }
    }

    public class FilePrinter:Printer
    { 
        public override void Print(string text)
        {
            System.IO.File.WriteAllText(@"d:\\1.txt",text);
        }
        
    }
    public class PicturePrinter:Printer
    {
        public override void Print(string text)
        {            
            Bitmap b = new Bitmap(200, 100);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.Clear(Color.White);
                g.DrawString(text, new Font("Verdana", (float)20),new SolidBrush(Color.Black), 15, b.Height / 2);
            }
            b.Save(@"d:\\1.bmp");            
        }
    }

    public abstract class Printer
    {
        public abstract void Print(string text);

    }
}
