using System;
namespace Core.Utilities.Security.Numerator
{
    public class Numerator
    {
        public static int CreateEducatorNumber()
        {
            Random random = new Random();

            int educatorNumber = random.Next(210000, 219999);

            return educatorNumber;
        }

        public static int CreateStudentNumber()
        {
            Random random = new Random();

            int studentNumber = random.Next(21000000, 21999999);

            return studentNumber;
        }

        public static int CreateStudentLessonId()
        {
            Random random = new Random();

            int studentLessonId = random.Next(0, 100000);

            return studentLessonId;
        }
    }
}
