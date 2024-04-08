using System.Reflection.Metadata;
using System.Transactions;

namespace ksiegarnia
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                string json = File.ReadAllText("ksiazki.json");
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}