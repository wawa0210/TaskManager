using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace CommonLib
{
    /// <summary>
    /// 利用Flurl进行http请求
    /// </summary>
    public static class FlurlHttpRequestHelper
    {
        #region Get

        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="requestEntity"></param>
        /// <returns></returns>
        public static async Task<ResponseEntity> DoGetAsync(this string requestUrl, RequestEntity requestEntity)
        {
            var result = new ResponseEntity { RequestEntity = requestEntity };
            if (string.IsNullOrEmpty(requestUrl)) throw new ArgumentNullException("requestUrl");
            result.RequestBeginTime = DateTime.Now;

            await requestUrl
               .SetQueryParams(requestEntity.RequestQueryParams)
               .ConfigureRequest(x =>
                {
                    x.AfterCallAsync = async call =>
                    {
                        if (call.HttpStatus != null) result.StatusCode = (HttpStatusCode)call.HttpStatus;
                        result.IsSucceed = call.Succeeded;
                        result.Exception = call.Exception;
                        result.RequestBody = await call.Response.Content.ReadAsStringAsync();
                        result.RequestEndTime = DateTime.Now;
                    };
                    x.OnError = callBack => callBack.ExceptionHandled = true;
                })
               .GetStringAsync();

            return result;
        }
        #endregion


        #region Post

        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="requestEntity"></param>
        /// <returns></returns>
        public static async Task<ResponseEntity> DoPostAsync(this string requestUrl, RequestEntity requestEntity)
        {
            var result = new ResponseEntity { RequestEntity = requestEntity };
            if (string.IsNullOrEmpty(requestUrl)) throw new ArgumentNullException("requestUrl");
            result.RequestBeginTime = DateTime.Now;
            await requestUrl
               .SetQueryParams(requestEntity.RequestQueryParams)
               .ConfigureRequest(x =>
               {
                   x.AfterCallAsync = async call =>
                   {
                       if (call.HttpStatus != null) result.StatusCode = (HttpStatusCode)call.HttpStatus;
                       result.IsSucceed = call.Succeeded;
                       result.Exception = call.Exception;
                       result.RequestBody = await call.Response.Content.ReadAsStringAsync();
                       result.RequestEndTime = DateTime.Now;
                   };
                   x.OnError = callBack => callBack.ExceptionHandled = true;
               })
               .PostJsonAsync(requestEntity.RequestBody);

            return result;
        }
        #endregion
    }

    /// <summary>
    /// 请求信息
    /// </summary>
    public class RequestEntity
    {
        /// <summary>
        /// 请求地址
        /// </summary>
        public string RequestUrl { get; set; }

        /// <summary>
        /// 请求头
        /// </summary>

        public object RequestHeaders { get; set; }

        /// <summary>
        /// query string 参数
        /// </summary>

        public object RequestQueryParams { get; set; }

        /// <summary>
        /// 请求body
        /// </summary>
        public object RequestBody { get; set; }
    }

    /// <summary>
    /// http响应信息
    /// </summary>
    public class ResponseEntity
    {
        public RequestEntity RequestEntity { get; set; }

        public DateTime RequestBeginTime { get; set; }

        public DateTime RequestEndTime { get; set; }

        public string RequestBody { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// 请求异常信息
        /// </summary>
        public Exception Exception { get; set; }

        public bool IsSucceed { get; set; }
    }
}
