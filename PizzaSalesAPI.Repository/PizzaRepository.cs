﻿using PizzaSalesAPI.Domain;
using PizzaSalesAPI.Domain.Models;
using PizzaSalesAPI.Repository.Interfaces;

namespace PizzaSalesAPI.Repository
{
    public class PizzaRepository: GenericRepository<Pizzas>, IPizzaRepository
    {
        public PizzaRepository(PizzaSalesAPIContext dbContext) : base(dbContext)
        {
        }
    }
}
