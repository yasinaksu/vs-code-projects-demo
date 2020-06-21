using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            //customerManager.MessageSenderBase=new EmailSender();
            customerManager.MessageSenderBase = new SmsSender();
            customerManager.Add();
        }
    }

    class EmailSender : MessageSenderBase
    {
        public override void SendMessage(string message)
        {
            Console.WriteLine("Email Message: "+message);
        }
    }

    class SmsSender : MessageSenderBase
    {
        public override void SendMessage(string message)
        {
            Console.WriteLine("Sms Message: "+message);
        }
    }

    abstract class MessageSenderBase
    {
        public abstract void SendMessage(string message);
    }

    class CustomerManager
    {
        public MessageSenderBase MessageSenderBase { get;  set; }

        public void Add()
        {
            Console.WriteLine("Customer added");
            MessageSenderBase.SendMessage("Customer was added by Employee1.");
        }
    }
}
