using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class Chore : IChore
    {
        ILogger logger;
        IMessageSender messageSender;

        public string ChoreName { get; set; }
        public IPerson Owner { get; set; }
        public double HoursWorked { get; private set; }
        public bool IsComplete { get; private set; }

        public Chore(ILogger logger, IMessageSender messageSender)
        {
            this.logger = logger;
            this.messageSender = messageSender;
        }

        public void PerformedWork(double hours)
        {
            HoursWorked += hours;
            this.logger.Log($"Performed work on {ChoreName}");
        }

        public void CompleteChore()
        {
            IsComplete = true;

            this.logger.Log($"Completed {ChoreName}");

            this.messageSender.SendMessage(Owner, $"The chore {ChoreName} is complete.");
        }
    }
}
