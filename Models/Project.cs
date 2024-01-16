namespace Cotrageco.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public int? Project_TitleId { get; set; }
        public virtual Project_Title? Project_Title { get; set; } 
        public string? Project_Image { get; set; }
    }
}