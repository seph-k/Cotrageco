namespace Cotrageco.Models
{
    public class Our_Realisation
    {
        public int Our_RealisationId { get; set; }

        public int? Realisation_CaptionId { get; set; }
        public virtual Realisation_Caption? Realisation_Captions { get; set; }
        public string? Realisation_Image { get; set; }
    }
}