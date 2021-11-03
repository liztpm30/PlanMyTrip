using Microsoft.AspNetCore.Mvc;
using PlanMyTrip.Models.Queries;
using PlanMyTrip.Models.Responses;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanMyTrip.Services
{
    public interface IGoogleDistanceMatrixApi
    {
        [Get("/json")]
        Task<ApiResponse<DistanceMatrixResponse>> DistanceMatrix([Query(CollectionFormat.Pipes)] DistanceMatrixQuery distanceMatrixQuery, [Query] string key);
    }
}
