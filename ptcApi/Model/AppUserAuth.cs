namespace ptcApi.Model {
    public class AppUserAuth {
        public AppUserAuth () {
            UserName = "Not Authorized";
            BearerToken = string.Empty;
        }
        public string UserName { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool canAccessProducts { get; set; }
        public bool canAddProducts { get; set; }
        public bool canSaveProducts { get; set; }
        public bool canAccessCategories { get; set; }
        public bool canAddCategories { get; set; }
    }
}