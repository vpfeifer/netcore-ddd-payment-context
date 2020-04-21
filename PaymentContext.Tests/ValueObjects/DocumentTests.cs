using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShouldBeInvalidWhenCNPJIsInvalid()
        {
            var document = new Document("1234", DocumentTypeEnum.CNPJ);
            Assert.IsTrue(document.Invalid);
            Assert.AreEqual(1, document.Notifications.Count);
            Assert.AreEqual("Invalid CNPJ", document.Notifications.First().Message);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("21455355000145")]
        [DataRow("43743261000104")]
        [DataRow("70766212000160")]
        public void ShouldBeValidWhenCNPJIsValid(string cnpj)
        {
            var document = new Document(cnpj, DocumentTypeEnum.CNPJ);
            Assert.IsTrue(document.Valid);
            Assert.AreEqual(0, document.Notifications.Count);
        }

        [TestMethod]
        public void ShouldBeInvalidWhenCPFIsInvalid()
        {
            var document = new Document("1234", DocumentTypeEnum.CPF);
            Assert.IsTrue(document.Invalid);
            Assert.AreEqual(1, document.Notifications.Count);
            Assert.AreEqual("Invalid CPF", document.Notifications.First().Message);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("82169291458")]
        [DataRow("47186112706")]
        [DataRow("95585012800")]
        public void ShouldBeValidWhenCPFIsValid(string cpf)
        {
            var document = new Document(cpf, DocumentTypeEnum.CPF);
            Assert.IsTrue(document.Valid);
            Assert.AreEqual(0, document.Notifications.Count);
        }
    }
}