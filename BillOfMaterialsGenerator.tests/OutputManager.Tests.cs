using BillOfMaterialsGenerator.Interfaces;
using DataEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Utilities.Interfaces;

namespace BillOfMaterialsGenerator.tests
{
    [TestClass]
    public class outputManagerTests
    {
        private OutputManager outputManager;

        private Mock<IConsoleOutput> mockConsoleOutput;
        private Mock<ISystemSettingsWrapper> mockSystemSettingsWrapper;
        private Mock<ILogWrapper> mockLogWrapper;

        [TestInitialize]
        public void TestInitialize()
        {
            SetOutputManager();
        }

        [TestMethod]
        public void OutputBillOfMaterials_OutputToConsoleTrue_OutputsToConsole()
        {
            // Arrange
            mockSystemSettingsWrapper.Setup(x => x.OutputToConsole).Returns(true);

            // Act
            outputManager.OutputBillOfMaterials(new BillOfMaterials());

            // Assert
            mockConsoleOutput.Verify(x => x.OutputBillOfMaterials(It.IsAny<BillOfMaterials>()), Times.Once, "Expected bill to have been output");
        }

        [TestMethod]
        public void OutputBillOfMaterials_OutputToConsoleFalse_BillNotOutput()
        {
            // Arrange
            mockSystemSettingsWrapper.Setup(x => x.OutputToConsole).Returns(false);

            // Act
            outputManager.OutputBillOfMaterials(new BillOfMaterials());

            // Assert
            mockConsoleOutput.Verify(x => x.OutputBillOfMaterials(It.IsAny<BillOfMaterials>()), Times.Never, "Expected bill to not have been output");
        }

        [TestMethod]
        public void OutputError_OutputToConsole_OutputError()
        {
            // Arrange
            mockSystemSettingsWrapper.Setup(x => x.OutputToConsole).Returns(true);

            // Act
            outputManager.OutputError();

            // Assert
            mockConsoleOutput.Verify(x => x.OutputError(), Times.Once(), "Expected error to have been output");
        }

        [TestMethod]
        public void OutputError_OutputToConsoleFalse_ErrorNotOutput()
        {
            // Arrange
            mockSystemSettingsWrapper.Setup(x => x.OutputToConsole).Returns(false);

            // Act
            outputManager.OutputError();

            // Assert
            mockConsoleOutput.Verify(x => x.OutputError(), Times.Never(), "Expected error to not have been output");
        }


        public void SetOutputManager()
        {
            mockConsoleOutput = new Mock<IConsoleOutput>();
            mockSystemSettingsWrapper = new Mock<ISystemSettingsWrapper>();
            mockLogWrapper = new Mock<ILogWrapper>();

            outputManager = new OutputManager(mockConsoleOutput.Object, mockSystemSettingsWrapper.Object, mockLogWrapper.Object);

            
        }
    }
}
