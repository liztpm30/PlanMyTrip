using Microsoft.AspNetCore.Mvc;
using PlanMyTrip.Models.Maps;
using PlanMyTrip.Models.Queries;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlanMyTrip.Services
{
    public interface IGooglePlaceApi
    {
        [Get("/findplacefromtext/json")]
        Task<ApiResponse<PlaceResponse>> FindPlace([FromQuery] FindPlaceQuery findPlaceQuery, [FromQuery] string key);

        [Get("/details/json")]
        Task<ApiResponse<PlaceDetailResponse>> PlaceDetails([FromQuery] PlaceDetailsQuery findPlaceDetailQuery, [FromQuery] string key);

        [Get("/nearbysearch/json")]
        Task<ApiResponse<PlaceNearbyResponse>> NearbySearch([FromQuery] NearbyPlaceQuery nearbyPlaceQuery, [FromQuery] string key);

        [Get("/textsearch/json")]
        Task<ApiResponse<PlaceTextResponse>> TextSearch([FromQuery] PlaceTextQuery placeTextQuery, [FromQuery] string key);

        [Get("/photo")]
        Task<ApiResponse<HttpContent>> PlacePhoto([FromQuery] PlacePhotoQuery placePhotoQuery, [FromQuery] string key);
    }
}
