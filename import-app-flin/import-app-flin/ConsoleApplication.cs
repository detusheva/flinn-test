using import_app_flin.DataContext;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace import_app_flin
{
    class ConsoleApplication
    {
        private readonly IConfiguration _config;
        private readonly flintestContext _context;

        public ConsoleApplication(IConfiguration config, flintestContext context)
        {
            _config = config;
            _context = context;
        }
        public void Run(string path)
        {
            try
            {
                StreamReader r = new StreamReader(path);
                {
                    string json = r.ReadToEnd();
                    List<Product> items = JsonConvert.DeserializeObject<List<Product>>(json);

                    foreach (var item in items)
                    {
                        Product productEntity = new Product
                        {
                            Name = item.Name,
                            ProductId = item.ProductId,
                            Price = item.Price,
                            ProductGroupId = item.ProductGroupId,
                            Currency = item.Currency,
                        };

                        _context.Add(productEntity);
                        _context.SaveChanges();
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(String.Format("Something went wrong: {0}", e.GetType().FullName));

            }
        }
    }
}
