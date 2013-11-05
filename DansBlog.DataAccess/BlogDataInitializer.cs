using DansBlog.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DansBlog.DataAccess
{
    public class BlogDataInitializer : DropCreateDatabaseAlways<BlogDbContext>
    {
        protected override void Seed(BlogDbContext context)
        {
            var postsList = new List<Post>
            {
                new Post
                    {
                        Title = "Going Text Crazy",
                        PublishDate = new DateTime(2013, 9, 28 ),
                        Content =  @"Trawling through the deep dark depths of my external hard-drive, I came up with some interesting code samples I had written a few years back.  There was all-sorts of good stuff lurking in there, a few of which are worth working on further.  I raised a smile when I came across a Java Android program I wrote called Text Roulette.  It simply picks a random victim from your contacts, then pulls in a cheeky quote from an xml file before texting the victim.  Imagine the horror of asking your mother for a strip-tease by text.  I can remember being extremely chuffed with myself for simply being able to send a text programmatically. I was even more chuffed when I realised I had the power to text people en-masse.  I can remember my friend threatening to “knock me out” the following day after he had received hundreds of texts and his phone nearly imploded.  What prompted me to “for-loop” text his number I can’t remember exactly but it was pretty funny.  The GUI on the program is nothing to write home about but I intend to spruce it up and stick it on Github shortly.  So feel free to download and customise it to your hearts desire.  I will post a link to the source code soon.",

                        Author = "Daniel Dutton",   
                    },
                new Post
                    {
                        Title = "It Justice’nt right",
                        PublishDate = new DateTime(2013, 8, 20 ),
                        Content =  @"I am not very happy with the British Justice System today. A short while back, I came home from work and disturbed two masked intruders at my home. Challenging them, as any person would, I was attacked and injured quite badly. One of them was carrying a metal bar and wasn’t afraid to use it. Afterwards, my legs, in particular were a complete mess. I couldn’t walk for a while and I continued to suffer from anxiety for some time after. Not being a vengeful person, I let the police take over and they were brilliant. I cannot fault them. However, despite what I would consider to be overwhelming evidence indicating their guilt, The Crown Prosecution Service advised me that there wasn’t enough evidence to prosecute the men involved. I was quite rightly flabbergasted and still am. I’m intelligent enough to understand that stringent rules must be in place to protect the innocent, but as a lay person, it is shocking to me at the detail of evidence required to secure a prosecution. It particularly grates that I have had to put my career on hold whilst I recovered. If I am ever unfortunate enough to be attacked again, I will be sure to ask the perpetrators if I can have a photo with them and maybe offer them a cup of tea over a signed confession before seeing them on their merry way.",

                        Author = "Daniel Dutton",   
                    },
                new Post
                    {
                        Title = "Neither ear nor hair",
                        PublishDate = new DateTime(2013, 7, 19 ),
                        Content =  @"I’ve got quite a lot of chest hair and the older I seem to get, the bushier it seems to grow.  I thought it would reach a peak growth phase and stop but obviously not.  It seems to be on a growth par with my ear hair, another annoyance.  I mean what is that all about?  It can’t be one of evolutions grand master plans, surely, because I can’t see any legitimate reason for it being there.  If I could grow it to a decent length and then comb it over my ears to keep them warm, then fair enough.  If I could walk down the street and catch my tea in it sort of like a spider’s web, then again, fair enough.  Next time I’m out cycling, I might test them out as wind brakes.  Then again, I will probably just trim them off.  I think I might be running short of things to blog about.  This is not good.  That said, any suggestions for alternative ear hair use will be warmly welcomed.",

                        Author = "Daniel Dutton",   
                    },
                new Post
                    {
                        Title = "Here Aygo Again",
                        PublishDate = new DateTime(2013, 7, 9 ),
                        Content =  @"I never regretted the moment I was handed the keys to my dapper 1ltr Toyota Aygo.  Car tax costs twenty pounds per annum.  Fully comp insurance can be had for less than two hundred pounds.  Fuel efficiency simply rocks at sixty-two miles per gallon.  The thing practically runs on fresh air.  There are downsides of course.  You have to be prepared to be immediately emasculated as soon as you sit in the driver’s seat.   The car is small.  No actually it’s seriously small.  Other drivers seem to assume that because your car is delicate, you too will drive in a delicate manner.  It’s almost like upon purchasing the car, you agree to an implied contract; one with terms that dictate that you can be bullied off the road at any moment.   That said, if you can get past this minor crutch, you will enjoy a car that is nippy, versatile, and can handle almost anything……oh, except for big hills.  I found this out when me and the girlfriend went on an outing to the Trough of Bowland and came face to face with such a beast.  I literally had to drive up the thing in first gear. Yes that’s right, first gear all the way.  We made it of course but it was a close shave.  I still love the Aygo though.",

                        Author = "Daniel Dutton",   
                    },
                    new Post
                    {
                        Title = "Technically It's Wrong",
                        PublishDate = new DateTime(2013, 6, 15 ),
                        Content =  @"Just recently I have found that I have been running out of things to blog about, hence the large gap since my last post.  There is only so many times you can say “hey I cycled today”.  Ironically, this blog was supposed to be a technical one.  A journal as such where I could chart my progress as I learn and develop my coding skills further.  However, whenever I sit down to write, I find it a bit of an effort to write “technical”.  It doesn’t feel right.  I think I may try and remedy this soon.  It’s not that I have been short of technical things to jot down, I just don’t feel like it.  Stack Overflow seems to satisfy my urges in this regard.  I have completed an awful lot of training though.  I can’t get enough of Pluralsight at the moment.  Those guys are really spot on with their material.  They don’t just glance over a subject, they really get into the nuts and bolts of everything.  I have looked at all and sundry from MVC 4, Entity Framework, Linq, C# 5.0 and in particular software testing.  I'm not usually one to plug a product, but at twenty pounds a month for a personal subscription, it's well worth it.",

                        Author = "Daniel Dutton",   
                    },
                new Post
                    {
                        Title = "Anti-Bone-Idle",
                        PublishDate = new DateTime(2013, 6, 10 ),
                        Content =  @"Another weekend and another fifty miles completed on the bike. This time I kept to my familiar stomping ground; in and around the streets of Blackpool.  The prom was packed, and as is usual on this route, you have to have your wits about you.  A large proportion of my time was spent circumventing sea-gulls, preventing collisions with small children, and dodging fast moving trams.  Now as I get fitter, I find that I sweat less, my strength increases, and so does my stamina. It seems like hard work for a very long time, and then all of a sudden, my body pulls into line and starts operating more like a machine.  It is at this point for me, that exercise becomes a pleasure rather than a chore.  When I reach this point, a strange phenomenon occurs.  I become ever so more “Anti-Bone-Idle”.  I often find myself wanting to stop and say “Put your chips down mate.  Too much chilling out is bad for you. Go for a run etc”.  Now the said chip muncher is no doubt, quite content, and any intervention on my part would be likely to elicit a one way stream of expletives (Aimed in my direction of course), and it’s not that I see myself as being superior to anyone else, because that I am not.  I think I am just so proud of myself for being disciplined enough to push myself to a higher level, and I enjoy the activity so much that I just want everyone else to get in on the act.  This is flawed thinking though as we are all different at the end of the day.",

                        Author = "Daniel Dutton",   
                    },
                new Post
                    {
                        Title = "Morecambe Promenade Oh Aye",
                        PublishDate = new DateTime(2013, 6, 6 ),
                        Content =  "I had another great day of cycling today.  I really pushed myself and managed to complete 60 miles.  That’s my best distance this year so far.  This time, it was destination Morecambe Promenade.  I hadn’t been for years so I thought it would make for an interesting ride.  With my legs behaving and twinge free, I was confident that I would make it this time. Interestingly, from Lancaster Millennium Bridge, all the way to the promenade, I never had to touch a single road.  There is a 5-6 mile bridle path that runs past Morecambe Football Club, Morecambe Cricket Club and the prom train station.  It ends right on the promenade.  This impressed me immensely.  The town is so cyclist friendly it’s untrue.  They even have dedicated cycle lanes on roundabouts.  Anyway, I stopped and took some photos, admired the scenery, marvelled at the strange Polo Mint Tower, and then headed home.  This is definitely one journey I will be attempting again.",

                        Author = "Daniel Dutton",   
                    },

                new Post
                    {
                        Title = "Lancaster City and back",
                        PublishDate = new DateTime(2013, 6, 3 ),
                        Content = "I cycled from Fleetwood to the city of Lancaster today.  I was even tempted to continue on to Morecambe but felt a few twinges in my legs and to me that always means bad news so I turned around and headed home.  All in all, I managed about 55 miles in total.  I found an amazing cycle path that runs from Glasson Dock for five miles straight into the heart of Lancaster.  Gorgeous scenery, quiet, and it follows the Lune Estuary all the way to the Millenium Bridge.  It was a long achy ride and I had plenty of time to think as I was cycling along. I always think.  Far too much if you ask me.  Anyway, that aside, it was just great.  I don’t understand why some people hate cyclists.  To me it’s like a drug. The best kind.  It makes you feel so alive.",

                        Author = "Daniel Dutton",   
                    },
                new Post
                    {
                        Title = "A Trip to Rochdale",
                        PublishDate = new DateTime(2013, 5, 23 ),
                        Content = "I agreed to pick up some friends from Rochdale and fetch them to Blackpool.  Instead of taking the dreary grey route that is the motorway, I decided to sex the journey up a little bit by hitting the A roads.  My improvised journey saw me pass through Blackburn, Accrington, Oswaldtwistle, then through Haslingden, then past Scout Moor Reservoir and turbines.  It was a pleasant journey.  One observation I made was there are a lot of shiny new hospitals, schools and fire stations, and places, well, generally just look a lot tidier.  Although I am not a Labour supporter, it is clear that this is one legacy they have left that is worth something." +
                                  "There is nothing else exciting to report really.  I’ve been looking at HTML 5 in depth and currently have some training videos on the go. My brother has also got me into watching Bear Grylls Man v Wild.  It’s extremely cheesy in more ways than one, but I must admit I respect any man that can make a tent out of a snakes arse.  That's talent!",         

                        Author = "Daniel Dutton",   
                    },
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
