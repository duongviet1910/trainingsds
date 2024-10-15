using AssignmentNHibernate.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AssignmentNHibernate.Utils
{
    class InputHelper
    {
        public static Student StudentId(String mes, List<Student> students)
        {
            Boolean check = true;
            int result = 0;
            while (check)
            {
                try
                {
                    result = NumberCheckInRange(mes, 0, Int32.MaxValue);
                    foreach(var s in students)
                    {
                        if (s.Id == result) return s;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Student Id is not exist");
                }
            }
            return null;
        }
        public static Class ClassId(String mes, List<Class> classes)
        {
            Boolean check = true;
            int result = 0;
            while (check)
            {
                try
                {
                    result = NumberCheckInRange(mes, 0, Int32.MaxValue);
                    foreach (var c in classes)
                    {
                        if (c.Id == result) return c;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Class Id is not exist");
                }
            }
            return null;
        }
        public static DateTime DateCheck(String mess)
        {
            Boolean check = true;
            String result = "";
            while (check)
            {
                try
                {
                    result = StringNotBlank(mess);
                    result.Trim();
                    if (Regex.Match(result, "^(0?[1-9]|[12][0-9]|3[01])[\\/\\-](0?[1-9]|1[012])[\\/\\-]\\d{4}$").Success)
                    {

                        DateTime date = DateTime.ParseExact(result, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        if (date > DateTime.Now)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            check = false;
                            return date;
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Your input is not true. Please try again !");
                }
            }
            return DateTime.Now;
        }
        public static String StringNotBlank(String mess)
        {
            Boolean check = true;
            String result = "";
            while (check)
            {
                try
                {
                    Console.Write(mess);
                    result = Console.ReadLine();
                    if (result == null || result.Equals(""))
                    {
                        throw new Exception();
                    }
                    check = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Your input must be not blank. Please try again!");
                }
            }
            return result;
        }
        public static int NumberCheck(String mess)
        {
            Boolean check = true;
            int result = 0;
            while (check)
            {
                try
                {
                    Console.Write(mess);
                    result = Convert.ToInt32(Console.ReadLine());
                    check = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Your input is not valid. Please try again !");
                }
            }
            return result;
        }
        public static int NumberCheckInRange(String mess, int min, int max)
        {
            Boolean check = true;
            int result = 0;
            while (check)
            {
                result = NumberCheck(mess);
                if (result >= min && result <= max)
                {
                    check = false;
                }
                else
                {
                    Console.WriteLine($"Your input is not in range {min} to {max}");
                }
            }

            return result;

        }
    }
}
