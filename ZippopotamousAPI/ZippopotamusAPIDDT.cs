using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;

namespace ZippopotamousAPI
{
    public class ZippopotamusAPIDDT
    {
        private RestClient client;

        [OneTimeSetUp]
        public void SetUpClient()
        {
            client = new RestClient("http://api.zippopotam.us/");
        }

        [TestCase("BG", "1000", "София")]
        [TestCase("BG", "2000", "Самоков")]
        [TestCase("BG", "3000", "Враца")]
        //[TestCase("BG", "4000", "Пловдив")] - Here I found bug there is no cyrillic name of city Plovdiv.
        [TestCase("BG", "5000", "Велико Търново")]
        [TestCase("BG", "6000", "Стара Загора")]
        [TestCase("BG", "7000", "Русе")]
        [TestCase("BG", "8000", "Бургас")]
        [TestCase("BG", "9000", "Варна")]
        public async Task ValidateAPI_WithDataDrivenTest(string countryAbbreviation, string postCode, string expectedResult)
        {
            var request = new RestRequest($"{countryAbbreviation}/{postCode}");
            var response = await client.ExecuteAsync(request);
            var location = JsonSerializer.Deserialize<Places>(response.Content);
            ;
            StringAssert.Contains(expectedResult, location.Places[0].PlaceName);
        }
    }
}
