﻿using System.Windows;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peregrin.Common.Extensions
{
    public static class RestSharpExtension
    {
        private static Task<T> SelectAsync<T>(this IRestClient client, IRestRequest request,
            Func<IRestResponse, T> selector)
        {
            var tsc = new TaskCompletionSource<T>();
            var asyncHandler = client.ExecuteAsync(request, r =>
            {
                if (r.ErrorException == null)
                {
                    tsc.SetResult(selector(r));
                }
                else
                {
                    tsc.SetException(r.ErrorException);
                }
            });

            return tsc.Task;
        }

        public static Task<string> GetContentAsync(this IRestClient client, IRestRequest request)
        {
            return client.SelectAsync(request, r => r.Content);            
        }

        public static Task<IRestResponse> GetResponseAsync(this IRestClient client, IRestRequest request)
        {
            return client.SelectAsync(request, r => r);
        }

    }
}
