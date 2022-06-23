

public class Program
{
    static void Main(string[] args)
    {
        Thread thread = new Thread(WriteUsingNewThread);
        thread.Name = "worker";
        //Worker Thread
        thread.Start();
        Thread.CurrentThread.Name = "main";
        for(int i = 0; i < 1000; i++)
        {
            Console.WriteLine("A" + i + " ");
        }
    }

    private static void WriteUsingNewThread()
    {
        for(int i = 0; i < 1000; i++)
        {
            Console.WriteLine("z" + i + " ");
        }
    }

}