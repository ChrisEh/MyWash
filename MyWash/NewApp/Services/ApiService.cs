﻿using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using NewApp.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace NewApp.Services
{
    public class ApiService
    {
        public static async Task<HttpResponseMessage> RegisterUserAsync(string name, string email, string password, string place, string postCode, string phoneNumber, string streetName, string houseNumber)
        {
            var register = new Register()
            {
                Name = name,
                Email = email,
                Password = password,
                Place = place,
                PhoneNumber = phoneNumber,
                StreetName = streetName,
                PostCode = postCode,
                HouseNumber = houseNumber
            };

            var json = JsonConvert.SerializeObject(register);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await AppSettings.GetClient().PostAsync($"{AppSettings.ApiUrl}Users/Register", content);

            return response;
        }

        public static async Task<User> GetCurrentUser(string userId)
        {
            var httpClient = AppSettings.GetClient();
            var response = await httpClient.GetStringAsync($"{AppSettings.ApiUrl}Users/GetUser/{userId}");
            return JsonConvert.DeserializeObject<User>(response);
        }

        public static async Task<bool> UpdateUserDetailsAsync(string id, string streetName, string houseNumber, string postCode, string place, string phoneNumber)
        {
            var httpClient = AppSettings.GetClient();
            var update = new UpdateUserDetails()
            {
                Id = id,
                StreetName = streetName,
                HouseNumber = houseNumber,
                PostCode = postCode,
                Place = place,
                PhoneNumber = phoneNumber
            };

            var json = JsonConvert.SerializeObject(update);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{AppSettings.ApiUrl}Users/UpdateUserDetails", content);
            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> LoginAsync(string email, string password)
        {
            var login = new Login()
            {
                Email = email,
                Password = password
            };

            var httpClient = AppSettings.GetClient();
            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{AppSettings.ApiUrl}Users/Login", content);

            if (!response.IsSuccessStatusCode)
                return false;

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Token>(jsonResult);
            Preferences.Set("accessToken", result.Access_token);
            Preferences.Set("userId", result.User_Id);
            Preferences.Set("userName", result.User_name);
            return true;
        }

        public static async Task<Product> GetProductByIdAsync(int productId)
        {
            var httpClient = AppSettings.GetClient();
            httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync($"{AppSettings.ApiUrl}Products/{productId}");
            return JsonConvert.DeserializeObject<Product>(response);
        }

        public static async Task<List<ProductByCategory>> GetProductByCategoryAsync(int categoryId)
        {
            var httpClient = AppSettings.GetClient();
            httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync($"{AppSettings.ApiUrl}Products/productsbycategory/{categoryId}");
            return JsonConvert.DeserializeObject<List<ProductByCategory>>(response);
        }

        //public static async Task<List<PopularProduct>> GetPopularProductsAsync()
        //{
        //    var httpClient = AppSettings.GetClient();
        //    httpClient.DefaultRequestHeaders.Authorization = 
        //        new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
        //    var response = await httpClient.GetStringAsync($"{AppSettings.ApiUrl}Products/popularproducts/");
        //    return JsonConvert.DeserializeObject<List<PopularProduct>>(response);
        //}

        public static async Task<bool> AddItemsInCartAsync(AddToCart addToCart)
        {
            var httpClient = AppSettings.GetClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var json = JsonConvert.SerializeObject(addToCart);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{AppSettings.ApiUrl}shoppingCartItems", content);

            if (!response.IsSuccessStatusCode)
                return false;
            return true;
        }

        public static async Task<CartSubTotal> GetCartSubTotalAsync(int userId)
        {
            var httpClient = AppSettings.GetClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync($"{AppSettings.ApiUrl}shoppingCartItems/SubTotal/{userId}");
            return JsonConvert.DeserializeObject<CartSubTotal>(response);
        }

        public static async Task<List<ShoppingCartItem>> GetShoppingCartItemsAsync(int userId)
        {
            var httpClient = AppSettings.GetClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync($"{AppSettings.ApiUrl}shoppingCartItems/{userId}");
            return JsonConvert.DeserializeObject<List<ShoppingCartItem>>(response);
        }

        public static async Task<TotalCartItems> GetTotalCartItemsAsync(int userId)
        {
            var httpClient = AppSettings.GetClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync($"{AppSettings.ApiUrl}shoppingCartItems/TotalItems/{userId}");
            return JsonConvert.DeserializeObject<TotalCartItems>(response);
        }

        public static async Task<bool> ClearShoppingCartAsync(int userId)
        {
            var httpClient = AppSettings.GetClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.DeleteAsync($"{AppSettings.ApiUrl}shoppingCartItems/{userId}");
            return response.IsSuccessStatusCode;
        }

        public static async Task<PickupResponse> PlacePickupAsync(Pickup pickup)
        {
            var httpClient = AppSettings.GetClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var json = JsonConvert.SerializeObject(pickup);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{AppSettings.ApiUrl}Pickups", content);
            var jsonResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PickupResponse>(jsonResult);
        }

        public static async Task<List<PickupByUser>> GetPickupsByUserAsync(int userId)
        {
            var httpClient = AppSettings.GetClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync($"{AppSettings.ApiUrl}Pickups/PickupsByUser/{userId}");
            return JsonConvert.DeserializeObject<List<PickupByUser>>(response);
        }

        public static async Task<List<Pickup>> GetPickupDetailsAsync(int pickupId)
        {
            var httpClient = AppSettings.GetClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync($"{AppSettings.ApiUrl}Pickups/PickupDetails" + pickupId);
            return JsonConvert.DeserializeObject<List<Pickup>>(response);
        }
    }
}