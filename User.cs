public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Username { get; set; }

    [EmailAddress]
    public string Email { get; set; }
}
