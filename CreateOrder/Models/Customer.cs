using System;
using Newtonsoft.Json;

namespace OrderManagement.Models
{
    public class Customer
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("customerName")]
        public string Name { get; set; }

    }
}
