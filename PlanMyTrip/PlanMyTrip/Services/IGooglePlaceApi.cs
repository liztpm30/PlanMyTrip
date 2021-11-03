using Microsoft.AspNetCore.Mvc;
using PlanMyTrip.Models.Places;
using PlanMyTrip.Models.Responses;
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
        Task<ApiResponse<PlaceResponse>> FindPlace([Query] FindPlaceQuery findPlaceQuery, [Query] string key);

        [Get("/details/json")]
        Task<ApiResponse<PlaceDetailResponse>> PlaceDetails([Query] PlaceDetailsQuery findPlaceDetailQuery, [Query] string key);

        [Get("/nearbysearch/json")]
        Task<ApiResponse<PlaceNearbyResponse>> NearbySearch([Query] NearbyPlaceQuery nearbyPlaceQuery, [Query] string key);

        [Get("/textsearch/json")]
        Task<ApiResponse<PlaceTextResponse>> TextSearch([Query] PlaceTextQuery placeTextQuery, [Query] string key);

        [Get("/photo")]
        Task<ApiResponse<HttpContent>> PlacePhoto([Query] PlacePhotoQuery placePhotoQuery, [Query] string key);

        [Get("/autocomplete/json")]
        Task<ApiResponse<PlaceAutocompleteResponse>> AutoComplete([Query] PlaceAutoCompleteQuery placeAutoCompleteQuery, [Query] string key);

        [Get("/queryautocomplete/json")]
        Task<ApiResponse<PlaceAutocompleteResponse>> QueryAutoComplete([Query] AutocompleteQuery autocomplete, [Query] string key);
    }
}
