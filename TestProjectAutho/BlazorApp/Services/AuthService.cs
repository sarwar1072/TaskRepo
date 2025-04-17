using BlazorApp.Helper;
using BlazorApp.Models;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class AuthService:IAuthService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authProvider;

        public AuthService(HttpClient http, ILocalStorageService localStorage, AuthenticationStateProvider authProvider)
        {
            _http = http;
            _localStorage = localStorage;
            _authProvider = authProvider;
        }

        public async Task<string> Register(RegisterVM model)
        {
            var response = await _http.PostAsJsonAsync("api/Auth/register", model);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Login(LoginVM model)
        {
            var response = await _http.PostAsJsonAsync("api/Auth/login", model);
            var token = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                await _localStorage.SetItemAsync("authToken", token);
                ((JwtAuthStateProvider)_authProvider).NotifyUserAuthentication(token);
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return token;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((JwtAuthStateProvider)_authProvider).NotifyUserLogout();
            _http.DefaultRequestHeaders.Authorization = null;
        }

    }
}
