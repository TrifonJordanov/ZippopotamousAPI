using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;


namespace ZippopotamousAPI
{
    public class ZippopotamousAPITests
    {
        private RestClient client;
        private RestRequest request;
        private RestResponse response;
        private Location location;
        [OneTimeSetUp]
        public async Task Setup()
        {
            client = new RestClient("http://api.zippopotam.us/");
            request = new RestRequest("BG/1000");
            response = await client.ExecuteAsync(request);
            location = JsonSerializer.Deserialize<Location>(response.Content);
            ;
        }

        [Test]
        public void ValidateAPI_ReturnCorrectlyCountryAbbreviation()
        {
            var expected = "BG";
            Assert.AreEqual(expected, location.CountryÀbbreviation);
        }

        [Test]
        public void ValidateAPI_ReturnCorrectPostCode()
        {
            var expected = "1000";
            Assert.AreEqual(expected, location.postCode);
        }

        [Test]
        public void ValidateAPI_ReturnCorrectlyCountryName()
        {
            var expected = "Bulgaria";
            Assert.AreEqual(expected, location.country);
        }

        [Test]
        public void ValidateAPI_ReturnCorrectlyCityName()
        {
            var expected = "Ñîôèÿ";
            StringAssert.Contains(expected, location.Places[0].PlaceName);
        }

        [Test]
        public void ValidateAPI_ReturnCorrectlyStateAbbreviation()
        {
            var expected = "SOF";
            Assert.AreEqual(expected, location.Places[0].StateAbbreviation);
        }
    }
}