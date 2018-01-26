using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linq_03_UsingCollections.Model;

namespace Linq_03_UsingCollections
{
    class Program
    {
        private static AreaDb DB= new AreaDb();
        static void Main(string[] args)
        {
            Console.BufferHeight = 10000;
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Stopwatch stp= new Stopwatch();
                stp.Start();
                Task_1();
                Console.ForegroundColor = ConsoleColor.White;
                stp.Stop();
                long seconds = stp.ElapsedMilliseconds / 100;
                Console.WriteLine("Прошло {0} миллисекунд, {1} секунд",stp.ElapsedMilliseconds,seconds);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                
                Console.ForegroundColor = ConsoleColor.White;

            }
        }

        private static Array Task_1()
        {
            Console.WriteLine("Получаем массив из базы данных");
            var a = DB.Areas.Select(s => new
            {
                s.AreaId,
                s.Name,
                s.IP,
                s.ComponentTypeId,
                s.Segment}).ToArray();
            //Area b = DB.Areas.FirstOrDefault(w => w.AreaId == 2);
            //b.TypeId = 1;
            //DB.Entry(b).State = EntityState.Modified;
            Console.WriteLine("Получили  массив из базы данных, а теперь выводим данные...");
            DB.SaveChanges();
            Console.WriteLine("---------------------------");
            foreach (var item in a)
            {
               
                Console.WriteLine("AreId : {0}\nName : {1}\nIP : {2}\n" +
                                  "ComponentTypeId : {3}\nSegment : {4}",
                    item.AreaId,item.Name,item.IP,item.ComponentTypeId,item.Segment);

                Console.WriteLine("---------------------------");
            }

            Console.WriteLine("Данные были выгружены успешно!\nИ да этот метод возвращает тип Array");
            return DB.Areas.ToArray();
        }
        
    }
}
