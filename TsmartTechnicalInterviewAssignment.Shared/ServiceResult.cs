﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Refit;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;
using MediatR;


namespace TsmartTechnicalInterviewAssignment.Shared
{
    public interface IRequestByServiceResult<T> : IRequest<ServiceResult<T>>;
    public interface IRequestByServiceResult : IRequest<ServiceResult>;
    public class ServiceResult
    {
        [JsonIgnore]
        public HttpStatusCode Status { get; set; }
        public ProblemDetails? Fail { get; set; }
        [JsonIgnore]
        public bool IsSuccess => Fail is null;
        [JsonIgnore]
        public bool IsFail => !IsSuccess;

       
        public static ServiceResult SuccessAsNoContent()
        {
            return new ServiceResult
            {
                Status = HttpStatusCode.NoContent
            };
        }
        public static ServiceResult ErrorNotFound()
        {
            return new ServiceResult
            {
                Status = HttpStatusCode.NotFound,
                Fail = new ProblemDetails
                {
                    Title = "Bulunamadı",
                    Detail = "İstenen kaynak bulunamadı"
                }


            };
        }
        public static ServiceResult Unauthorized()
        {
            return new ServiceResult
            {
                Status = HttpStatusCode.Unauthorized,
                Fail = new ProblemDetails
                {
                    Title = "Giriş Yapılamadı",
                    Detail = "Lütfen bilgilerinizi kontrol ediniz"
                }


            };
        }
        public static ServiceResult ErrorFromProblemDetails(ApiException exception)
        {
            if (string.IsNullOrEmpty(exception.Content))
            {
                return new ServiceResult
                {
                    Fail = new ProblemDetails()
                    {
                        Title = exception.Message,

                    },
                    Status = exception.StatusCode

                };
            }
            var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(exception.Content, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return new ServiceResult()
            {
                Fail = problemDetails,
                Status = exception.StatusCode
            };
        }

        public static ServiceResult Error(ProblemDetails problemDetails, HttpStatusCode status)
        {
            return new ServiceResult()
            {
                Status = status,
                Fail = problemDetails
            };

        }
        public static ServiceResult Error(string title, string description, HttpStatusCode status)
        {

            return new ServiceResult()
            {
                Status = status,
                Fail = new ProblemDetails()
                {
                    Title = title,
                    Detail = description,
                    Status = status.GetHashCode()
                }
            };

        }

        public static ServiceResult ErrorFromValidation(IDictionary<string, object?> errors)
        {

            return new ServiceResult()
            {
                Status = HttpStatusCode.BadRequest,
                Fail = new ProblemDetails()
                {
                    Title = "Doğrulama hataları oluştu",
                    Detail = "Lütfen kontrol edin",
                    Extensions = errors,
                    Status = HttpStatusCode.BadRequest.GetHashCode()
                }
            };

        }

        public static ServiceResult Error(string title, HttpStatusCode status)
        {

            return new ServiceResult()
            {
                Status = status,
                Fail = new ProblemDetails()
                {
                    Title = title,

                    Status = status.GetHashCode()
                }
            };

        }

    }

    public class ServiceResult<T> : ServiceResult, IRequest
    {
        public T? Data { get; set; }
        [JsonIgnore] public string? UrlAsCreated { get; set; }

        public static ServiceResult<T> SuccessAsOk(T data)
        {
            return new ServiceResult<T>
            {
                Status = HttpStatusCode.OK,
                Data = data


            };
        }

       
        public static ServiceResult<T> SuccessAsCreated(T data, string url)
        {
            return new ServiceResult<T>
            {
                Status = HttpStatusCode.Created,
                Data = data,
                UrlAsCreated = url

            };
        }
        public new static ServiceResult<T> Unauthorized()
        {
            return new ServiceResult<T>
            {
                Status = HttpStatusCode.Unauthorized,
                Fail = new ProblemDetails
                {
                    Title = "Giriş Yapılamadı",
                    Detail = "Lütfen bilgilerinizi kontrol ediniz"
                }


            };
        }

        public new static ServiceResult<T> ErrorFromProblemDetails(ApiException exception)
        {
            if (string.IsNullOrEmpty(exception.Content))
            {
                return new ServiceResult<T>
                {
                    Fail = new ProblemDetails()
                    {
                        Title = exception.Message,

                    },
                    Status = exception.StatusCode

                };
            }
            var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(exception.Content, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            return new ServiceResult<T>()
            {
                Fail = problemDetails,
                Status = exception.StatusCode
            };
        }

        public new static ServiceResult<T> Error(ProblemDetails problemDetails, HttpStatusCode status)
        {
            return new ServiceResult<T>()
            {
                Status = status,
                Fail = problemDetails
            };

        }
        public new static ServiceResult<T> Error(string title, string description, HttpStatusCode status)
        {

            return new ServiceResult<T>()
            {
                Status = status,
                Fail = new ProblemDetails()
                {
                    Title = title,
                    Detail = description,
                    Status = status.GetHashCode()
                }
            };

        }

        public new static ServiceResult<T> ErrorFromValidation(IDictionary<string, object?> errors)
        {

            return new ServiceResult<T>()
            {
                Status = HttpStatusCode.BadRequest,
                Fail = new ProblemDetails()
                {
                    Title = "Doğrulama hataları oluştu",
                    Detail = "Lütfen kontrol edin",
                    Extensions = errors,
                    Status = HttpStatusCode.BadRequest.GetHashCode()
                }
            };

        }

        public new static ServiceResult<T> Error(string title, HttpStatusCode status)
        {

            return new ServiceResult<T>()
            {
                Status = status,
                Fail = new ProblemDetails()
                {
                    Title = title,

                    Status = status.GetHashCode()
                }
            };

        }
    }
}
