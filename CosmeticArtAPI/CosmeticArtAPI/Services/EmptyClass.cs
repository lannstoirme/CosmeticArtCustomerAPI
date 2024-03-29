﻿using System;
using CosmeticArtAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CosmeticArtAPI.Services
{
    public class ClientService
    {

        private readonly IMongoCollection<Client> _clients;

        public ClientService(ICosmeticArtDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString)
            var database = client.GetDatabase(settings.DatabaseName);

            _clients = database.GetCollection<Client>(settings.CosmeticArtCollectionName)
        }

        public List<Client> Get() =>
            _clients.Find(Client => true).ToList();

        public Client Get(string id) =>
            _clients.Find<Client>(client => client.Id == id).FirstOrDefault();

        public Client Create(Client client)
        {
            _clients.InsertOne(client);
            return client;
        }

        public void Update(string id, Client clientIn) =>
            _clients.ReplaceOne(client = client.Id == id, clientIn);

        public void Remove(Client clientIn) =>
            _clients.DeleteOne(client = client.Id == clientIn.Id);

        public void Remove(string id) =>
            _clients.DeleteOne(client => client.Id == id);
    }
}
