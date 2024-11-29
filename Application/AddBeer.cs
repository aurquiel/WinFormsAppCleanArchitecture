using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBusiness
{
    public class AddBeer 
    {
        private readonly IRepository<Beer> _repository;

        public AddBeer(IRepository<Beer> repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Beer beer)
        {
            if (string.IsNullOrEmpty(beer.Name))
            {
                throw new Exception("El nombre de la cerveza es obligatorio");
            }

            await _repository.AddAsync(beer);
        }
    }
}
