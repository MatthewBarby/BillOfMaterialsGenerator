using BillOfMaterialsGenerator.Interfaces;
using DataEntities;
using Utilities.Interfaces;

namespace BillOfMaterialsGenerator
{
    public class BillOfMaterialsValidator : IBillOfMaterialsValidator
    {
        private const int MaxWidth = 1000;
        private const int MaxHeight = 1000;

        private readonly ILogWrapper logger;

        public BillOfMaterialsValidator(ILogWrapper logger)
        {
            this.logger = logger;
        }

        public bool IsValid(BillOfMaterials billOfMaterials)
        {
            logger.LogInfo("Beginning validation of next bill");

            foreach (Rectangle rectangle in billOfMaterials.Rectangles)
            {
                if (!ValidateWidget(rectangle))
                {
                    return false;
                }
            }

            foreach (Square square in billOfMaterials.Squares)
            {
                if (!ValidateWidget(square))
                {
                    return false;
                }
            }

            foreach (Ellipse elipse in billOfMaterials.Elipses)
            {
                if (!ValidateWidget(elipse))
                {
                    return false;
                }
            }

            foreach (Circle circle in billOfMaterials.Circles)
            {
                if (!ValidateWidget(circle))
                {
                    return false;
                }
            }

            foreach (Textbox textbox in billOfMaterials.Textboxes)
            {
                if (!ValidateWidget(textbox))
                {
                    return false;
                }
            }

            logger.LogInfo("Finishing validation of bill");

            return true;
        }


        public bool ValidateWidget(Rectangle rectangle)
        {
            if (ValidateHeight(rectangle.Height, rectangle.PositionY)
                && ValidateWidth(rectangle.Width, rectangle.PositionX)
                && ValidateIntProperty(rectangle.PositionX)
                && ValidateIntProperty(rectangle.PositionY))
            {
                return true;
            }
            else
            {
                logger.LogWarn($"Rectangle failed validation. {rectangle.ToString()}");
                return false;
            }
        }

        public bool ValidateWidget(Square square)
        {
            if (ValidateHeight(square.Width, square.PositionY)
                && ValidateWidth(square.Width, square.PositionX)
                && ValidateIntProperty(square.PositionX)
                && ValidateIntProperty(square.PositionY))
            {
                return true;
            }
            else
            {
                logger.LogWarn($"Square failed validation. {square.ToString()}");
                return false;
            }
        }

        public bool ValidateWidget(Ellipse ellipse)
        {
            if (ValidateHeight(ellipse.VerticalDiameter, ellipse.PositionY)
                && ValidateWidth(ellipse.HorizontalDiameter, ellipse.PositionX)
                && ValidateIntProperty(ellipse.PositionX)
                && ValidateIntProperty(ellipse.PositionY))
            {
                return true;
            }
            else
            {
                logger.LogWarn($"Ellipse failed validation. {ellipse.ToString()}");
                return false;
            }
        }

        public bool ValidateWidget(Circle circle)
        {
            if (ValidateHeight(circle.Diameter, circle.PositionY)
                && ValidateWidth(circle.Diameter, circle.PositionY)
                && ValidateIntProperty(circle.PositionX)
                && ValidateIntProperty(circle.PositionY))
            {
                return true;
            }
            else
            {
                logger.LogWarn($"Circle failed validation. {circle.ToString()}");
                return false;
            }
        }

        public bool ValidateWidget(Textbox textbox)
        {
            if (ValidateHeight(textbox.Height, textbox.PositionY)
                && ValidateWidth(textbox.Width, textbox.PositionX)
                && ValidateIntProperty(textbox.PositionX)
                && ValidateIntProperty(textbox.PositionY))
            {
                return true;
            }
            else
            {
                logger.LogWarn($"Textbox failed validation. {textbox.ToString()}");
                return false;
            }
        }

        public bool ValidateHeight(int height, int positionY)
        {
            return height > 0
                && height + positionY < MaxHeight;
        }

        public bool ValidateWidth(int width, int positionX)
        {
            return width > 0
                && width + positionX < MaxWidth;
        }

        public bool ValidateIntProperty(int prop)
        {
            return prop > 0;
        }
    }
}
