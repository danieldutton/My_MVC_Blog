using DansBlog.DataAccess;
using DansBlog.Model.Entities;
using DansBlog.Repository.Repositories;
using Moq;
using NUnit.Framework;

namespace DansBlog._UnitTests.Repository
{
    [TestFixture]
    public class PostRepositoryShould
    {
        #region Add

        [Test]
        public void Add_CallMethod_Posts_Add()
        {
            var fakeBlogDbContext = new Mock<IDbContext>();
            fakeBlogDbContext.Setup(x => x.Posts.Add(It.IsAny<Post>()));
            var sut = new PostRepository(fakeBlogDbContext.Object);

            sut.Add(new Post());

            fakeBlogDbContext.Verify();
        }

        [Test]
        public void Add_CallMethod_Posts_SaveChanges()
        {
            var fakeBlogDbContext = new Mock<IDbContext>();
            fakeBlogDbContext.Setup(x => x.Posts.Add(It.IsAny<Post>()));
            var sut = new PostRepository(fakeBlogDbContext.Object);

            sut.Add(new Post());

            fakeBlogDbContext.Verify(x => x.SaveChanges(), Times.Once());
        }

        #endregion

        #region Update

        [Test]
        public void Update_CallMethod_SetModified()
        {
            var fakeBlogDbContext = new Mock<IDbContext>();
            var sut = new PostRepository(fakeBlogDbContext.Object);

            sut.Update(new Post());

            fakeBlogDbContext.Verify(x => x.SetModified(It.IsAny<Post>()), Times.Once());
        }

        [Test]
        public void Update_CallMethod_SaveChanges()
        {
            var fakeBlogDbContext = new Mock<IDbContext>();
            fakeBlogDbContext.Setup(x => x.SetModified(It.IsAny<Post>()));
            var sut = new PostRepository(fakeBlogDbContext.Object);

            sut.Update(new Post());

            fakeBlogDbContext.Verify(x => x.SaveChanges(), Times.Once());
        }

        #endregion

        #region Find

        [Test]
        public void Find_CallMethod_Posts_Find()
        {
            //var fakeBlogDbContext = new Mock<IDbContext>();
            //fakeBlogDbContext.Setup(x => x.Posts).Returns(Mother.GetTenPostsInRandomOrder());
            //var sut = new PostRepository(fakeBlogDbContext.Object);
            
            //sut.Find(1);

            //fakeBlogDbContext.Verify(x => x.Posts.Find(1), Times.Exactly(2));
        }

        [Test]
        public void ReturnTheCorrectPost_ForIdGiven()
        {
            var fakeBlogDbContext = new Mock<IDbContext>();
            var sut = new PostRepository(fakeBlogDbContext.Object);   
        }

        #endregion
    }
}
