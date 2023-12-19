namespace Cotrageco.Models
{
    public class Objective
    {
        public int ObjectiveId { get; set; }

        public string Objective_Title { get; set; }
        public string Objective_Description { get; set; }
        // i added a ? to the string to make it nullable, ? makes it nullable
        // update database after making changes to the model
        // this is for us to upload pictures
        public string? Objective_Icon { get; set; }

    }
}