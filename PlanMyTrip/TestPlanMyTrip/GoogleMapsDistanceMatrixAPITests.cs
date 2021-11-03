using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using PlanMyTrip.Services;
using PlanMyTrip.Models.Queries;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using PlanMyTrip.Models.Matrices;

namespace TestPlanMyTrip
{
    public class GoogleMapsDistanceMatrixAPITests
    {

        private readonly string key = "AIzaSyCAYvqmiA05BM7fk1PFSQaD5CUiii8BObA";
        private readonly IGoogleDistanceMatrixApi _googleMatrixApi = RestService.For<IGoogleDistanceMatrixApi>(new HttpClient()
        {
            BaseAddress = new Uri("https://maps.googleapis.com/maps/api/distancematrix")
        });

        [Theory]
        [InlineData("place_id:ChIJW4vELgQe2YgRVPx7Bj9_0nI", "place_id:ChIJMRJAKhv17IgR4H_rTH8OxH8")]
        public async Task DistanceMatrix(string origin, string destination)
        {
            var placeQuery = new DistanceMatrixQuery(new List<string> { origin }, new List<string> { destination });

            var response = await _googleMatrixApi.DistanceMatrix(placeQuery, key);
            Assert.True(response.IsSuccessStatusCode);
            var placeResponse = response.Content;
            Assert.NotNull(placeResponse);
            Assert.NotEmpty(placeResponse.DestinationAddresses);
            Assert.Equal("403 Stadium Dr, Tallahassee, FL 32304, USA", placeResponse.DestinationAddresses.First());
            Assert.NotEmpty(placeResponse.OriginAddresses);
            Assert.Equal("777 Glades Rd, Boca Raton, FL 33431, USA", placeResponse.OriginAddresses.First());
            Assert.NotEmpty(placeResponse.Rows);
            var row = placeResponse.Rows.First();
            Assert.NotEmpty(row.Elements);
            var element = row.Elements.First();
            Assert.Equal(DistanceMatrixElementStatus.OK, element.Status);
            Assert.Equal("708 km", element.Distance.Text);
            Assert.Equal(707869, element.Distance.Value);
            Assert.Equal("708 km", element.Distance.Text);
            Assert.Equal("6 hours 32 mins", element.Duration.Text);
            Assert.Equal(23518, element.Duration.Value);
        }
    }
}
