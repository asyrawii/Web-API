using Newtonsoft.Json;
using Web_API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Services
{
    public static class JsonFileServices
    {
        private static StreamReader srArray;

        public static void SaveJsonFile<T>(List<T> inputList, string filename) where T : new()
        {
            string listOutput = JsonConvert.SerializeObject(inputList, Formatting.Indented);


            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            File.WriteAllText(filename, listOutput);
        }

        //public static void SaveJsonFile(List<User> userList)
        //{
        //    string listOutput = JsonConvert.SerializeObject(userList, Formatting.Indented);

        //    if (File.Exists("UserList.json"))
        //    {
        //        File.Delete("UserList.json");
        //    }

        //    File.WriteAllText("UserList.json", listOutput);
        //}

        public static List<T> LoadJsonFile<T>(string jsonFilename) where T : new()
        {
            try
            {
                srArray = new StreamReader(jsonFilename);
                string outputFromFile = srArray.ReadToEnd();

                List<T> classArray = JsonConvert.DeserializeObject<List<T>>(outputFromFile);

                srArray.Close();

                return classArray;
            }
            catch (Exception)
            {
                return null;
                //throw;
            }
        }

        //public static List<User> LoadJsonFile(string jsonFilename)
        //{
        //    try
        //    {
        //        srArray = new StreamReader(jsonFilename);
        //        string outputFromFile = srArray.ReadToEnd();

        //        List<User> usrArray = JsonConvert.DeserializeObject<List<User>>(outputFromFile);

        //        srArray.Close();

        //        return usrArray;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //        //throw;
        //    }
        //}
    }
}