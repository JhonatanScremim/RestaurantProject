using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using ProjectRestaurant.Domains.Entities;
using ProjectRestaurant.Domains.Enums;
using System;
using ProjectRestaurant.Data.Schemas;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRestaurant.Data
{
    public class MongoDB
    {
        public IMongoDatabase database { get; }
        public MongoDB(IConfiguration configuration)
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration["ConnectionString"]));
                var client = new MongoClient(settings);
                database = client.GetDatabase(configuration["DataBase"]);
                MapClasses();
            }
            catch(Exception e)
            {
                throw new MongoException("Não foi possivel se conectar ao banco", e);
            }
        }

        private void MapClasses()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(RestaurantSchema)))
            {
                BsonClassMap.RegisterClassMap<RestaurantSchema>(i =>
                {
                    i.AutoMap();
                    i.MapIdMember(x => x.RestaurantId);
                    i.MapMember(x => x.Kitchen).SetSerializer(new EnumSerializer<Kitchen>(BsonType.Int32));
                    i.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}
