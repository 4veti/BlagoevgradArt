namespace BlagoevgradArt.Core.Models.Exhibition
{
    public class ExhibitionAllModel
    {
        public int CountPerPage { get; } = 4;

        public int CurrentPage { get; set; } = 1;

        public ExhibitionAllServiceModel Exhibitions { get; set; } = null!;
    }
}
