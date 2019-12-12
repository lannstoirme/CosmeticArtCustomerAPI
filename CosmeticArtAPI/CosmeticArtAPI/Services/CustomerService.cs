using System;
using CosmeticArtAPI.Models;
using CosmeticArtAPI.Controllers;
using CosmeticArtAPI.Services;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace CosmeticArtAPI.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerService(ICosmeticArtDatabaseSettings settings)
        {
            var customers = new MongoClient(settings.ConnectionString);
            var database = customers.GetDatabase(settings.DatabaseName);

            _customers = database.GetCollection<Customer>(settings.CosmeticArtCollectionName);
        }

        public List<Customer> Get() =>
            _customers.Find(book => true).ToList();

        public Customer Get(string id) =>
            _customers.Find<Customer>(customer => customer.Id == id).FirstOrDefault();

        public Customer Create(Customer customer)
        {
            _customers.InsertOne(customer);
            return customer;
        }

        public void Update(string id, Customer customerIn) =>
            _customers.ReplaceOne(book => book.Id == id, customerIn);

        public void Remove(Customer customerIn) =>
            _customers.DeleteOne(customer => customer.Id == customerIn.Id);

        public void Remove(string id) =>
            _customers.DeleteOne(customer => customer.Id == id);
    }
}
