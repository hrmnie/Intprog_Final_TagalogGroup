using System.ComponentModel.DataAnnotations;

namespace AdventureSeekers.Models;

public class Comment
{
    [Key]
    public int comment_id { get; set; }
    public int post_id { get; set; }
    [Required]
    public string comment { get; set; }
    public string comment_name {  get; set; }
    public string comment_date {  get; set; }
    public User_Post User_Post { get; set; }

}
