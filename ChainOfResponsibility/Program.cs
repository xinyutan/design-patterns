using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            // client
            var googleHangoutApp = new GoogleHangout();
            var nativePhoneApp = new NativePhone();
            nativePhoneApp.SetOtherPhoneApp(googleHangoutApp);

            var phoneNumber1 = new PhoneNumber("+8613211267511", "China");
            var phoneNumber2 = new PhoneNumber("+017343851102", "USA");

            Console.WriteLine("Call USA number: ");
            nativePhoneApp.Call(phoneNumber2);

            Console.WriteLine("\nCall China number using google hangout (cheaper): ");
            nativePhoneApp.Call(phoneNumber1);
        }
    }
}
