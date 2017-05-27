using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication9
{
    enum Type_of_print
    {
        original,
        sorted
    }
    class Program
    {
        static int arr_len;  // Длина массива
        static int[] array; //Массив для сортировки
        static string user_input; // Пользовательский ввод
        static bool is_number; // Флаг ввода числа

        static void Main(string[] args)
        {
            Type_of_print type_pr;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.Title = "Курс С# и .NET";
            Console.WriteLine("Самостоятельная работа №1 \nМетод быстрой сортировки массива \nСтудент: Дмитрий Орлов \n\n");
            input_arr_len();
            array = new int[arr_len];
            input_arr_data();
            type_pr = Type_of_print.original;
            print_array(type_pr);
            very_quick_sort(array,0,arr_len-1);
            type_pr = Type_of_print.sorted;
            print_array(type_pr);
        }
         static void input_arr_len()
        {
            Console.WriteLine("Введите количество элементов массива:");
            is_number = false;
            while (!is_number)
            {
                user_input = Console.ReadLine();
                is_number = Int32.TryParse(user_input, out arr_len);
                if (!is_number)
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите число!!!");
                    Console.Beep();
                }
                else
                {
                    Console.WriteLine("Количество элементов массива:{0}", arr_len);
                }
            }
        }
         static void input_arr_data()
         {
             int i; // Счетчик по элементам массива
             int k; //Значение элемента массива
             i=0;
             is_number = false;
             Console.Clear();
             while (i<arr_len)
             {
                 Console.WriteLine("Введите {0}-й элемент массива",i+1);
                 while (!is_number)
                    {
                       user_input = Console.ReadLine();
                       is_number = Int32.TryParse(user_input, out k);
                       if (!is_number)
                        {
                          Console.Clear();
                          Console.WriteLine("Некорректный ввод. Введите {0}-й элемент массива",i+1);
                          Console.Beep();
                        }
                        else
                        {
                         array[i]=k;
                        }
                   }
                 i++;
                 is_number = false;
           }

         }
         static void print_array(Type_of_print typ_pr)
         {
             switch (typ_pr)
             {
                 case Type_of_print.original:
                     Console.Clear();
                     Console.WriteLine("Вы ввели исходный массив из {0} элементов", arr_len);
                     Console.ForegroundColor=ConsoleColor.Yellow;
                     foreach (int j in array)
                     {
                         Console.Write(j+"  ");
                     }
                     Console.ForegroundColor = ConsoleColor.White;
                     Console.WriteLine();
                     Console.WriteLine("Нажмите любую клавишу для сортировки исходного массива...");
                     Console.ReadKey();    
                     break;
                 case Type_of_print.sorted:
                      Console.WriteLine("Отсортированный массив из {0} элементов", arr_len);
                     Console.ForegroundColor=ConsoleColor.Green;
                     foreach (int j in array)
                     {
                         Console.Write(j+"  ");
                     }
                     Console.ForegroundColor = ConsoleColor.White;
                     Console.WriteLine();
                     Console.WriteLine("Нажмите любую клавишу для завершения работы...");
                     Console.ReadKey();    
                     break;
                 default:
                     break;
             }
         }
         static int  opor_elem(int[] arr_work, int left_border, int right_border, out int in_op)
         {
             int op;
             in_op=(left_border+right_border)/2;
             op=arr_work[in_op];
             return op; ;
         }
         static void very_quick_sort(int[] arr_sort,int l_b, int r_b)
         {
             int i_l, j_r; // Индексы правой и левой сторон передаваемого массива для перестановки
             int op_elem, ind_op_elem; // Значение опорного элемента
             int aux; // Дополнительная переменная для обмена значений
             op_elem = opor_elem(arr_sort, l_b,r_b, out ind_op_elem);
             i_l=l_b; // Присваиваем левую начальную границу массива для перестановки
             j_r=r_b; // Присваиваем правую начальную границу массива для перестановки

             while (i_l<=j_r) // Цикл по элементам массива пока индексы не пересекутся
             {
                 //Console.WriteLine("Индекс справа {0} индекс слева {1} опорный элемент {2}[{3}]", i_l, j_r, op_elem, ind_op_elem);
                 //Console.ReadKey();
                 while (arr_sort[i_l]<op_elem)   //Поиск в левом субмассиве элемента больше опорного
                 {
                    // Console.WriteLine("Элемент {0}[{1}]  меньше опорного элемента {2}[{3}]",arr_sort[i_l] ,i_l, op_elem, ind_op_elem);
                     i_l++;
                 }
                 while (arr_sort[j_r] > op_elem)  //Поиск в правом субмассиве элемента меньше опорного
                 {
                    // Console.WriteLine("Элемент {0}[{1}]  больше опорного элемента {2}[{3}]", arr_sort[j_r], j_r, op_elem, ind_op_elem);
                     j_r--;
                 }
                 if (i_l<=j_r)                     // Если индексы не пересеклись, то меняем элементы местами и наращиваем/уменьшаем индексы границ
                 {
                   //  Console.WriteLine("Меняем местами {0}[{1}] с  {2}[{3}]", arr_sort[i_l], i_l, arr_sort[j_r], j_r);

                     aux = arr_sort[i_l];
                     arr_sort[i_l] = arr_sort[j_r];
                     arr_sort[j_r] = aux;
                     
                     i_l++;
                     j_r--;
                    // Console.WriteLine("Индекс слева {0} индекс слева {1}", i_l,j_r);
                 }     
             }

             if (i_l<r_b) // Условие рекурсии для правого массива
             {
                 very_quick_sort(arr_sort,i_l, r_b);   
             }

             if (j_r>l_b) //Условие рекурсии для левого массива
             {
                 very_quick_sort(arr_sort,l_b, j_r);
             }
         }
    }
}
