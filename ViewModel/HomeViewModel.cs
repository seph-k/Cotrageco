using Cotrageco.Models;

namespace Cotrageco.ViewModel
{
    public class HomeViewModel
    {
        //create the items that you would like to display on the home page

        //to display items from content table in the database
        public IEnumerable<Cotrageco_Content> cotrageco_Contents { get; set; }

        //to display items from the objectives table in the database
        public IEnumerable<Objective> Objectives { get; set; }

        //to display items from the corperate info table in the database
        public IEnumerable<Corperate_Info> Corperate_Infos { get; set; }

        //to display items from the projects table in the database
        public IEnumerable<Project> Projects { get; set; }
    }
}
