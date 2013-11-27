using DansBlog.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DansBlog.DataAccess
{
    public class BlogDataInitializer : CreateDatabaseIfNotExists<BlogDbContext>
    {
        protected override void Seed(BlogDbContext context)
        {
            var postsList = new List<Post>
            {               
                new Post
                    {
                        Title = "Cycling Diaries",
                        PublishDate = new DateTime(2013, 5, 10),
                        Content = "We really have had some great weather at the moment here in the UK.  Makes a change.  " +
                                  "It’s been absolutely awful for weeks.  Anyway, sensing a bit of sun, I got my racing bike out, dug out my shorts and " +
                                  "rucksack and went for it.  Living on the Fylde coast leaves your cycling route options quite limited.  Quite often I " +
                                  "cycle through Lytham St Anne’s, which is quite a well to do area.  One thing I often notice is that Lytham seems to have " +
                                  "a high proportion of beautiful people.  You really have to concentrate whilst on the roads there.   " +
                                  "No ogling or it might be straight into a lamp post at any given moment.  I don’t imagine this.  " +
                                  "This got me thinking so I did a bit of research.   Conclusion, Attractive people usually earn more or wealthy people attract beautiful people.  Google it and prepare to be amazed.  Not exactly rocket science but It might explain why Lytham is always full of fitties. Lady wise, I'm hoping it's because they earn more, but I'll reserve judgment on that one.",
                        Author = "Daniel Dutton",   
                    },
                new Post
                    {
                        Title = "Just About There",
                        PublishDate = new DateTime(2013, 4, 26),
                        Content = "Well, this blog is 99.9% complete with just a few loose ends to tie up in the admin section.  It’s been an interesting journey, and one that has made me recognise the immense benefits of working with MVC.  It really does crap on (technical term alert) working with Win Forms. It allows you to develop using universally recognised best practices, makes unit testing a breeze, and leaves you feeling that you are in complete control of the development process every step of the way.  The best part was trying to develop the site using Test-Driven-Development.  Although I sometimes rushed ahead then unit tested later (which is clearly cheating), it was my first outing using this methodology and I can see the benefits so will try and stick with it when developing in the future.  I am definately looking forward to learning more in the coming months   ",
                        Author = "Daniel Dutton",   
                    },
                new Post
            {
               Title = "Aha, I'm back again",
               PublishDate = new DateTime(2013, 4, 15),
               Content = "I’m currently running a bit behind schedule with this site.  The reason; I keep refactoring like fury.  The more I read about MVC best practice, the more I want to refactor my code.  The project implements data access using the repository design pattern.  This helps to keep my controllers as skinny as possible.  I spent two days re-designing it.  Instead of instant coding, I sat down and really thought about the best way to architecture it.  It’s now a hell of a lot more efficient, and adheres nicely to the majority of the SOLID design principles.  Time taken it’s a pain but for long term gain I guess it’s not.     ",
               Author = "Daniel Dutton",
               Comments = new List<Comment>
            {
               new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "This is blog 1 test comment and is not very interesting really",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now, 
                  HasBeenModerated = true,
                },  
                new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "This is blog 2 test comment and is not very interesting really",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now,  
                  HasBeenModerated = true,
                }, 
                new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "This is blog 3 test comment and is not very interesting really",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now,       
                  HasBeenModerated = true,
                }, 
             },
             Categories = new List<Category>
             {
                 new Category{Name = "Programming"},
             },
                 Tags = new List<Tag>
                 {
                   new Tag{Name = "Xhtml"},
                   new Tag{Name = "Programming"},
                   new Tag{Name = "JQuery"},
                   new Tag{Name = "Css"},
             },
           },new Post
                    {
                        Title = "Slightly Tipsy Deep Thinking",
                        PublishDate = new DateTime(2013, 4, 10),
                        Content = "Can you be everywhere?  Are you part of everything?  I was watching an Idiot Abroad series three, the one where Karl was on a boat travelling through the waters of Venice.  The narrator was extolling the great adventure of Marco Polo who travelled the same route.  Then I thought, did Marco actually take in everything he could.  Yeah he was an explorer but he only explored the part of the world as we know it.  How we saw it.  The world abstracted to his and our particular view.  If you were an atom who decided to go exploring, what would your journey be like?  You might follow the same route as Marco, but you would take in a completely different view.   I pictured the waves the boat was travelling on and I imagined myself being part of the wave, part of the water.   Is this possible?  To be part of everything...everywhere.  They say that every breath we take contains atoms that have been inhaled by famous peeps.  If that is the case, can we explore just by sitting still and breathing.  And then I thought have we really explored all there is to explore.  Not if we had the view-point of an atom.  I’m drunk as I type this by the way, but hey, just a thought.  There’s a lot more out there than we can currently comprehend.",
                        Author = "Daniel Dutton",   
                    },
               new Post
            {
               Title = "Aha, I'm back",
               PublishDate = new DateTime(2013, 4, 7),
               Content = "This site is currently being rebuilt. What stood in its place previously was an Umbraco powered blog plug-in. However, I decided to rewrite the thing from scratch using ASP.NET MVC 3.0 with Razor, Linq, Entity Framework Code First 4.0 and plenty of Dependency Injection Using Ninject. Hopefully it should be finished soon.",
               Author = "Daniel Dutton",
               Comments = new List<Comment>
            {
               new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "This is blog 1 test comment and is not very interesting really",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now,
                  HasBeenModerated = true,
                },  
                new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "This is blog 2 test comment and is not very interesting really",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now,  
                  HasBeenModerated = true,
                }, 
                new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "This is blog 3 test comment and is not very interesting really",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now, 
                  HasBeenModerated = true,
                }, 
             },
             Categories = new List<Category>
             {
                 new Category{Name = "Programming"},
             },
                 Tags = new List<Tag>
                 {
                   new Tag{Name = "Xhtml"},
                   new Tag{Name = "Programming"},
                   new Tag{Name = "JQuery"},
                   new Tag{Name = "Css"},
             },
           },

           new Post
            {
               Title = "Thinking Too Much",
               PublishDate = new DateTime(2013, 03, 2),
               Content = "Content for Blog 2 woohoo Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nisl dolor, volutpat a vehicula et, scelerisque non purus. Vestibulum at semper purus. Nunc gravida mollis posuere. Mauris vel condimentum diam. Morbi at pulvinar enim. Vivamus et neque sed ipsum tincidunt ultricies nec sit amet eros ",
               Author = "Daniel Dutton",
               Comments = new List<Comment>
            {
               new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "Blog 1 Comment 1",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now,  
                  HasBeenModerated = true,
              
                }    ,
                new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "Blog 1 Comment 1",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now,
                  HasBeenModerated = true,
                }, 
             },
             Categories = new List<Category>
             {
                 new Category{Name = "XHTML"},
             },
                 Tags = new List<Tag>
                 {
                   new Tag{Name = "Css"},
                   new Tag{Name = "JavaScript"},
             },
           },
   

            new Post
            {
               Title = "Blog 2 Title Category XHTML",
               PublishDate = new DateTime(2013, 02, 2),
               Content = "Content for Blog 2 woohoo Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nisl dolor, volutpat a vehicula et, scelerisque non purus. Vestibulum at semper purus. Nunc gravida mollis posuere. Mauris vel condimentum diam. Morbi at pulvinar enim. Vivamus et neque sed ipsum tincidunt ultricies nec sit amet eros",
               Author = "Daniel Dutton",
               Comments = new List<Comment>(),
              Categories = new List<Category>
                              {
                                  new Category{Name = "JavaScript"},
                              },
                              Tags = new List<Tag>
                 {
                   new Tag{Name = "Programming"},
                   new Tag{Name = "JQuery"},
             },
            },


            new Post
            {
               Title = "Blog 3 Title Category MVC",
               PublishDate = new DateTime(2013, 01, 2),
               Content = "Content for Blog 3 woohoo Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nisl dolor, volutpat a vehicula et, scelerisque non purus. Vestibulum at semper purus. Nunc gravida mollis posuere. Mauris vel condimentum diam. Morbi at pulvinar enim. Vivamus et neque sed ipsum tincidunt ultricies nec sit amet eros",
               Author = "Daniel Dutton",
               Comments = new List<Comment>
            {
               new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "Blog 3 Comment 3",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now,
                  HasBeenModerated = true,
                }    
             },
              Categories = new List<Category>
                              {
                                  new Category{Name = "ASP.NET MVC"},
                              },
                              Tags = new List<Tag>
                 {
                   new Tag{Name = "Css"},
                   new Tag{Name = "JavaScript"},
             },
            },
            new Post
            {
               Title = "Blog 3 Title Category CSS",
               PublishDate = new DateTime(2012, 12, 2),
               Content = "Content for Blog 3 woohoo Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nisl dolor, volutpat a vehicula et, scelerisque non purus. Vestibulum at semper purus. Nunc gravida mollis posuere. Mauris vel condimentum diam. Morbi at pulvinar enim. Vivamus et neque sed ipsum tincidunt ultricies nec sit amet eros",
               Author = "Daniel Dutton",
               Comments = new List<Comment>
            {
               new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "Blog 3 Comment 3",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now,
                  HasBeenModerated = true,
                }    
             },
              Categories = new List<Category>
                              {
                                  new Category{Name = "CSS"},
                              },
                              Tags = new List<Tag>
                 {
                   new Tag{Name = "Css"},
             },
            },
            new Post
            {
               Title = "Blog 3 Title Category CSS",
               PublishDate = new DateTime(2011, 12, 2),
               Content = "Content for Blog 3 woohoo Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nisl dolor, volutpat a vehicula et, scelerisque non purus. Vestibulum at semper purus. Nunc gravida mollis posuere. Mauris vel condimentum diam. Morbi at pulvinar enim. Vivamus et neque sed ipsum tincidunt ultricies nec sit amet eros",
               Author = "Daniel Dutton",
               Comments = new List<Comment>
            {
               new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "Blog 3 Comment 3",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now,
                  HasBeenModerated = true,
                }    
             },
              Categories = new List<Category>
                              {
                                  new Category{Name = "CSS"},
                              },
                              Tags = new List<Tag>
                 {
                   new Tag{Name = "Css"},
             },
            },
            new Post
            {
               Title = "Blog 3 Title Category Random Category",
               PublishDate = new DateTime(2012, 6, 23),
               Content = "Content for Blog 3 woohoo Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nisl dolor, volutpat a vehicula et, scelerisque non purus. Vestibulum at semper purus. Nunc gravida mollis posuere. Mauris vel condimentum diam. Morbi at pulvinar enim. Vivamus et neque sed ipsum tincidunt ultricies nec sit amet eros",
               Author = "Daniel Dutton",
               Comments = new List<Comment>
            {
               new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "Blog 3 Comment 3",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now,
                  HasBeenModerated = true,
                }    
             },
              Categories = new List<Category>
                              {
                                  new Category{Name = "Random Category"},
                              },
                              Tags = new List<Tag>
                 {
                   new Tag{Name = "Css"},
                   new Tag{Name = "JavaScript"},
             },
            },
            new Post
            {
               Title = "Blog 3 Title Category Random Category",
               PublishDate = new DateTime(2012, 4, 23),
               Content = "Content for Blog 3 woohoo Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nisl dolor, volutpat a vehicula et, scelerisque non purus. Vestibulum at semper purus. Nunc gravida mollis posuere. Mauris vel condimentum diam. Morbi at pulvinar enim. Vivamus et neque sed ipsum tincidunt ultricies nec sit amet eros",
               Author = "Daniel Dutton",
               Comments = new List<Comment>
            {
               new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "Blog 3 Comment 3",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now,
                  HasBeenModerated = true,
                }    
             },
              Categories = new List<Category>
                              {
                                  new Category{Name = "Random Category"},
                              },
                              Tags = new List<Tag>
                 {
                   new Tag{Name = "Css"},
                   new Tag{Name = "JavaScript"},
             },
            },
            new Post
            {
               Title = "Blog 3 Title Category Random Category programming",
               PublishDate = new DateTime(2012, 12, 23),
               Content = "Content for Blog 3 woohoo Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nisl dolor, volutpat a vehicula et, scelerisque non purus. Vestibulum at semper purus. Nunc gravida mollis posuere. Mauris vel condimentum diam. Morbi at pulvinar enim. Vivamus et neque sed ipsum tincidunt ultricies nec sit amet eros",
               Author = "Daniel Dutton",
               Comments = new List<Comment>
            {
               new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "Blog 3 Comment 3",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now,
                  HasBeenModerated = true,
                }    
             },
              Categories = new List<Category>
                              {
                                  new Category{Name = "Random Category"},
                                  new Category{Name = "Programming"},
                              }
            },
            new Post
            {
               Title = "Blog 3 Title Category Random Category programming",
               PublishDate = new DateTime(2012, 12, 23),
               Content = "Content for Blog 3 woohoo Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nisl dolor, volutpat a vehicula et, scelerisque non purus. Vestibulum at semper purus. Nunc gravida mollis posuere. Mauris vel condimentum diam. Morbi at pulvinar enim. Vivamus et neque sed ipsum tincidunt ultricies nec sit amet eros",
               Author = "Daniel Dutton",
               Comments = new List<Comment>
            {
               new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "Blog 3 Comment 3",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now,
                  HasBeenModerated = true,
                }    
             },
              Categories = new List<Category>
                              {
                                  new Category{Name = "Random Category"},
                                  new Category{Name = "Programming"},

                              }
            },
            new Post
            {
               Title = "Blog 3 Title Category Random Category",
               PublishDate = new DateTime(2012, 12, 23),
               Content = "Content for Blog 3 woohoo Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nisl dolor, volutpat a vehicula et, scelerisque non purus. Vestibulum at semper purus. Nunc gravida mollis posuere. Mauris vel condimentum diam. Morbi at pulvinar enim. Vivamus et neque sed ipsum tincidunt ultricies nec sit amet eros",
               Author = "Daniel Dutton",
               Comments = new List<Comment>
            {
               new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "Blog 3 Comment 3",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now,
                  HasBeenModerated = true,
                }    
             },
              Categories = new List<Category>
                              {
                                  new Category{Name = "Random Category"},
                              }
            },
            new Post
            {
               Title = "Blog 3 Title Category Random Category",
               PublishDate = new DateTime(2012, 11, 17),
               Content = "Content for Blog 3 woohoo Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nisl dolor, volutpat a vehicula et, scelerisque non purus. Vestibulum at semper purus. Nunc gravida mollis posuere. Mauris vel condimentum diam. Morbi at pulvinar enim. Vivamus et neque sed ipsum tincidunt ultricies nec sit amet eros",
               Author = "Daniel Dutton",
               Comments = new List<Comment>
            {
               new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "Blog 3 Comment 3",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now,
                  HasBeenModerated = true,
                }    
             },
              Categories = new List<Category>
                              {
                                  new Category{Name = "Random Category"},
                              }
            },

            new Post
            {
               Title = "Blog 3 Title Category Random Category",
               PublishDate = new DateTime(2012, 11, 2),
               Content = "Content for Blog 3 woohoo Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nisl dolor, volutpat a vehicula et, scelerisque non purus. Vestibulum at semper purus. Nunc gravida mollis posuere. Mauris vel condimentum diam. Morbi at pulvinar enim. Vivamus et neque sed ipsum tincidunt ultricies nec sit amet eros",
               Author = "Daniel Dutton",
               Comments = new List<Comment>
            {
               new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "Blog 3 Comment 3",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now,
                  HasBeenModerated = true,
                }    
             },
              Categories = new List<Category>
                              {
                                  new Category{Name = "Random Category"},
                              }
            },

            new Post
            {
               Title = "Blog 3 Title Category Random Category",
               PublishDate = new DateTime(2012, 11, 23),
               Content = "Content for Blog 3 woohoo Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nisl dolor, volutpat a vehicula et, scelerisque non purus. Vestibulum at semper purus. Nunc gravida mollis posuere. Mauris vel condimentum diam. Morbi at pulvinar enim. Vivamus et neque sed ipsum tincidunt ultricies nec sit amet eros",
               Author = "Daniel Dutton",
               Comments = new List<Comment>
            {
               new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "Blog 3 Comment 3",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now,
                  HasBeenModerated = true,
                }    
             },
              Categories = new List<Category>
                              {
                                  new Category{Name = "Random Category"},
                              }
            },

           };

            foreach(var post in postsList)
            {
                context.Posts.Add(post);
            }

            base.Seed(context);
        }
    }
}
