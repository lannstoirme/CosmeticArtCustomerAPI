using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmeticArtAPI.Models;
using CosmeticArtAPI.Controllers;
using CosmeticArtAPI.Services;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CosmeticArtAPI.Models
{
    public class CosmeticArtDatabaseSettings : ICosmeticArtDatabaseSettings

    {
        public string CosmeticArtCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICosmeticArtDatabaseSettings
    {
        string CosmeticArtCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }


}