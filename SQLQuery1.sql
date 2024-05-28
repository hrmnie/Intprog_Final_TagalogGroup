

select * from User_Seeker inner join User_Post on User_Post.seeker_id = User_Seeker.seeker_id 
full join Comments on Comments.post_id = User_Post.post_id;

insert into Comments (post_id, comment, comment_name, comment_date)
VALUES('1','I love the beach','James','05-24-24');