namespace AutosRA.Backend.Models
{
    using AutosRA.Domain;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    [NotMapped]
    public class VehicleView : Vehicle
    {
        [Display(Name="Image")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
