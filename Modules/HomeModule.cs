using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace HairSalon
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => {
                List<Stylist> AllStylists = Stylist.GetAll();
                return View["index.cshtml", AllStylists];
            };
// for clients
            Get["/clients"] =_=> {
             List<Clients> AllClientss = Clients.GetAll();
             return View["clients.cshtml", AllClientss];
            };

            Get["/clients/new"] =_=> {
               List<Stylist> AllStylists = Stylist.GetAll();
               return View["client_new.cshtml", AllStylists];
           };

           Post["/clients/new"] =_=> {
               Client newClient = new Client(Request.Form["client-name"], Request.Form["stylist-id"]);
               newClient.Save();
               return View["success.cshtml"];
           };

            Get["/clients/edit/{id}"] = parameters => {
               Client SelectedClient = Client.Find(parameters.id);
               return View["clients_edit.cshtml", SelectedClient];
           };

           Patch["/clients/edit/{id}"] = parameters => {
               Client SelectedClient = Client.Find(parameters.id);
               SelectedClient.Update(Request.Form["client-name"]);
               return View["success.cshtml"];
           };

           Get["clients/delete/{id}"] = parameters => {
               Client SelectedClient = Client.Find(parameters.id);
               return View["clients_edit.cshtml", SelectedClient];
           };

           Delete["clients/delete/{id}"] = parameters => {
               Client SelectedClient = Client.Find(parameters.id);
               SelectedClient.Delete();
               return View["success.cshtml"];
           };
