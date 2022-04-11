
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Models;

namespace Web_API.Services
{
    public class InventoryServices
    {
        /*
        private static StreamReader srArray;
        public static List<T> LoadJsonFile<T>(string jsonFilename) where T : new()
        {
            try
            {
                srArray = new StreamReader(jsonFilename);
                string outputFromFile = srArray.ReadToEnd();

                List<T> classArray = JsonConvert.DeserializeObject<List<T>>(outputFromFile);

                srArray.Close();
                float TotalProfit = 0;
                for (int i = 0; i< classArray.Count; i++)
                {
                   TotalProfit = TotalProfit + float.Parse(outputFromFile);
                }
                srArray.Close();
                return classArray;

            }
            catch (Exception)
            {
                return null;
                //throw;
            }
        }*/
        static float TotalProfit;
        static float value;

        public static string ProfitCalculator(List<Inventory> inventory)
        {
            int x = inventory.Count;


            TotalProfit = 0;
            for (int i = 0; i < inventory.Count; i++)
            {
                Inventory profit = inventory[i];
                value = profit.Profit;
                TotalProfit += value;
            }
            return TotalProfit.ToString();
        }
    }
}
