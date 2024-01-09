using Helpers;
using Microsoft.AspNetCore.Mvc;
using ProgramUtilities;
using System.Text;

namespace KALENDARb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public string Get(string? command,
            string? sy, string? sm, string? sd,
            string? ey, string? em, string? ed,
            string? year, string? type, string? n)
        {
            if(command == null) return Literals.welcome_message;

            Dictionary<string, string> d = new Dictionary<string, string>();

            d.Add("command", command);
            if (sy != null) d.Add("sy", sy);
            if (sm != null) d.Add("sm", sm);
            if (sd != null) d.Add("sd", sd);
            if (ey != null) d.Add("ey", ey);
            if (em != null) d.Add("em", em);
            if (ed != null) d.Add("ed", ed);
            if (year != null) d.Add("year", year);
            if (type != null) d.Add("type", type);
            if (n != null) d.Add("n", n);

            if (!CommandProcessor.ProcessCommand(d))
            {
                ConsoleWrapper.WriteLine("Not all parameters were given");
            }

            StringBuilder b = new StringBuilder();
            foreach (string s in ConsoleWrapper.History) b.Append(s);
            return Literals.welcome_message + "\n" + b.ToString();
        }
    }
}