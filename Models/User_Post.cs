using System.ComponentModel.DataAnnotations;

namespace AdventureSeekers.Models;

public class User_Post
{
    [Key]
    public int post_id { get; set; }
    public int seeker_id { get; set; }
    [Required]
    public string? post_image {  get; set; }
    public string? post_title {  get; set; }
    public string? post_caption {  get; set; }
    public string? post_location {  get; set; }
    public string? post_categories {  get; set; }
    public User_Seeker User_Seekers { get; set; }
    public ICollection<Comment> Comments { get; set; }


}
