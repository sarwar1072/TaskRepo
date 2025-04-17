using BlazorApp.Helper;
using BlazorApp.Models;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;

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
      
        public async Task<bool> Login(LoginVM model)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", model);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
                var token = result.token.token; // Nested property

                await _localStorage.SetItemAsync("authToken", token);
                ((JwtAuthStateProvider)_authProvider).NotifyUserAuthentication(token);
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                return true;
            }

            return false;
        }

        public async Task<string?> ChangePassword(ChangePasswordModel model)
        {
            var response = await _http.PostAsJsonAsync("api/auth/change-password", model);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync(); // "Password changed"
            }

            var error = await response.Content.ReadAsStringAsync();
            return $"Failed: {error}";
        }

        public async Task<string?> ForgotPassword(ForgotPasswordModel model)
        {
            var response = await _http.PostAsJsonAsync("api/auth/forgot-password", model);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                return result?["token"]; // In production, you'd email this
            }

            return null;
        }

        public async Task<bool> ResetPassword(ResetPasswordModel model)
        {
            var response = await _http.PostAsJsonAsync("api/auth/reset-password", model);
            return response.IsSuccessStatusCode;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((JwtAuthStateProvider)_authProvider).NotifyUserLogout();
            _http.DefaultRequestHeaders.Authorization = null;
        }

    }
}
