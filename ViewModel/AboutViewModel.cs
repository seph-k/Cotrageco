using Cotrageco.Models;

namespace Cotrageco.ViewModel
{
    public class AboutViewModel
    {
        public IEnumerable<Cotrageco_Content> cotrageco_Contents { get; set; }
        public IEnumerable<Sectors_Of_Intervention> Sectors_Of_Interventions { get; set; }
        public IEnumerable<Registration> Registrations { get; set; }
        public IEnumerable<OFS> OFSs { get; set; }
        public IEnumerable<Partner> Partners { get; set; }
        public IEnumerable<Banner> Banner { get; set; }
    }
}
