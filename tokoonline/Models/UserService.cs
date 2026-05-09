using Newtonsoft.Json;
using tokoonline.Models;

namespace tokoonline.Services
{
    public static class UserService
    {
        private static string filePath = "users.json";

        public static List<User> GetUsers()
        {
            if (!File.Exists(filePath))
            {
                return new List<User>();
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrEmpty(json))
            {
                return new List<User>();
            }

            return JsonConvert.DeserializeObject<List<User>>(json)
                   ?? new List<User>();
        }

        public static void SaveUsers(List<User> users)
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);

            File.WriteAllText(filePath, json);
        }
    }
}