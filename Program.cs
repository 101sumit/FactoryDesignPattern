using System;

public interface INotification
{
    public void SendNotification(string str);
}

public class SMS: INotification
{
    public void SendNotification(string msg)
    {
        Console.WriteLine("SMS " + msg);
    }
}

public class Email:INotification
{
    public void SendNotification(string msg)
    {
        Console.WriteLine("Email " + msg);
    }
}

public class WhatsApp:INotification
{
    public void SendNotification(string msg)
    {
        Console.WriteLine("WhatsApp " + msg);
    }
}

public class NotificationFactory
{
    public INotification CreateNotificationInstance(string str)
    {
        switch(str)
        {
            case "sms": 
                return new SMS();
            case "email":
                return new Email();
            case "whatsapp":
                return new WhatsApp();
            default:
                throw new Exception("Notification type not supported");
        }
    }
}

public class NotificationService
{
    private readonly NotificationFactory _notificationFactory;

    public NotificationService()
    {
        _notificationFactory = new NotificationFactory();
    }

    public void SendNotification(string type, string message)
    {
        INotification notification = _notificationFactory.CreateNotificationInstance(type);
        notification.SendNotification(message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        NotificationService service = new NotificationService();
        service.SendNotification("sms", "Your OTP is 123456");
        service.SendNotification("email", "Welcome to our service!");
        service.SendNotification("whatsapp", "Your package has been shipped.");
    }
}
