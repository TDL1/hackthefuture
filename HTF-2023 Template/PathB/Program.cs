using Common;
using Newtonsoft.Json;
using PathB;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Windows;


namespace pathB 
{ 
     public class Program
        {
        private readonly B1 _b1 = new B1();
        private readonly B2 _b2 = new B2(); 
        private readonly B3 _b3 = new B3();
        private HackTheFutureClient _httpClient;
        
        public Program()
        {
            _httpClient = new HackTheFutureClient();
            
           
        }
        static async Task Main(string[] args)
        {
            var program = new Program();

            
            await program._b3.GetAsync();
        }

        




    }

}
