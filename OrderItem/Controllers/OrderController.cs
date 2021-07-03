using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderItem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;

namespace OrderItem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public Cart Post(int menuItemId)
        {
            int id = 1, userId = 1;
            string menuItemName = null;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                response = client.GetAsync("https://localhost:44363/api/MenuItem/" + menuItemId).Result;
                var data = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);
                menuItemName = data;
                Cart cartObj = new Cart()
                {
                    Id = id,
                    userId = userId,
                    menuItemId = menuItemId,
                    menuItemName = menuItemName
                };
                // string content = JsonSerializer.Serialize(cartObj,Encoding.UTF8); ;
                return cartObj;

            }

        }
    }
}
