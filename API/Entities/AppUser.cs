namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }        
    
    //4.33{
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    //}4.33
    }
}