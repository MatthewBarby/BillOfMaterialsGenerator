using BillOfMaterialsGenerator.Interfaces;
using DataEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Utilities.Interfaces;

namespace BillOfMaterialsGenerator.tests
{
    [TestClass]
    public class BillOfMaterialsGeneratorTests
    {
        private BillOfMaterialsGenerator billOfMaterialsGenerator;

        private Mock<IInputMethod> mockInputMethod;
        private Mock<IBillOfMaterialsValidator> mockBillOfMaterialsValidator;
        private Mock<IOutputManager> mockOutputManager;
        private Mock<ILogWrapper> mockTestableLogger;

        [TestInitialize]
        public void TestInitialize()
        {
            SetUpBillOfMaterialsGenerator();
        }

        [TestMethod]
        public void ProccessNextBill_ValidBill_CallsOutputBill()
        {
            // Arrange
            mockInputMethod.Setup(x => x.GetBillOfMaterials()).Returns(new BillOfMaterials());
            mockBillOfMaterialsValidator.Setup(x => x.IsValid(It.IsAny<BillOfMaterials>())).Returns(true);

            // Act
            billOfMaterialsGenerator.ProccessNextBill();

            // Assert
            mockOutputManager.Verify(x => x.OutputBillOfMaterials(It.IsAny<BillOfMaterials>()), Times.Once(), "Valid bill was not output");
            mockOutputManager.Verify(x => x.OutputError(), Times.Never(), "Error message should not be  output");
        }

        [TestMethod]
        public void ProccessNextBill_InvalidBill_CallsOutputError()
        {
            // Arrange
            mockInputMethod.Setup(x => x.GetBillOfMaterials()).Returns(new BillOfMaterials());
            mockBillOfMaterialsValidator.Setup(x => x.IsValid(It.IsAny<BillOfMaterials>())).Returns(false);

            // Act
            billOfMaterialsGenerator.ProccessNextBill();

            // Assert
            mockOutputManager.Verify(x => x.OutputBillOfMaterials(It.IsAny<BillOfMaterials>()), Times.Never(), "Bill should not be output");
            mockOutputManager.Verify(x => x.OutputError(), Times.Once(), "Error message was not output");
        }

        public void SetUpBillOfMaterialsGenerator()
        {
            mockInputMethod = new Mock<IInputMethod>();
            mockBillOfMaterialsValidator = new Mock<IBillOfMaterialsValidator>();
            mockOutputManager = new Mock<IOutputManager>();
            mockTestableLogger = new Mock<ILogWrapper>();

            billOfMaterialsGenerator = new BillOfMaterialsGenerator(mockInputMethod.Object,
                mockBillOfMaterialsValidator.Object,
                mockOutputManager.Object,
                mockTestableLogger.Object);
        }
    }
}
