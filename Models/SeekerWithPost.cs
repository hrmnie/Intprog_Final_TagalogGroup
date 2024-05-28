namespace AdventureSeekers.Models;

public class SeekerWithPost
{
    public User_Seeker seeker { get; set; }
    public User_Post post { get; set; }
    public IEnumerable< Comment> comment { get; set; }
}
