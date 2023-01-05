using DemoLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class BusinessLogic : IBusinessLogic
    {
        ILogger logger;
        IDataAccess dataAccess;
        public BusinessLogic(ILogger logger, IDataAccess dataAccess) // this is called constructor injection which is the way to go for most of the cases.
        {
            this.logger = logger;
            this.dataAccess = dataAccess;
        }
        public void ProcessData()
        {
            

            this.logger.Log("Starting the processing of data.");
            Console.WriteLine("Processing the data");
            this.dataAccess.LoadData();
            this.dataAccess.SaveData("ProcessedInfo");
            this.logger.Log("Finished processing of the data.");
        }
    }
}
