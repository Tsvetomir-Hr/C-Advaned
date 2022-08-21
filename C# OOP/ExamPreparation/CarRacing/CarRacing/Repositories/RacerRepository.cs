using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private readonly List<IRacer> models;
        public IReadOnlyCollection<IRacer> Models => models;
        public RacerRepository()
        {
            models = new List<IRacer>();
        }
        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }
            models.Add(model);
        }

        public IRacer FindBy(string username)
        {
            return models.FirstOrDefault(x => x.Username == username);
        }

        public bool Remove(IRacer model)
        {
            return models.Remove(model);
        }
    }
}
