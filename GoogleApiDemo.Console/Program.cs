using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using System.Linq;

namespace GoogleApiDemo.Console
{
    class Program
    {
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";

        static void Main(string[] args)
        {
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                ApiKey = "<API Key>",
                ApplicationName = ApplicationName,

            });

            var events = service.Events.List("en-gb.mt#holiday@group.v.calendar.google.com").Execute();


            foreach (var myEvent in events.Items.OrderByDescending(x => x.Start.Date))
            {
                System.Console.WriteLine(string.Format("Event: {0} Start: {1} End: {2}", myEvent.Summary, myEvent.Start.Date, myEvent.End.Date));
            }

            System.Console.ReadKey();
        }
    }
}
