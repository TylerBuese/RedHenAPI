namespace RedHenAPI.Models
{
    public class AccountModel
    {
        public int AccountNumber { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool isParent { get; set; }
        public string CareGiverID { get; set; }
        public string CareGiverStreet { get; set; }
        public string CareGiverCity { get; set; }
        public string CareGiverCounty { get; set; }
        public string CareGiverState { get; set; }
        public int CareGiverNumOfSlotsAvailable { get; set; }
        public string CareGiverEmail { get; set; }
        public string CareGiverPhoneNumber { get; set; }
    }
}
