using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Utilities
{
    public class DataAccess : IDataAccess
    {
        private readonly ILogger logger;
        public DataAccess(ILogger logger)
        {
            this.logger = logger;
        }
        public void LoadData()
        {
            Console.WriteLine("Loading Data");
            this.logger.Log("Loading data");
        }

        public void SaveData(string name)
        {
            Console.WriteLine($"Saving {name}");
            this.logger.Log("Saving data");
        }
    }
}
