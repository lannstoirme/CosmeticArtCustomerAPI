using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmeticArtAPI.Services;
using Microsoft.AspNetCore.Mvc;
using CosmeticArtAPI.Models;
using CosmeticArtAPI.Controllers;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CosmeticArtAPI.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("LastName")]
        public string Lastname { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("Mobile")]
        public string Mobile { get; set; }

        [BsonElement("Dob")]
        public string Dob { get; set; }

        [BsonElement("ServiceDate")]
        public string ServiceDate { get; set; }

        [BsonElement("Address")]
        public string Address { get; set; }

        [BsonElement("State")]
        public string State { get; set; }

        [BsonElement("Postcode")]
        public string Postcode { get; set; }

        [BsonElement("Procedure")]
        public string Procedure { get; set; }

        [BsonElement("Notes")]
        public string Notes { get; set; }

        [BsonElement("MedicalNotes")]
        public string MedicalNotes { get; set; }

        [BsonElement("ConsentCompleted")]
        public string ConsentCompleted { get; set; }

        [BsonElement("MarketSubscribe")]
        public string MarketSubscribe { get; set; }
    }
}
