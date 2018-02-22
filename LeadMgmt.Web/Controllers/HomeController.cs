using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LeadMgmt.Web.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using LeadMgmt.Web.Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeadMgmt.Web.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient _apiClient;
        public HomeController()
        {
            _apiClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:7252/api/")
            };
            // Add an Accept header for JSON format.
            _apiClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public IActionResult Index()
        {
            var model = _apiClient.GetAsync("leads").Result.Content.ReadAsStringAsync().Result;
            return View(JsonConvert.DeserializeObject<List<LeadModel>>(model));
        }

        public IActionResult Register(long? id)
        {
            var model = new LeadModel();
            if (id != null)
            {
                var jsonstring = _apiClient.GetAsync("leads?id=" + id).Result.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<LeadModel>>(jsonstring);
                model = list.Count > 0 ? list.FirstOrDefault() : model;
                model.LeadTypeList = GetLeadList();
                return View(model);
            }
            model.LeadTypeList = GetLeadList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Register(LeadModel leadModel)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(leadModel), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage model;
                if (leadModel.ID > 0)
                    model = _apiClient.PutAsync("leads", content).Result; 
                else
                    model = _apiClient.PostAsync("leads", content).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Save", "Error saving lead");
                   
                } 
            }
            leadModel.LeadTypeList = GetLeadList();
            return View(leadModel);
        }

        private List<SelectListItem> GetLeadList()
        {
            var leadlist = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Select",
                    Value = ""
                }
            };
            foreach (LeadType eVal in Enum.GetValues(typeof(LeadType)))
            {
                leadlist.Add(new SelectListItem { Text = Enum.GetName(typeof(LeadType), eVal), Value = eVal.ToString() });
            }
            return leadlist;
        } 
    }
}
