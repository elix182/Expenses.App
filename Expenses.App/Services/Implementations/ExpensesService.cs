using System.Net.Mime;
using System.Text;
using Expenses.App.Models;
using Expenses.App.Models.Common;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Expenses.App.Services
{
    public class ExpensesService : IExpensesService
	{
        private readonly string _baseUrl;

        public ExpensesService(IConfiguration configuration)
        {
            _baseUrl = configuration["Urls:ExpensesAPI"] ?? "";
        }

        public async Task<ServiceResult> CreateExpense(Expense data)
        {
            try
            {
                using var client = new HttpClient
                {
                    BaseAddress = new Uri(_baseUrl)
                };
                var payload = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, MediaTypeNames.Application.Json);
                var response = await client.PostAsync("/Expenses", payload);
                var payloadString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<ServiceResult>(payloadString);
                    return result;
                }
                else
                {
                    var result = new ServiceResult();
                    result.SetErrorMessage(payloadString);
                    return result;
                }
            }
            catch (Exception ex)
            {
                var response = new ServiceResult();
                response.SetErrorMessage(ex);
                return response;
            }
        }

        public async Task<ServiceResult> DeleteExpense(Guid expenseUid)
        {
            try
            {
                using var client = new HttpClient
                {
                    BaseAddress = new Uri(_baseUrl)
                };
                var response = await client.DeleteAsync($"/Expenses/{expenseUid}");
                var payloadString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<ServiceResult>(payloadString);
                    return result;
                }
                else
                {
                    var result = new ServiceResult();
                    result.SetErrorMessage(payloadString);
                    return result;
                }
            }
            catch (Exception ex)
            {
                var response = new ServiceResult();
                response.SetErrorMessage(ex);
                return response;
            }
        }

        public async Task<ServiceResult<IEnumerable<Expense>>> FindAll()
        {
            try
            {
                using var client = new HttpClient
                {
                    BaseAddress = new Uri(_baseUrl)
                };
                var response = await client.GetAsync("/Expenses");
                var payloadString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<ServiceResult<IEnumerable<Expense>>>(payloadString);
                    return result;
                }
                else
                {
                    var result = new ServiceResult<IEnumerable<Expense>>();
                    result.SetErrorMessage(payloadString);
                    return result;
                }
            }
            catch (Exception ex)
            {
                var response = new ServiceResult<IEnumerable<Expense>>();
                response.SetErrorMessage(ex);
                return response;
            }
        }

        public async Task<ServiceResult> UpdateExpense(Guid expenseUid, Expense data)
        {
            try
            {
                using var client = new HttpClient
                {
                    BaseAddress = new Uri(_baseUrl)
                };
                var payload = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, MediaTypeNames.Application.Json);
                var response = await client.PutAsync($"/Expenses/{expenseUid}", payload);
                var payloadString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<ServiceResult>(payloadString);
                    return result;
                }
                else
                {
                    var result = new ServiceResult();
                    result.SetErrorMessage(payloadString);
                    return result;
                }
            }            
            catch (Exception ex)
            {
                var response = new ServiceResult();
                response.SetErrorMessage(ex);
                return response;
            }
        }
    }
}

