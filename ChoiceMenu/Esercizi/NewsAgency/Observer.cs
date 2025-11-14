using System.Net;

public interface INewsSubscriber
{
    void Update(string news);
}

public class NewsAgency
{
    private static NewsAgency _instance; // lazy singleton backing field
    private string _news;
    private readonly List<INewsSubscriber> _newsAgencyList = new List<INewsSubscriber>();

    public NewsAgency(){}

    // Lazy initialization of the singleton instance (simple, non-thread-safe)
    public static NewsAgency Instance
    {
        get
        {
            if (_instance == null)
                _instance = new NewsAgency();
            return _instance;
        }
    }

    public string News
    {
        get { return _news; }
        set
        {
            _news = value;
            Notify();
        }

    }

    public void AddSubscriber(INewsSubscriber newsSubscriber)
    {
        _newsAgencyList.Add(newsSubscriber);
    }

    public void RemoveSubscriber(INewsSubscriber newsSubscriber)
    {
        _newsAgencyList.Remove(newsSubscriber);
    }

    public void Notify()
    {
        foreach (INewsSubscriber newsSubscriber in _newsAgencyList)
        {
            newsSubscriber.Update(News);
        }
    }
}


class MobileApp : INewsSubscriber
{
    public void Update(string news)
    {
        Console.WriteLine($"Notification on mobile: {news}");
    }
}

class EmailClient : INewsSubscriber
{
    public void Update(string news)
    {
        Console.WriteLine($"Email sent: {news}");
    }
}