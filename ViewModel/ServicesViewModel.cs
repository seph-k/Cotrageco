using Cotrageco.Models;

namespace Cotrageco.ViewModel
{
    public class ServicesViewModel
    {
        public IEnumerable<Cotrageco_Content> cotrageco_Contents { get; set; }
        public IEnumerable<Our_Realisation> Our_Realisations { get; set; }
        public IEnumerable<Corperate_Purpose> Corperate_Purposes { get; set; }
    }
}
