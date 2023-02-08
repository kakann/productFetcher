using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;





namespace ProductFetcher
{
    class Program{
    static HttpClient client = new HttpClient();

    public static int getEditDistance(string X, string Y)
    {
        int m = X.Length;
        int n = Y.Length;
 
        int[][] T = new int[m + 1][];
        for (int i = 0; i < m + 1; ++i) {
            T[i] = new int[n + 1];
        }
 
        for (int i = 1; i <= m; i++) {
            T[i][0] = i;
        }
        for (int j = 1; j <= n; j++) {
            T[0][j] = j;
        }
 
        int cost;
        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) {
                cost = X[i - 1] == Y[j - 1] ? 0: 1;
                T[i][j] = Math.Min(Math.Min(T[i - 1][j] + 1, T[i][j - 1] + 1),
                        T[i - 1][j - 1] + cost);
            }
        }
 
        return T[m][n];
    }
 
    public static double findSimilarity(string x, string y) {
        if (x == null || y == null) {
            throw new ArgumentException($"Strings must not be null: str1 {x}, str2 {y}");
        }
 
        double maxLength = Math.Max(x.Length, y.Length);
        if (maxLength > 0) {
            // optionally ignore case if needed
            return (maxLength - getEditDistance(x, y)) / maxLength;
        }
        return 1.0;
    }
    

    static async Task<OFFproduct> GetProductAsync(String brand, String name){
        String path = $"https://world.openfoodfacts.org/api/v2/search?categories_tags_en=&brands_tags_en={brand}&fields=code,product_name,nutriments&page={1}";
        List<OFFproduct> products = new List<OFFproduct>();
        HttpResponseMessage response = await client.GetAsync(path);
        //String body = await response.Content.ReadAsStringAsync();
        //Console.WriteLine(body);
        OFFresult result = null;
        
        
        
        if(response.IsSuccessStatusCode){
            result = await response.Content.ReadAsAsync<OFFresult>();
            int index = 2;
            int total_products = result.page_count;
            
            while(result.count > total_products){
                
                path = $"https://world.openfoodfacts.org/api/v2/search?categories_tags_en=&brands_tags_en={brand}&fields=code,product_name,nutriments&page={index}";
                response = await client.GetAsync(path);
                OFFresult pagei = await response.Content.ReadAsAsync<OFFresult>();
                index++;
                total_products += pagei.page_count;

                result.products.AddRange(pagei.products);
            }
        }
        
        Console.WriteLine(result.products.Count);


        return pickProduct(name, result.products);


        
    }

    static String cleanStr(String name, List<String> stopwords){
        foreach(String word in stopwords){
            name = name.ToLower().Replace(word.ToLower(), "");
        }
        return name;
    }

    

    static OFFproduct pickProduct(String name, List<OFFproduct> products){
        double similarity = -1;
        OFFproduct result = null;
        List<String> stopwords = new List<string>();
        stopwords.Add("Proteinbar");
        stopwords.Add("12-pack");
        stopwords.Add("Protein bar");
        foreach(OFFproduct product in products){
            if(product.product_name == null) product.product_name = "";
            double prod_sim = findSimilarity(product.product_name, cleanStr(name, stopwords));
            if(prod_sim > similarity){
                similarity = prod_sim;
                result = product;
            }
        }
        return result;
    }

    static async Task searchTestAsync(String brand, String name){
        
        OFFproduct final = await GetProductAsync(brand, name);
        Console.WriteLine($"Serach name: {name}");
        Console.WriteLine($"Result name: {final.product_name}");
    }
    static async Task Main(string[] args){
        
        String name= "Proteinbar Double Bite Peanut";
        String brand = "barebells";
        await searchTestAsync(brand, name);
        
    }
}
    
}



