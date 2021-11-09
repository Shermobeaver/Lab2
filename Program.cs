using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Numerics;


namespace Lab_2
{
    // Program
    class Program
    {
        static void ConsoleWiteRed(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ConsoleWiteBlue(string str)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ConsoleWiteGreen(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ListAndFile()
        {
            Vector2 vector_1 = new(0.5f, 0.01f);
            V2DataArray array = new("Array", DateTime.Now, 3, 2, vector_1, FuncV2Complex.FuncV2Complex_1);
            V2DataList list_copy = array;
            Console.WriteLine(list_copy.ToLongString("F4"));
            list_copy.SaveAsText("ListSave.txt");
            ConsoleWiteBlue("\n\n------------------------\n\n");
            V2DataList list_new = new("List", DateTime.Now);
            Console.WriteLine(list_new.ToLongString("F4"));
            ConsoleWiteBlue("\n\n------------------------\n\n");
            list_new.LoadAsText("ListSave.txt", ref list_new);
            Console.WriteLine(list_new.ToLongString("F4"));
        }

        static void ArrayAndFile()
        {
            Vector2 vector_1 = new(0.5f, 0.01f);
            V2DataArray array = new("Array 1", DateTime.Now, 3, 2, vector_1, FuncV2Complex.FuncV2Complex_1);
            Console.WriteLine(array.ToLongString("F4"));
            array.SaveBinary("ListSave.txt");
            ConsoleWiteBlue("\n\n------------------------\n\n");
            Vector2 vector_2 = new(0.5f, 0.01f);
            V2DataArray array_new = new("Array 2", DateTime.Now, 4, 5, vector_2, FuncV2Complex.FuncV2Complex_1);
            Console.WriteLine(array_new.ToLongString("F4"));
            ConsoleWiteBlue("\n\n------------------------\n\n");
            array.LoadBinary("ListSave.txt", ref array_new);
            Console.WriteLine(array_new.ToLongString("F4"));
        }

        static void LINQour1()
        {
            Vector2 vector_1 = new(0.5f, 0.01f);
            V2DataArray array = new("Array", DateTime.Now, 3, 1, vector_1, FuncV2Complex.FuncV2Complex_1);
            V2DataList list = new("List", DateTime.Now);
            list.Add(new(new(10, 40), new(2, 1)));
            list.Add(new(new(20, 80), new(3, 0)));
            V2MainCollection CollectionV2 = new();
            CollectionV2.Add(array);
            CollectionV2.Add(list);
            Console.WriteLine(CollectionV2.ToLongString("F4"));
            Console.WriteLine("\n\n------------------------\n\n");
            ConsoleWiteGreen("____MaxDistance____:\n\n");
            Console.WriteLine(CollectionV2.MaxDistance);
            ConsoleWiteGreen("\n\n____UniquePoints____:\n\n");
            var UniqueP = CollectionV2.UniquePoints;
            if (UniqueP != null)
            {
                foreach (Vector2 point in CollectionV2.UniquePoints)
                {
                    Console.WriteLine(point.ToString("F4"));
                }
            }
            else
            {
                Console.WriteLine("It is NULL");
            }
            ConsoleWiteGreen("\n\n____V2DataListImNoneZ____:\n\n");
            var ImNoneZ = CollectionV2.V2DataListImNoneZ;
            if (ImNoneZ != null)
            {
                foreach (V2DataList item in ImNoneZ)
                {
                    Console.WriteLine(item.ToLongString("F4"));
                }
            }
            else
            {
                Console.WriteLine("It is NULL");
            }
        }

        static void LINQour2()
        {
            V2MainCollection CollectionV2 = new();
            Console.WriteLine(CollectionV2.ToLongString("F4"));
            Console.WriteLine("\n\n------------------------\n\n");
            ConsoleWiteGreen("____MaxDistance____:\n\n");
            Console.WriteLine(CollectionV2.MaxDistance);
            ConsoleWiteGreen("\n\n____UniquePoints____:\n\n");
            var UniqueP = CollectionV2.UniquePoints;
            if (UniqueP != null)
            {
                foreach (Vector2 point in CollectionV2.UniquePoints)
                {
                    Console.WriteLine(point.ToString("F4"));
                }
            }
            else
            {
                Console.WriteLine("It is NULL");
            }
            ConsoleWiteGreen("\n\n____V2DataListImNoneZ____:\n\n");
            var ImNoneZ = CollectionV2.V2DataListImNoneZ;
            if (ImNoneZ != null)
            {
                foreach (V2DataList item in ImNoneZ)
                {
                    Console.WriteLine(item.ToLongString("F4"));
                }
            }
            else
            {
                Console.WriteLine("It is NULL");
            }
        }

        static void LINQour3()
        {
            V2DataList list_1 = new("List 1", DateTime.Now);
            list_1.Add(new(new(10, 40), new(2, 1)));
            list_1.Add(new(new(20, 80), new(3, 4)));
            V2DataList list_2 = new("List 2", DateTime.Now);
            V2MainCollection CollectionV2 = new();
            CollectionV2.Add(list_1);
            CollectionV2.Add(list_2);
            Console.WriteLine(CollectionV2.ToLongString("F4"));
            Console.WriteLine("\n\n------------------------\n\n");
            ConsoleWiteGreen("____MaxDistance____:\n\n");
            Console.WriteLine(CollectionV2.MaxDistance);
            ConsoleWiteGreen("\n\n____UniquePoints____:\n\n");
            var UniqueP = CollectionV2.UniquePoints;
            if (UniqueP != null)
            {
                foreach (Vector2 point in CollectionV2.UniquePoints)
                {
                    Console.WriteLine(point.ToString("F4"));
                }
            }
            else
            {
                Console.WriteLine("It is NULL");
            }
            ConsoleWiteGreen("\n\n____V2DataListImNoneZ____:\n\n");
            var ImNoneZ = CollectionV2.V2DataListImNoneZ;
            if (ImNoneZ != null)
            {
                foreach (V2DataList item in ImNoneZ)
                {
                    Console.WriteLine(item.ToLongString("F4"));
                }
            }
            else
            {
                Console.WriteLine("It is NULL");
            }
        }

        static void LINQour4()
        {
            Vector2 vector_1 = new(0.5f, 0.01f);
            V2DataArray array_1 = new("Array 1", DateTime.Now, 3, 1, vector_1, FuncV2Complex.FuncV2Complex_1);
            V2DataList list = new("List", DateTime.Now);
            V2DataArray array_2 = new("Array 2", DateTime.Now, 2, 2, vector_1, FuncV2Complex.FuncV2Complex_1);
            list.Add(new(new(10, 40), new(2, 1)));
            list.Add(new(new(20, 80), new(3, 0)));
            V2MainCollection CollectionV2 = new();
            CollectionV2.Add(array_1);
            CollectionV2.Add(array_2);
            CollectionV2.Add(list);
            Console.WriteLine(CollectionV2.ToLongString("F4"));
            Console.WriteLine("\n\n------------------------\n\n");
            ConsoleWiteGreen("____MaxDistance____:\n\n");
            Console.WriteLine(CollectionV2.MaxDistance);
            ConsoleWiteGreen("\n\n____UniquePoints____:\n\n");
            var UniqueP = CollectionV2.UniquePoints;
            if (UniqueP != null)
            {
                foreach (Vector2 point in CollectionV2.UniquePoints)
                {
                    Console.WriteLine(point.ToString("F4"));
                }
            }
            else
            {
                Console.WriteLine("It is NULL");
            }
            ConsoleWiteGreen("\n\n____V2DataListImNoneZ____:\n\n");
            var ImNoneZ = CollectionV2.V2DataListImNoneZ;
            if (ImNoneZ != null)
            {
                foreach (V2DataList item in ImNoneZ)
                {
                    Console.WriteLine(item.ToLongString("F4"));
                }
            }
            else
            {
                Console.WriteLine("It is NULL");
            }
        }

        static void LINQour5()
        {
            V2DataList list = new("List", DateTime.Now);
            list.Add(new(new(10, 40), new(2, 1)));
            V2MainCollection CollectionV2 = new();
            CollectionV2.Add(list);
            Console.WriteLine(CollectionV2.ToLongString("F4"));
            Console.WriteLine("\n\n------------------------\n\n");
            ConsoleWiteGreen("____MaxDistance____:\n\n");
            Console.WriteLine(CollectionV2.MaxDistance);
            ConsoleWiteGreen("\n\n____UniquePoints____:\n\n");
            var UniqueP = CollectionV2.UniquePoints;
            if (UniqueP != null)
            {
                foreach (Vector2 point in CollectionV2.UniquePoints)
                {
                    Console.WriteLine(point.ToString("F4"));
                }
            }
            else
            {
                Console.WriteLine("It is NULL");
            }
            ConsoleWiteGreen("\n\n____V2DataListImNoneZ____:\n\n");
            var ImNoneZ = CollectionV2.V2DataListImNoneZ;
            if (ImNoneZ != null)
            {
                foreach (V2DataList item in ImNoneZ)
                {
                    Console.WriteLine(item.ToLongString("F4"));
                }
            }
            else
            {
                Console.WriteLine("It is NULL");
            }
        }

        static void LINQour6()
        {
            Vector2 vector_1 = new(0.5f, 0.01f);
            V2DataArray array = new("Array", DateTime.Now, 0, 0, vector_1, FuncV2Complex.FuncV2Complex_1);
            V2MainCollection CollectionV2 = new();
            CollectionV2.Add(array);
            Console.WriteLine(CollectionV2.ToLongString("F4"));
            Console.WriteLine("\n\n------------------------\n\n");
            ConsoleWiteGreen("____MaxDistance____:\n\n");
            Console.WriteLine(CollectionV2.MaxDistance);
            ConsoleWiteGreen("\n\n____UniquePoints____:\n\n");
            var UniqueP = CollectionV2.UniquePoints;
            if (UniqueP != null)
            {
                foreach (Vector2 point in CollectionV2.UniquePoints)
                {
                    Console.WriteLine(point.ToString("F4"));
                }
            }
            else
            {
                Console.WriteLine("It is NULL");
            }
            ConsoleWiteGreen("\n\n____V2DataListImNoneZ____:\n\n");
            var ImNoneZ = CollectionV2.V2DataListImNoneZ;
            if (ImNoneZ != null)
            {
                foreach (V2DataList item in ImNoneZ)
                {
                    Console.WriteLine(item.ToLongString("F4"));
                }
            }
            else
            {
                Console.WriteLine("It is NULL");
            }
        }

        static void Main()
        {
            //ConsoleWiteRed("____ListAndFile____:\n\n");
            //ListAndFile();
            //ConsoleWiteRed("\n\n========================\n\n");
            //ConsoleWiteRed("____ArrayAndFile____:\n\n");
            //ArrayAndFile();
            //ConsoleWiteRed("\n\n========================\n\n");
            //ConsoleWiteRed("____LINQour1____:\n\n");
            //LINQour1();
            //ConsoleWiteRed("\n\n========================\n\n");
            //ConsoleWiteRed("____LINQour2____:\n\n");
            //LINQour2();
            //ConsoleWiteRed("\n\n========================\n\n");
            //ConsoleWiteRed("____LINQour3____:\n\n");
            //LINQour3();
            //ConsoleWiteRed("\n\n========================\n\n");
            ConsoleWiteRed("____LINQour4____:\n\n");
            LINQour4();
            ConsoleWiteRed("\n\n========================\n\n");
            //ConsoleWiteRed("____LINQour5____:\n\n");
            //LINQour5();
            //ConsoleWiteRed("\n\n========================\n\n");
            //ConsoleWiteRed("____LINQour6____:\n\n");
            //LINQour6();
            //ConsoleWiteRed("\n\n========================\n\n");
        }
    }
}
