using DataEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Utilities.Interfaces;

namespace BillOfMaterialsGenerator.tests
{
    [TestClass]
    public class BillOfMaterialsValidatorTests
    {
        private BillOfMaterialsValidator billOfMaterialsValidator;

        private Mock<ILogWrapper> mockTestableLogger;

        [TestInitialize]
        public void TestInitialize()
        {
            SetUpBillOfMaterialsValidator();
        }

        #region IsValid tests

        [TestMethod]
        public void IsValid_ValidBillOfMaterials_True()
        {
            // Arrange/Act
            bool isValid = billOfMaterialsValidator.IsValid(GetValidBillOfMaterials());

            // Assert
            Assert.IsTrue(isValid, "Expected isValid to return true");
        }

        [TestMethod]
        public void IsValid_InvalidBillOfMaterials_True()
        {
            // Arrange/Act
            BillOfMaterials billOfMaterials = GetValidBillOfMaterials();
            billOfMaterials.Rectangles[0].Height = -10;

            bool isValid = billOfMaterialsValidator.IsValid(billOfMaterials);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to return false");
        }

        #endregion

        #region ValidateWidget Rectangle tests

        [TestMethod]
        public void ValidateWidgetRectangle_Valid_True()
        {
            // Arrange
            Rectangle widget = new Rectangle
            {
                Height = 40,
                Width = 30,
                PositionX = 10,
                PositionY = 10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsTrue(isValid, "Expected isValid to be true");
        }

        [TestMethod]
        public void ValidateWidgetRectangle_PositionXIsNegative_false()
        {
            // Arrange
            Rectangle widget = new Rectangle
            {
                Height = 40,
                Width = 30,
                PositionX = -10,
                PositionY = 10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        [TestMethod]
        public void ValidateWidgetRectangle_PositionYIsNegative_false()
        {
            // Arrange
            Rectangle widget = new Rectangle
            {
                Height = 40,
                Width = 30,
                PositionX = 10,
                PositionY = -10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        [TestMethod]
        public void ValidateWidgetRectangle_HeightIsNegative_false()
        {
            // Arrange
            Rectangle widget = new Rectangle
            {
                Height = -40,
                Width = 30,
                PositionX = 10,
                PositionY = 10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        [TestMethod]
        public void ValidateWidgetRectangle_WidthIsNegative_false()
        {
            // Arrange
            Rectangle widget = new Rectangle
            {
                Height = 40,
                Width = -30,
                PositionX = 10,
                PositionY = 10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        [TestMethod]
        public void ValidateWidgetRectangle_OffOfCanvas_false()
        {
            // Arrange
            Rectangle widget = new Rectangle
            {
                Height = 999,
                Width = 30,
                PositionX = 10,
                PositionY = 10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        #endregion

        #region ValidateWidget Square tests

        [TestMethod]
        public void ValidateWidgetSquare_Valid_True()
        {
            // Arrange
            Square widget = new Square
            {
                Width = 30,
                PositionX = 10,
                PositionY = 10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsTrue(isValid, "Expected isValid to be true");
        }

        [TestMethod]
        public void ValidateWidgetSquare_PositionXIsNegative_false()
        {
            // Arrange
            Square widget = new Square
            {
                Width = 30,
                PositionX = -10,
                PositionY = 10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        [TestMethod]
        public void ValidateWidgetSquare_PositionYIsNegative_false()
        {
            // Arrange
            Square widget = new Square
            {
                Width = 30,
                PositionX = 10,
                PositionY = -10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        [TestMethod]
        public void ValidateWidgetSquare_WidthIsNegative_false()
        {
            // Arrange
            Square widget = new Square
            {
                Width = -30,
                PositionX = 10,
                PositionY = 10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        [TestMethod]
        public void ValidateWidgetSquare_OffOfCanvas_false()
        {
            // Arrange
            Square widget = new Square
            {
                Width = 995,
                PositionX = 10,
                PositionY = 10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        #endregion

        #region ValidateWidget Ellipse tests

        [TestMethod]
        public void ValidateWidgetEllipse_Valid_True()
        {
            // Arrange
            Ellipse widget = new Ellipse
            {
                VerticalDiameter = 40,
                HorizontalDiameter = 30,
                PositionX = 10,
                PositionY = 10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsTrue(isValid, "Expected isValid to be true");
        }

        [TestMethod]
        public void ValidateWidgetEllipse_PositionXIsNegative_false()
        {
            // Arrange
            Ellipse widget = new Ellipse
            {
                VerticalDiameter = 40,
                HorizontalDiameter = 30,
                PositionX = -10,
                PositionY = 10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        [TestMethod]
        public void ValidateWidgetEllipse_PositionYIsNegative_false()
        {
            // Arrange
            Ellipse widget = new Ellipse
            {
                VerticalDiameter = 40,
                HorizontalDiameter = 30,
                PositionX = 10,
                PositionY = -10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        [TestMethod]
        public void ValidateWidgetEllipse_VerticicalDiameterIsNegative_false()
        {
            // Arrange
            Ellipse widget = new Ellipse
            {
                VerticalDiameter = -40,
                HorizontalDiameter = 30,
                PositionX = 10,
                PositionY = 10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        [TestMethod]
        public void ValidateWidgetEllipse_HorizontalDiameterIsNegative_false()
        {
            // Arrange
            Ellipse widget = new Ellipse
            {
                VerticalDiameter = 40,
                HorizontalDiameter = -30,
                PositionX = 10,
                PositionY = 10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        [TestMethod]
        public void ValidateWidgetEllipse_OffOfCanvas_false()
        {
            // Arrange
            Ellipse widget = new Ellipse
            {
                VerticalDiameter = 999,
                HorizontalDiameter = 30,
                PositionX = 10,
                PositionY = 10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        #endregion

        #region ValidateWidget Circle tests

        [TestMethod]
        public void ValidateWidgetCircle_Valid_True()
        {
            // Arrange
            Circle widget = new Circle
            {
                Diameter = 30,
                PositionX = 10,
                PositionY = 10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsTrue(isValid, "Expected isValid to be true");
        }

        [TestMethod]
        public void ValidateWidgetCircle_PositionXIsNegative_false()
        {
            // Arrange
            Circle widget = new Circle
            {
                Diameter = 30,
                PositionX = -10,
                PositionY = 10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        [TestMethod]
        public void ValidateWidgetCircle_PositionYIsNegative_false()
        {
            // Arrange
            Circle widget = new Circle
            {
                Diameter = 30,
                PositionX = 10,
                PositionY = -10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        [TestMethod]
        public void ValidateWidgetCircle_WidthIsNegative_false()
        {
            // Arrange
            Circle widget = new Circle
            {
                Diameter = -30,
                PositionX = 10,
                PositionY = 10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        [TestMethod]
        public void ValidateWidgetCircle_OffOfCanvas_false()
        {
            // Arrange
            Circle widget = new Circle
            {
                Diameter = 995,
                PositionX = 10,
                PositionY = 10
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        #endregion

        #region ValidateWidget Textbox tests

        [TestMethod]
        public void ValidateWidgetTextbox_Valid_True()
        {
            // Arrange
            Textbox widget = new Textbox
            {
                Height = 40,
                Width = 30,
                PositionX = 10,
                PositionY = 10,
                Text = "Some text"
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsTrue(isValid, "Expected isValid to be true");
        }

        [TestMethod]
        public void ValidateWidgetTextbox_NoText_True()
        {
            // Arrange
            Textbox widget = new Textbox
            {
                Height = 40,
                Width = 30,
                PositionX = 10,
                PositionY = 10,
                Text = string.Empty
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsTrue(isValid, "Expected isValid to be true");
        }

        [TestMethod]
        public void ValidateWidgetTextbox_PositionXIsNegative_false()
        {
            // Arrange
            Textbox widget = new Textbox
            {
                Height = 40,
                Width = 30,
                PositionX = -10,
                PositionY = 10,
                Text = "Some text"
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        [TestMethod]
        public void ValidateWidgetTextbox_PositionYIsNegative_false()
        {
            // Arrange
            Textbox widget = new Textbox
            {
                Height = 40,
                Width = 30,
                PositionX = 10,
                PositionY = -10,
                Text = "Some text"
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        [TestMethod]
        public void ValidateWidgetTextbox_HeightIsNegative_false()
        {
            // Arrange
            Textbox widget = new Textbox
            {
                Height = -40,
                Width = 30,
                PositionX = 10,
                PositionY = 10,
                Text = "Some text"
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        [TestMethod]
        public void ValidateWidgetTextbox_WidthIsNegative_false()
        {
            // Arrange
            Textbox widget = new Textbox
            {
                Height = 40,
                Width = -30,
                PositionX = 10,
                PositionY = 10,
                Text = "Some text"
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        [TestMethod]
        public void ValidateWidgetTextbox_OffOfCanvas_false()
        {
            // Arrange
            Textbox widget = new Textbox
            {
                Height = 999,
                Width = 30,
                PositionX = 10,
                PositionY = 10,
                Text = "Textbox"
            };

            // Act
            bool isValid = billOfMaterialsValidator.ValidateWidget(widget);

            // Assert
            Assert.IsFalse(isValid, "Expected isValid to be false");
        }

        #endregion

        public void SetUpBillOfMaterialsValidator()
        {
            mockTestableLogger = new Mock<ILogWrapper>();

            billOfMaterialsValidator = new BillOfMaterialsValidator(mockTestableLogger.Object);
        }

        public BillOfMaterials GetValidBillOfMaterials()
        {
            return new BillOfMaterials
            {
                Rectangles = new List<Rectangle>
                {
                    new Rectangle
                    {
                        PositionX = 10,
                        PositionY = 10,
                        Width = 30,
                        Height = 40
                    }
                },
                Squares = new List<Square>
                {
                    new Square
                    {
                        PositionX = 15,
                        PositionY = 30,
                        Width = 35
                    }
                },
                Elipses = new List<Ellipse>
                {
                    new Ellipse
                    {
                        PositionX = 100,
                        PositionY = 150,
                        HorizontalDiameter = 300,
                        VerticalDiameter = 200
                    }
                },
                Circles = new List<Circle>
                {
                    new Circle
                    {
                        PositionX = 1,
                        PositionY = 1,
                        Diameter = 300
                    }
                },
                Textboxes = new List<Textbox>
                {
                    new Textbox
                    {
                        PositionX = 5,
                        PositionY = 5,
                        Width = 200,
                        Height = 100,
                        Text = "sample text"
                    }
                }
            };
        }
    }
}
