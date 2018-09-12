using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStore.Domain.Account.Entities;
using MyStore.Domain.Account.Scopes;

namespace MyStore.Domain.Tests.Scopes
{
    [TestClass]
    public class UserScopeTests
    {
        [TestMethod]
        [TestCategory("Users - Scopes.")]
        public void RegisterScopeIsValid()
        {
            var user = new User("vandoap@hotmail.com", "vandersonpereira", "123456");
            Assert.AreEqual(true, user.RegisterScopeIsValid());
        }

        // SEGUE MESMA LÓGICA PARA DEMAIS MÉTODOS DO USERS SCOPES --------------------------------

    }
}
