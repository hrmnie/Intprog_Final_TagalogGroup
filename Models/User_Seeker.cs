using System.ComponentModel.DataAnnotations;
using static NuGet.Packaging.PackagingConstants;

namespace AdventureSeekers.Models;

public class User_Seeker
{
    [Key]
    public int? seeker_id { get;set; }
    [Required]
    public string? seeker_name { get;set; }
    public string? seeker_email { get;set; }
    public string? seeker_contact { get;set; }
    public string? seeker_address { get;set; }
    public string? seeker_password { get;set; }
    public ICollection<User_Post> User_Post { get; set; }

}
