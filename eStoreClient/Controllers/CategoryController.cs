using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using BusinessObject;
using BusinessObject.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace eStoreClient.Controllers
{
    public class CategoryController : Controller
    {
        private readonly HttpClient _client = null;
        private string CategoryApiUrl = "";

        public CategoryController()
        {
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            CategoryApiUrl = "http://localhost:5247/api/category/";
            _client.BaseAddress = new Uri(CategoryApiUrl);
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            var responseMessage = await _client.GetAsync(CategoryApiUrl);
            var strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var categories = JsonSerializer.Deserialize<List<Category>>(strData, options);
            return View(categories);
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var responseMessage = await _client.GetAsync(CategoryApiUrl + id);
            var strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var category = JsonSerializer.Deserialize<Category>(strData, options);

            return View(category);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryDTO model)
        {
            var mapper = MapperConfig.InitAutoMapper();
            var category = new Category();
            try
            {
                if (ModelState.IsValid)
                {
                    var responseMessage = await _client.PostAsJsonAsync("", model);
                    Console.WriteLine(responseMessage.StatusCode);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                category = mapper.Map<Category>(model);

                return View(category);
            }
            catch
            {
                return View(category);
            }
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var responseMessage = await _client.GetAsync(CategoryApiUrl + id);
            var strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var category = JsonSerializer.Deserialize<Category>(strData, options);

            return View(category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryDTO model)
        {
            try
            {
                var responseMessage = await _client.GetAsync(CategoryApiUrl + id);
                var strData = await responseMessage.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var category = JsonSerializer.Deserialize<Category>(strData, options);
                if (category == null)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    responseMessage = await _client.PutAsJsonAsync(id.ToString(), model);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                return View(category);
            }
            catch
            {
                return View(MapperConfig.InitAutoMapper().Map<Category>(model));
            }
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var responseMessage = await _client.GetAsync(CategoryApiUrl + id);
            var strData = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var category = JsonSerializer.Deserialize<Category>(strData, options);

            return View(category);
        }
        
        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var responseMessage = await _client.GetAsync(CategoryApiUrl + id);
                var strData = await responseMessage.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var category = JsonSerializer.Deserialize<Category>(strData, options);
                if (category == null)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    responseMessage = await _client.DeleteAsync(id.ToString());
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                return View(category);
            }
            catch
            {
                return View("Index");
            }
        }
    }
}