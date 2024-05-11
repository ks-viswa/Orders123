using System;
using Newtonsoft.Json;

namespace OrderManagement.Models
{
    
    using System;
    using Newtonsoft.Json; 

    public class Order
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("customerId")]
        public int CustomerId { get; set; }

        [JsonProperty("itemName")]
        public string ItemName { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("unitPrice")]
        public decimal UnitPrice { get; set; }

        [JsonProperty("total")]
        public decimal? Total { get; set; }
                
        [JsonProperty("paymentTimestamp")]
        public DateTime? PaymentTimestamp { get; set; }


    }
}
