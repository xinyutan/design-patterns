using System;
namespace ChainOfResponsibility
{
    class PhoneNumber
    {
        public string Number { get; }
        public string NationCode { get; }

        public PhoneNumber(string number, string nationCode)
        {
            Number = number;
            NationCode = nationCode;
        }
    }

    /// <summary>
    /// Handler
    /// </summary>
    abstract class PhoneApp
    {
        protected PhoneApp OtherApp;
        public abstract void Call(PhoneNumber phoneNumber);
    }

    /// <summary>
    /// ConcreteHandler1
    /// </summary>
    class GoogleHangout : PhoneApp
    {
        public override void Call(PhoneNumber phoneNumber)
        {
            Console.WriteLine("Calling phone number {0} from area {1} using Google Hangout.", phoneNumber.Number, phoneNumber.NationCode);
        }
    }

    /// <summary>
    /// ConcreteHandler2: when calling other country's number, transfer the responsibility to GoogleHangout
    /// </summary>
    class NativePhone : PhoneApp
    { 
        public void SetOtherPhoneApp(PhoneApp phoneApp)
        {
            OtherApp = phoneApp;
        }

        public override void Call(PhoneNumber phoneNumber)
        {
            if (phoneNumber.NationCode != "USA")
            {
                OtherApp.Call(phoneNumber);
            }
            else
            {
                Console.WriteLine("Calling phone number {0} from area {1} using Native Phone App.", phoneNumber.Number, phoneNumber.NationCode);
            }
        }
    }
}
