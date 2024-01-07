using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VCardGenerator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("How many vCards should be created?");
            string input = Console.ReadLine();
            int count;

            if (!int.TryParse(input, out count))
            {
                Console.WriteLine("Please enter a valid number.");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                try
                {
                    VCard card = await FetchRandomUser();
                    string vCardString = ToVCardFormat(card);
                    SaveVCardToFile(vCardString, card);
                    Console.WriteLine($"{card.Firstname} {card.Surname} vCard was created for .");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Something went wrong: {ex.Message}");
                }
            }
        }

        static async Task<VCard> FetchRandomUser()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://randomuser.me/api/");
                string content = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(content);
                return new VCard
                {
                    Firstname = result.results[0].name.first,
                    Surname = result.results[0].name.last,
                    Email = result.results[0].email,
                    Phone = result.results[0].phone,
                    Country = result.results[0].location.country,
                    City = result.results[0].location.city
                };
            }
        }

        static string ToVCardFormat(VCard card)
        {
            var builder = new StringBuilder();
            builder.AppendLine("BEGIN:VCARD");
            builder.AppendLine("VERSION:3.0");
            builder.AppendLine($"N:{card.Surname};{card.Firstname};");
            builder.AppendLine($"FN:{card.Firstname} {card.Surname}");
            builder.AppendLine($"EMAIL:{card.Email}");
            builder.AppendLine($"TEL:{card.Phone}");
            builder.AppendLine($"ADR:;{card.City};{card.Country};");
            builder.AppendLine("END:VCARD");
            return builder.ToString();
        }

        static void SaveVCardToFile(string vCardString, VCard card)
        {
            string directory = Path.Combine(Environment.CurrentDirectory, "vCards");
            Directory.CreateDirectory(directory); 

            string fileName = $"{card.Firstname}_{card.Surname}_{Guid.NewGuid()}.vcf";
            string filePath = Path.Combine(directory, fileName);
            File.WriteAllText(filePath, vCardString);
        }
    }

    public class VCard
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
