﻿using DansBlog.DataAccess;
using DansBlog.Model.Entities;
using DansBlog.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DansBlog.IntegrationTests.Repository_Data
{
    [TestFixture]
    public class CategoryRepository_Should
    {
        private BlogDbContext _dataContext;

        private CategoryRepository _sut;

        [SetUp]
        public void InitTest()
        {
            _dataContext = new BlogDbContext();
            _sut = new CategoryRepository(_dataContext);
        }

        [Test]
        public void All_ReturnAllCategories()
        {
            List<Category> result = _sut.All;

            Assert.AreEqual(10, result.Count);
        }

        [Test]
        public void Find_FindCorrectCategoryById()
        {
            Category result = _sut.Find(3);

            Assert.IsTrue(result.CategoryId == 3);
        }

        [Test]
        public void Find_ReturnNullIfACategoryWithAMatchingIdDoesNotExist()
        {
            Category result = _sut.Find(13);

            Assert.IsNull(result);
        }

        [Test]
        public void Add_AddANewCategoryToTheDatabase()
        {
            var category = new Category { Name = "New Category" };

            _sut.Add(category);
            Category newCategory = _sut.Find(11);

            Assert.AreEqual(11, newCategory.CategoryId);
            Assert.AreEqual("New Category", newCategory.Name);
        }

        [Test]
        public void Add_FailToInsertACategoryIfItAlreadyExistsByName()
        {
            var duplicateCategory = new Category { Name = "Category Two" };

            _sut.Add(duplicateCategory);
            List<Category> categoryList = _sut.All.Where(x => x.Name.Contains("Category Two")).ToList();

            Assert.AreEqual(1, categoryList.Count);
        }

        [Test]
        public void Add_FailToInsertACategoryIfItAlreadyExistsByNameWhilstIgnoringCase()
        {
            var duplicateCategory = new Category { Name = "category one" };

            _sut.Add(duplicateCategory);
            List<Category> categoryList = _sut.All.Where(x => x.Name.Contains("category one")).ToList();

            Assert.AreEqual(0, categoryList.Count);
        }

        [Test]
        public void Update_UpdateARecordInTheDatabase()
        {
            Category result = _sut.Find(3);
            result.Name = "Updated Category";
            _sut.Update(result);

            Category updatedCategory = _sut.Find(3);

            Assert.AreEqual("Updated Category", updatedCategory.Name);
        }

        [Test]
        public void Update_FailToUpdateACatgoryIfItAlreadyExists()
        {
            Category result = _sut.Find(3);

            result.Name = "Category Ten";
            _sut.Update(result);

            Category affectedCategory = _sut.Find(3);

            Assert.AreEqual("Category Three", affectedCategory.Name);
        }

        [Test]
        public void Delete_DeleteARecordInTheDatabase()
        {
            Category result = _sut.Find(3);
            _sut.Delete(result);
            Category deletedResult = _sut.Find(3);

            Assert.IsTrue(deletedResult == null);
        }

        [TearDown]
        public void TearDown()
        {
            _dataContext.Dispose();
            _sut = null;
        }
    }
}
