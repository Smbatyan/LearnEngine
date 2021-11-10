using LearnEngine.Application.Exceptions;
using LearnEngine.Application.Helpers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LearnEngine.Infrastucture.ClientServices
{
    internal abstract class ClientServiceBase
    {
        private readonly ILogger<ClientServiceBase> _logger;

        private readonly HttpClient _httpClient;
        private readonly HttpExceptionHelper _exceptionHelper;

        protected ClientServiceBase(HttpClient httpClient, ILogger<ClientServiceBase> logger, IOptions<IClientServiceBase> clientServiceBase, HttpExceptionHelper exceptionHelper)
        {
            _httpClient = httpClient;
            BaseAddressUrl = clientServiceBase.Value.BaseAddress;
            ConfigHttpClient();

            _logger = logger;
            _exceptionHelper = exceptionHelper;
        }

        protected string BaseAddressUrl { get; init; }
        
        private void ConfigHttpClient()
        {
            if (string.IsNullOrEmpty(BaseAddressUrl))
            {
                throw new NullReferenceException("Base Address Url is missing.");
            }

           _httpClient.BaseAddress = new Uri(BaseAddressUrl);

           _httpClient.Timeout = TimeSpan.FromSeconds(15);

           _httpClient.DefaultRequestHeaders.Accept.Clear();
           _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //TODO
        }

        protected async Task<TRT> PostAsJsonAsync<T, TRT>(string requestUrl, T content)
        {
            var response = await _httpClient.PostAsJsonAsync(requestUrl, content);
            
            var result = await GetRequestResult<TRT>(response, requestUrl);

            return result;
        }

        protected async Task<TRT> PostAsJsonAsync<TRT>(string requestUrl, object content)
        {
            var response = await _httpClient.PostAsJsonAsync(requestUrl, content);
            
            var result = await GetRequestResult<TRT>(response, requestUrl);

            return result;
        }

        protected async Task<TRT> PutAsJsonAsync<T, TRT>(string requestUrl, T content)
        {
            var response = await _httpClient.PutAsJsonAsync(requestUrl, content);
            
            var result = await GetRequestResult<TRT>(response, requestUrl);

            return result;
        }

        protected async Task<TRT> PutAsJsonAsync<TRT>(string requestUrl, object content)
        {
            var response = await _httpClient.PutAsJsonAsync(requestUrl, content);

            var result = await GetRequestResult<TRT>(response, requestUrl);

            return result;
        }

        protected async Task PutAsJsonAsync(string requestUrl, object content)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(requestUrl, content);
            
            EnsureSuccessStatusCode(response, requestUrl);
        }

        protected async Task<T> GetAsJsonAsync<T>(string requestUrl)
        {
            var response = await _httpClient.GetAsync(requestUrl);
            
            var result = await GetRequestResult<T>(response, requestUrl);

            return result;
        }

        private async Task<T> GetRequestResult<T>(HttpResponseMessage response, string requestUrl)
        {
            T result = default;

            try
            {
                response.EnsureSuccessStatusCode();

                var resp = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<T>(resp);
            }
            catch (Exception ex)
            {
                string message = $"{BaseAddressUrl}{requestUrl} - {response?.Content?.ReadAsStringAsync()?.Result}";
                _exceptionHelper.ThrowException(response.StatusCode, message, ex);
            }

            return result;
        }

        private void EnsureSuccessStatusCode(HttpResponseMessage response, string requestUrl)
        {
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                string message = $"{BaseAddressUrl}{requestUrl} - {response.Content.ReadAsStringAsync().Result}";
                _exceptionHelper.ThrowException(response.StatusCode, message, ex);
            }
        }
    }
}
