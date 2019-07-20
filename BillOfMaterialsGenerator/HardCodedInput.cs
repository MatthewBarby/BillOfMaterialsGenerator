using BillOfMaterialsGenerator.Interfaces;
using DataEntities;
using System.Collections.Generic;
using Utilities.Interfaces;

namespace BillOfMaterialsGenerator
{
    /// <summary>
    /// Class for reading in a hard coded bill of materials
    /// </summary>
    public class HardCodedInput : IInputMethod
    {
        private readonly ILogWrapper logger;

        public HardCodedInput(ILogWrapper logger)
        {
            this.logger = logger;
        }

        public BillOfMaterials GetBillOfMaterials()
        {
            logger.LogInfo("Getting hard coded bill");

            // default test data
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
