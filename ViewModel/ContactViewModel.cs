using Cotrageco.Models;

namespace Cotrageco.ViewModel
{
    public class ContactViewModel
    {
        public IEnumerable<Cotrageco_Content> cotrageco_Contents { get; set; }
        public IEnumerable<Banner> Banner { get; set; }
    }
}
