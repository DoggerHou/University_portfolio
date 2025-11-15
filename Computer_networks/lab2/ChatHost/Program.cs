using System;
using System.ServiceModel;


namespace ChatHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var host = new ServiceHost(typeof(Laba_2__IP_TCP.ServiceChat)))
                {
                    host.Open();
                    Console.WriteLine("Сервер запущен. Нажмите Enter для остановки.");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при запуске сервера:");
                Console.WriteLine(ex);
                Console.ReadLine(); // чтобы окно не закрылось
            }
        }
    }
}
