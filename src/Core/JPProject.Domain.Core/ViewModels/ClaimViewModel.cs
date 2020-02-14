namespace JPProject.Domain.Core.ViewModels
{
    public class ClaimViewModel
    {
        public ClaimViewModel() { }
        public ClaimViewModel(in int id, string type, string value)
        {
            Id = id;
            Type = type;
            Value = value;
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
