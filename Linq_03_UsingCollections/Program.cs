using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Linq_03_UsingCollections.BestNameSpace;
using Linq_03_UsingCollections.Model;

namespace Linq_03_UsingCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BufferHeight = 10000;
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Stopwatch stp = new Stopwatch();
                int option = 2;
                for (int i = 1; i <= 11; i++)
                {
                    Console.WriteLine("{0} - Task_{0}", i);
                }
                Console.WriteLine("0 - Exit");
                start:
                int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 0:
                        {
                            stp.Start();
                            Console.Clear();
                            stp.Stop();
                            break;
                        }
                    case 1:
                        {
                            stp.Start();
                            Console.WriteLine("Класс Area был создан успешно!");
                            stp.Stop();
                            break;
                        }
                    case 2:
                        {
                            stp.Start();
                            Console.WriteLine("Метод по выгрузке данных из БД был реализован успешно!");
                            stp.Stop();
                            break;

                        }
                    case 3:
                        {
                            stp.Start();
                            Console.WriteLine("Создаем метод, который возвращает данные в виде Array.");
                            Array task1Arr = BestStruct.Task_3;
                            stp.Stop();
                            break;
                        }
                    case 4:
                        {
                            stp.Start();
                            Console.WriteLine("Создаем  метод, который возвращает данные в виде List<Area> ");
                            List<Area> taskList2 = BestStruct.Task_4();
                            stp.Stop();
                            break;
                        }
                    case 5:
                        {
                            stp.Start();
                            BestStruct.Task_5();
                            stp.Stop();
                            break;
                        }
                    case 6:
                        {
                            stp.Start();
                            BestStruct.Task_6();
                            stp.Stop();
                            break;
                        }
                    case 7:
                        {
                            stp.Start();
                            BestStruct.Task_7();
                            stp.Stop();
                            break;
                        }
                    case 8:
                        {
                            stp.Start();
                            BestStruct.Task_8();
                            stp.Stop();
                            break;
                        }
                    case 9:
                        {
                            stp.Start();
                            BestStruct.Task_9();
                            stp.Stop();
                            break;
                        }
                    case 10:
                        {
                            stp.Start();
                            Console.WriteLine("Запустить подфункцию A функции 10 нажмите 1 ");
                            Console.WriteLine("Запустить подфункцию B функции 10 нажмите 2 ");
                            int.TryParse(Console.ReadLine(), out option);
                            Console.WriteLine(BestStruct.Task_10(option));
                            stp.Stop();
                            break;
                        }
                    case 11:
                        {
                            stp.Start();
                            BestStruct.Task_11();
                            stp.Stop();
                            break;
                        }
                    default:
                        stp.Start();
                        Console.WriteLine("Хммм ... что-то не получилось)");
                        goto start;

                }
                Console.ForegroundColor = ConsoleColor.White;

                double seconds = (double)stp.ElapsedMilliseconds / 100;
                Console.WriteLine("Прошло {0} миллисекунд, {1} секунд", stp.ElapsedMilliseconds, seconds);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    namespace BestNameSpace
    {
        struct BestStruct
        {
            private static AreaDb DB = new AreaDb();
            public static Array Task_3
            {
                get
                {
                    Console.WriteLine("Получаем массив из базы данных");
                    var a = DB.Areas.Select(s => new
                    {
                        s.AreaId,
                        s.Name,
                        s.IP,
                        s.ComponentTypeId,
                        s.Segment
                    }).ToArray();
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
                            item.AreaId, item.Name, item.IP, item.ComponentTypeId, item.Segment);

                        Console.WriteLine("---------------------------");
                    }


                    Console.WriteLine("Данные были выгружены успешно!\nИ да этот метод возвращает тип Array");
                    return DB.Areas.ToArray();
                }
            }

            public static List<Area> Task_4()
            {
                List<Area> a = DB.Areas.ToList();
                Console.WriteLine("Получили  массив из базы данных, а теперь выводим данные...");
                DB.SaveChanges();
                Console.WriteLine("---------------------------");
                foreach (var item in a)
                {

                    Console.WriteLine("AreId : {0}\nName : {1}\nIP : {2}\n" +
                                      "ComponentTypeId : {3}\nSegment : {4}",
                        item.AreaId, item.Name, item.IP, item.ComponentTypeId, item.Segment);

                    Console.WriteLine("---------------------------");
                }


                Console.WriteLine("Данные были выгружены успешно!\nИ да этот метод возвращает тип List");

                return a;
            }

            public static void Task_5()
            {
                Dictionary<int, string> a = DB.Areas.Where(w => !string.IsNullOrEmpty(w.IP)).Select(s => new
                {
                    s.AreaId,
                    s.IP
                }).ToDictionary(w => w.AreaId, w => w.IP);
                foreach (KeyValuePair<int, string> item in a)
                {
                    Console.WriteLine("AreaId : {0} , IP : {1}", item.Key, item.Value);
                }
            }

            public static void Task_6()
            {
                Dictionary<int, string> a = DB.Areas.Where(w => !string.IsNullOrEmpty(w.IP) && w.ParentId != 0).Select(s => new
                {
                    s.AreaId,
                    s.IP
                }).ToDictionary(w => w.AreaId, w => w.IP);
                foreach (KeyValuePair<int, string> item in a)
                {
                    Console.WriteLine("AreaId : {0} , IP : {1}", item.Key, item.Value);
                }
            }

            public static void Task_7()
            {



                ILookup<string, Area> d = DB.Areas.Where(w => !string.IsNullOrEmpty(w.IP)).ToLookup(l => l.IP);
                foreach (IGrouping<string, Area> item in d)
                {
                    Area first = null;
                    foreach (var f in item)
                    {
                        if (f.IP == item.Key)
                        {
                            first = f;
                            break;
                        }
                    }

                    if (first != null) Console.WriteLine("IP : {0} , Name : {1}", item.Key, first.Name);
                }
            }

            public static void Task_8()
            {
                Area item = DB.Areas.FirstOrDefault(f => f.HiddenArea == true);
                Console.WriteLine("AreId : {0}\nName : {1}\nIP : {2}\n" +
                                  "ComponentTypeId : {3}\nSegment : {4}",
                    item.AreaId, item.Name, item.IP, item.ComponentTypeId, item.Segment);
            }

            public static void Task_9()
            {
                var areas = DB.Areas.ToList();
                var item = areas.LastOrDefault(f => f.PavilionId == 1);
                Console.WriteLine("AreId : {0}\nName : {1}\nIP : {2}\n" +
                                  "ComponentTypeId : {3}\nSegment : {4}\nPavillionId : {5}",
                    item.AreaId, item.Name, item.IP, item.ComponentTypeId, item.Segment, item.PavilionId);
            }

            public static string Task_10(int option)
            {
                switch (option)
                {
                    case 0:
                        Task10A();
                        return null;
                    case 1:
                        Task10B();
                        return null;
                    default:
                        return "Сюда пришло что-то не то";
                }
                void Task10A()
                {
                    string[] ip = { "10.53.34.85", "10.53.34.77", "10.53.34.53" };
                    bool a = DB.Areas.Where(w => w.PavilionId == 1).Any(b => ip.Contains(b.IP));
                    List<Area> dAreas = DB.Areas.Where(w => w.PavilionId == 1 && ip.Contains(w.IP)).ToList();
                    if (a)
                    {
                        Console.WriteLine("Выводим данные на экран ...");
                        Console.WriteLine("---------------");
                        foreach (Area item in dAreas)
                        {
                            Console.WriteLine("AreId : {0}\nName : {1}\nIP : {2}\n" +
                                              "ComponentTypeId : {3}\nSegment : {4}\nPavillionId : {5}",
                                item.AreaId, item.Name, item.IP, item.ComponentTypeId, item.Segment, item.PavilionId);
                            Console.WriteLine("---------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("По данному условию ничего не найдено!");
                    }
                }
                void Task10B()
                {
                    string[] expression = { "PT disassembly", "Engine testing" };
                    bool any = DB.Areas.Any(w => expression.Contains(w.Name));
                    List<Area> a = DB.Areas.Where(w => expression.Contains(w.Name)).ToList();

                    Console.WriteLine("---------------");
                    if (any)
                    {
                        Console.WriteLine("Выводим данные на экран ...");
                        foreach (Area item in a)
                        {
                            Console.WriteLine("AreId : {0}\nName : {1}\nIP : {2}\n" +
                                              "ComponentTypeId : {3}\nSegment : {4}\nPavillionId : {5}",
                                item.AreaId, item.Name, item.IP, item.ComponentTypeId, item.Segment, item.PavilionId);
                            Console.WriteLine("---------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("По данному условию ничего не найдено!");
                    }
                }
            }

            public static void Task_11()
            {
                var a = DB.Areas.Select(s => new
                {
                    s.WorkingPeople
                }).ToList();
                int counter = 0;
                foreach (var item in a)
                {
                    counter += (int)item.WorkingPeople;
                }

                Console.WriteLine("Сумма всех работающих работников на зонах = {0}", counter);
            }
        }
    }


}
