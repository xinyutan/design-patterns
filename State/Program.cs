using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("abc");
            user.AddTask();
            user.AddTask();
            user.AddTask();
            user.FinishTask();
            user.FinishTask();
            user.FinishTask();
            user.AddTask();
        }
    }
}
