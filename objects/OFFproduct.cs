// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using System.Text.Json;


namespace ProductFetcher{

    public class OFFproduct
    {
        public string code { get; set; }
        public Nutriments nutriments { get; set; }
        public string product_name { get; set; }
    }
    public class Nutriments
    {
        public double carbohydrates { get; set; }
        public double carbohydrates_100g { get; set; }
        public string carbohydrates_unit { get; set; }
        public double carbohydrates_value { get; set; }
        public double energy { get; set; }

        
        public double energykcal { get; set; }

        
        public double energykcal_100g { get; set; }

        
        public string energykcal_unit { get; set; }

        
        public double energykcal_value { get; set; }

        
        public double energykcal_value_computed { get; set; }
        public double energy_100g { get; set; }
        public string energy_unit { get; set; }
        public double energy_value { get; set; }
        public double fat { get; set; }
        public double fat_100g { get; set; }
        public string fat_unit { get; set; }
        public double fat_value { get; set; }
        public double fiber { get; set; }
        public double fiber_100g { get; set; }
        public string fiber_unit { get; set; }
        public double fiber_value { get; set; }

        
        public double nutritionscorefr { get; set; }

        
        public double nutritionscorefr_100g { get; set; }
        public double proteins { get; set; }
        public double proteins_100g { get; set; }
        public string proteins_unit { get; set; }
        public double proteins_value { get; set; }
        public double salt { get; set; }
        public double salt_100g { get; set; }
        public string salt_unit { get; set; }
        public double salt_value { get; set; }

        
        public double saturatedfat { get; set; }

        
        public double saturatedfat_100g { get; set; }

        
        public string saturatedfat_unit { get; set; }

        
        public double saturatedfat_value { get; set; }
        public double sodium { get; set; }
        public double sodium_100g { get; set; }
        public string sodium_unit { get; set; }
        public double sodium_value { get; set; }
        public double sugars { get; set; }
        public double sugars_100g { get; set; }
        public string sugars_unit { get; set; }
        public double sugars_value { get; set; }
    }

    
}
    