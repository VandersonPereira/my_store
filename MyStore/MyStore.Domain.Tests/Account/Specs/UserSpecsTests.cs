using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStore.Domain.Account.Entities;
using MyStore.Domain.Account.Specs;

namespace MyStore.Domain.Tests.Account.Specs
{
    [TestClass]
    public class UserSpecsTests
    {
        private List<User> _users;

        public UserSpecsTests()
        {
            _users = new List<User>();

            _users.Add(new User("vandoap@hotmail.com", "vandersonpereira", "123456"));
            _users.Add(new User("lih_beatriz@hotmail.com", "alinegianola", "654321"));
            _users.Add(new User("teste@hotmail.com", "testesobrenome", "teste1234"));
            _users.Add(new User("teste2@hotmail.com", "teste2sobrenome2", "teste212342"));
        }

        [TestMethod]
        [TestCategory("Users - Specs")]
        public void GetByUserNameShouldReturnValue()
        {
            var user = _users
                .AsQueryable()
                .Where(UserSpecs.GetByUserName("vandersonpereira"))
                .FirstOrDefault();

            Assert.AreNotEqual(null, user);
        }

        [TestMethod]
        [TestCategory("Users - Specs")]
        public void GetByUserNameDontShouldReturnValue()
        {
            var user = _users
                .AsQueryable()
                .Where(UserSpecs.GetByUserName("vandersonpereira1234"))
                .FirstOrDefault();

            Assert.AreEqual(null, user);
        }
    }
}
