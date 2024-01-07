using ConfigurationReader;
using ConfigurationUI;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Configuration.Integration.Test
{
    public class ConfigurationIntegrationTest: IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        public ConfigurationIntegrationTest(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public void ConfigurationReader_Connection_Control_Succedded()
        {
            //arrange
            var applicationName = "test-app";
            var connectionString = "Data Source=FTS\\SQLEXPRESS;Initial Catalog=BeymenCodeCaseDB;Integrated Security=True";
            long refreshTimerIntervalInMs = 10000;

            //act
            ConfigReader reader = new ConfigReader(applicationName, connectionString, refreshTimerIntervalInMs);

            var test = reader.GetValue<bool>("boolean-name");//true
            var test1 = reader.GetValue<string>("string-name");//test-name
            var test3 = reader.GetValue<int>("integer-name"); //2

            //assert
            Assert.NotNull(reader);
            Assert.True(test);
            Assert.Equal("test-name", test1);
            Assert.Equal(2, test3);
        }

        [Fact]
        public async Task ConfigurationUI_AddConfiguration_Fire()
        {
            //arrange
            var data = new ConfigurationReader.Data.Configuration()
            {
                Name = "test-name",
                ApplicationName = "test-app",
                IsActive = 1,
                Type = "Integer",
                Value = "22"
            };
            string json = JsonConvert.SerializeObject(data);   
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            
            //act
            var response = await _httpClient.PostAsync("/Home/AddConfiguration", httpContent);

            //assert
            response.EnsureSuccessStatusCode();
            var succedded = await response.Content.ReadFromJsonAsync<ConfigurationReader.Data.Configuration>();
            Assert.NotNull(succedded);
            Assert.Equal("test-name", succedded.Name);
        }
    }
}
