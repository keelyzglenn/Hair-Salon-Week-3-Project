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

            // for stylist
            Get["/stylists/new"] =_=> {
                return View["stylist_new.cshtml"];
            };

            Post["/stylists/new"] =_=> {
                Stylist newStylist = new Stylist(Request.Form["stylist-name"], Request.Form["stylist-shift"], Request.Form["stylist-specialty"]);
                newStylist.Save();
                return View["success.cshtml"];
            };
            Get["/stylists/{id}"] = parameters => {
                Dictionary<string, object> model = new Dictionary<string, object>{};
                var SelectedStylist = Stylist.Find(parameters.id);
                var StylistClients = SelectedStylist.GetClients();
                model.Add("stylist", SelectedStylist);
                model.Add("clients", StylistClients);
                return View["stylist.cshtml", model];
            };

            Get["/stylist/edit/{id}"] = parameters => {
                Stylist SelectedStylist = Stylist.Find(parameters.id);
                return View["stylist_edit.cshtml", SelectedStylist];
            };

            Patch["/stylist/edit/{id}"] = parameters => {
                Stylist SelectedStylist = Stylist.Find(parameters.id);
                SelectedStylist.Update(Request.Form["stylist-name"]);
                return View["success.cshtml"];
            };

            Get["stylist/delete/{id}"] = parameters => {
                Stylist SelectedStylist = Stylist.Find(parameters.id);
                return View["stylist_edit.cshtml", SelectedStylist];
            };

            Delete["stylist/delete/{id}"] = parameters => {
                Stylist SelectedStylist = Stylist.Find(parameters.id);
                SelectedStylist.Delete();
                return View["success.cshtml"];
            };

            // for clients
            Get["/clients"] =_=> {
                List<Client> AllClients = Client.GetAll();
                return View["clients.cshtml", AllClients];
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

            Get["/clients/{id}"] = parameters => {
                Client SelectedClient = Client.Find(parameters.id);
                return View["client.cshtml", SelectedClient];
            };

            Get["/client/edit/{id}"] = parameters => {
                Client SelectedClient = Client.Find(parameters.id);
                return View["client_edit.cshtml", SelectedClient];
            };

            Patch["/client/edit/{id}"] = parameters => {
                Client SelectedClient = Client.Find(parameters.id);
                SelectedClient.Update(Request.Form["client-name"]);
                return View["success.cshtml"];
            };

            Get["client/delete/{id}"] = parameters => {
                Client SelectedClient = Client.Find(parameters.id);
                return View["client_edit.cshtml", SelectedClient];
            };

            Delete["client/delete/{id}"] = parameters => {
                Client SelectedClient = Client.Find(parameters.id);
                SelectedClient.Delete();
                return View["success.cshtml"];
            };
        }
    }
}
