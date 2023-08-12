using Microsoft.AspNetCore.Identity;

namespace WebChatApp.Data.Entities
{
    public class ManageUser : IdentityUser
    {
        public int DisplayName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
