using PlanMyTrip.Models.Maps;
using PlanMyTrip.Models.Queries;
using PlanMyTrip.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace TestPlanMyTrip
{
    public class GoogleMapsPlaceAPITests
    {

        private readonly string key = "AIzaSyCAYvqmiA05BM7fk1PFSQaD5CUiii8BObA";
        private readonly IGooglePlaceApi _googlePlaceApi = RestService.For<IGooglePlaceApi>(new HttpClient()
        {
            BaseAddress = new Uri("https://maps.googleapis.com/maps/api/place")
        });

        [Theory]
        [InlineData("FAU Museum", 26.36915796164171, -80.1017006043473)]
        public async Task FindPlace(string input, double lat, double lon)
        {
            var placeQuery = new FindPlaceQuery(input);
            placeQuery.SetPoint(new Coordinates { Latitude = lat, Longitude = lon });

            var response = await _googlePlaceApi.FindPlace(placeQuery, key);
            Assert.True(response.IsSuccessStatusCode);
            var placeResponse = response.Content;
            Assert.NotNull(placeResponse);
            Assert.Single(placeResponse.Candidates);
            Assert.Equal(PlacesSearchStatus.OK, placeResponse.Status);
            var place = placeResponse.Candidates.First();
            Assert.Equal("OPERATIONAL", place.BusinessStatus);
            Assert.Equal("FAU University Galleries", place.Name);
            Assert.Equal("777 Glades Rd, Boca Raton, FL 33431, United States", place.FormattedAddress);
            Assert.Equal("ChIJ5Y_ELgQe2YgRIGgSPjCKOOA", place.PlaceID);

        }

        [Theory]
        [InlineData("ChIJ5Y_ELgQe2YgRIGgSPjCKOOA")]
        public async Task FindPlaceDetails(string id)
        {

            var placeQuery = new PlaceDetailsQuery(id);

            var response = await _googlePlaceApi.PlaceDetails(placeQuery, key);
            Assert.True(response.IsSuccessStatusCode);
            var placeResponse = response.Content;
            Assert.NotNull(placeResponse);
            Assert.NotNull(placeResponse.Result);
            Assert.Equal(PlacesSearchStatus.OK, placeResponse.Status);
            var place = placeResponse.Result;
            Assert.Equal("OPERATIONAL", place.BusinessStatus);
            Assert.Equal("FAU University Galleries", place.Name);
            Assert.Equal("777 Glades Rd, Boca Raton, FL 33431, USA", place.FormattedAddress);
            Assert.Equal("ChIJ5Y_ELgQe2YgRIGgSPjCKOOA", place.PlaceID);
            Assert.Equal("(561) 297-2966", place.FormattedPhoneNumber);
            Assert.Equal(26.3688215, place.Geometry.Location.Latitude);
            Assert.Equal(-80.10177170000001, place.Geometry.Location.Longitude);
            Assert.Equal("https://www.fau.edu/artsandletters/galleries/", place.Website);
            Assert.Equal(new List<string> { "Monday: Closed", "Tuesday: 1:00 – 4:00 PM", "Wednesday: 1:00 – 4:00 PM", "Thursday: 1:00 – 4:00 PM", "Friday: 1:00 – 4:00 PM", "Saturday: 1:00 – 5:00 PM", "Sunday: Closed" }, place.OpeningHours.WeekdayText);
            Assert.Equal("76RX9V9X+G7", place.PlusCode.GlobalCode);
        }

        [Theory]
        [InlineData("museum", 26.36915796164171, -80.1017006043473)]
        public async Task NearbySearch(string keyword, double lat, double lng)
        {

            var placeQuery = new NearbyPlaceQuery(keyword, $"{lat},{lng}");

            var response = await _googlePlaceApi.NearbySearch(placeQuery, key);
            Assert.True(response.IsSuccessStatusCode);
            var placeResponse = response.Content;
            Assert.NotNull(placeResponse);
            Assert.NotEmpty(placeResponse.Results);
            Assert.Equal(PlacesSearchStatus.OK, placeResponse.Status);
            var place = placeResponse.Results.First();
            Assert.Equal("OPERATIONAL", place.BusinessStatus);
            Assert.Equal("FAU University Galleries", place.Name);
            Assert.Equal("ChIJ5Y_ELgQe2YgRIGgSPjCKOOA", place.PlaceID);
            Assert.Equal(26.3688215, place.Geometry.Location.Latitude);
            Assert.Equal(-80.10177170000001, place.Geometry.Location.Longitude);
            Assert.Equal("76RX9V9X+G7", place.PlusCode.GlobalCode);
        }

        [Theory]
        [InlineData("museum near FAU")]
        public async Task TextSearch(string keyword)
        {

            var placeQuery = new PlaceTextQuery(keyword);

            var response = await _googlePlaceApi.TextSearch(placeQuery, key);
            Assert.True(response.IsSuccessStatusCode);
            var placeResponse = response.Content;
            Assert.NotNull(placeResponse);
            Assert.NotEmpty(placeResponse.Results);
            Assert.Equal(PlacesSearchStatus.OK, placeResponse.Status);
            var place = placeResponse.Results.First();
            Assert.Equal("OPERATIONAL", place.BusinessStatus);
            Assert.Equal("FAU Fogelman Sports Museum", place.Name);
            Assert.Equal("ChIJBZPRCCkf2YgR6-TriHu1odU", place.PlaceID);
            Assert.Equal(26.3748774, place.Geometry.Location.Latitude);
            Assert.Equal(-80.1028651, place.Geometry.Location.Longitude);
            Assert.Equal("76RX9VFW+XV", place.PlusCode.GlobalCode);
        }

        [Theory]
        [InlineData("Aap_uECOFSsDblIPXSexVQYa75_nK4ImAylLNkSyq632eEb7Q9AsNO_I7DKnHhqsBH8iH_T_bpoyGgPz2spqLGBV7yvP9tmo8GgIcdOUycjxzbZaJ_fvcx2sConT02I81Ux9yPAEQ7z1DjK_0sXlrQbq4l2rBaIkcqiP3dI9mJB9DTMKv-s6")]
        public async Task PlacePhoto(string id)
        {

            var placeQuery = new PlacePhotoQuery(id);

            var response = await _googlePlaceApi.PlacePhoto(placeQuery, key);
            Assert.True(response.IsSuccessStatusCode);
            var placeResponse = response.Content;
            Assert.NotNull(placeResponse);
            var arr = await placeResponse.ReadAsByteArrayAsync();
            Assert.NotEmpty(arr);
        }
    }
}
