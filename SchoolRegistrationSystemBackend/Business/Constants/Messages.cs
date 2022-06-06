using System;
using System.Runtime.Serialization;

namespace Business.Constants
{
    public static class Messages
    {
        //Register && Login Result Messages
        public static string UserNotFound = "User not found";

        public static string PasswordError = "Incorrect Password";

        public static string SuccessfullLogin = "Successfully Login";

        public static string UserAlreadyExists = "This User is Registered in the System";

        public static string UserRegistered = "User Registered Successfully";

        public static string AccessTokenCreated = "Access Token Created";

        public static string AuthorizationDenied = "Authorization Denied";

        //Lesson Messages

        public static string LessonAddedSuccessfully = "Lesson Added Successfully";

        public static string LessonDeletedSuccessfully = "Lesson Deleted Successfully";

        public static string LessonUpdatedSuccessfully = "Lesson Updated Successfully";

        //Student Lessons Messages

        public static string LessonAdded = "Lessons Registration Successfully Done";

        public static string LessonDeleted = "Lessons Injection Successfully Done";
    }
}
