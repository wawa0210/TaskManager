using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace CommonLib
{
    /// <summary>
    /// 利用Flurl进行http请求
    /// </summary>
    public static class FlurlHttpRequestHelper
    {
        #region Get
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="requestUrl"></param>
        /// <param name="queryParam">请求参数</param>
        /// <returns></returns>
        public static async Task<T> DoGetAsync<T>(this string requestUrl, object queryParam)
        {
            if (string.IsNullOrEmpty(requestUrl)) throw new ArgumentNullException("requestUrl");

            return await requestUrl
                .SetQueryParams(queryParam)
                .GetJsonAsync<T>();
        }

        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="queryParam">querystring参数</param>
        /// <returns></returns>
        public static async Task<string> DoGetAsync(this string requestUrl, object queryParam)
        {
            if (string.IsNullOrEmpty(requestUrl)) throw new ArgumentNullException("requestUrl");
            return await requestUrl
                .SetQueryParams(queryParam)
                .GetStringAsync();
        }
        #endregion


        #region Post
        #endregion
    }

    public class RequestEntity
    {
        public string RequestUrl { get; set; }

        public object requestHeaders { get; set; }
    }
}
