public class AuthService
{
    public int? Id { get; set; }
    public string Name { get; set; } = "";
    public string Type { get; set; } = "";

    public bool IsLoggedIn => Id != null;
}