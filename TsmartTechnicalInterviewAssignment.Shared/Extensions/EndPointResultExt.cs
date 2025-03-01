﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TsmartTechnicalInterviewAssignment.Shared.Extensions
{
    public static class EndPointResultExt
    {
        public static IResult ToGenericResult<T>(this ServiceResult<T> result)
        {
            return result.Status switch
            {
                HttpStatusCode.OK => Results.Ok(result.Data),
                HttpStatusCode.Created => Results.Created(result.UrlAsCreated, result.Data),
                HttpStatusCode.NotFound => Results.NotFound(result.Fail!),
                HttpStatusCode.Unauthorized=> Results.Unauthorized(),
                _ => Results.Problem(result.Fail!),

            };
        }
        public static IResult ToGenericResult(this ServiceResult result)
        {
            return result.Status switch
            {

                HttpStatusCode.NoContent => Results.NoContent(),
                HttpStatusCode.NotFound => Results.NotFound(result.Fail!),
                HttpStatusCode.Unauthorized => Results.Unauthorized(),
                _ => Results.Problem(result.Fail!),

            };
        }
    }
}
