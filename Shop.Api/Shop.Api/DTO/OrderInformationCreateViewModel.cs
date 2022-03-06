namespace Shop.Api.DTO
{
    public class OrderInformationCreateViewModel
    {
        public string Address { get; set; }
        public string CardNumber { get; set; }

        public bool IsValid => !string.IsNullOrEmpty(Address)
            && !string.IsNullOrEmpty(CardNumber)
            && CardNumber.Length == 16;
    }
}
