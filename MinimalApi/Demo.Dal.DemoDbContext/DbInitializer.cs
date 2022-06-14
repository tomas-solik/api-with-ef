using Demo.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Dal.DemoDbContext
{
    public static class DbInitializer
    {
        public static void Initialize(DemoDbContext context)
        {
            // Drop the database if it exists
            context.Database.EnsureDeleted();
            
            // Create the database if it doesn't exist
            context.Database.EnsureCreated();

            SeedData(context);
        }

        public static void SeedData(DemoDbContext context)
        {
            if (context.Tools.Any())
            {
                return; //Db already contains something...
            }

            var quickMeasurementToolManufacturer = new ToolManufacturer
            {
                Name = "QuickMeasurementToolsManufacturer"
            };

            context.Manufacturers.Add(quickMeasurementToolManufacturer);
            //context.SaveChanges();

            var ittModel = new ToolModel
            {
                Name = "QM_Itt",
                Description = "Indicating Torque Tool for Quick Measurement",
                ToolType = ToolTechnology.IndicatingTorqueTool,
                Manufacturer = quickMeasurementToolManufacturer

            };

            var nutModel = new ToolModel
            {
                Name = "QM_Nut",
                Description = "Nutrunner for Quick Measurement",
                ToolType = ToolTechnology.Nutrunner,
                Manufacturer = quickMeasurementToolManufacturer
            };

            var sttModel = new ToolModel
            {
                Name = "QM_Stt",
                Description = "Setting Torque Tool for Quick Measurement",
                ToolType = ToolTechnology.SettingTorqueTool,
                Manufacturer = quickMeasurementToolManufacturer
            };

            var impModel = new ToolModel
            {
                Name = "QM_Imp",
                Description = "Impulse Tool for Quick Measurement",
                ToolType = ToolTechnology.ImpulseTool,
                Manufacturer = quickMeasurementToolManufacturer
            };

            context.Models.AddRange(ittModel, nutModel, sttModel, impModel);

            var itt = new Tool
            {
                Model = ittModel,
                Name = "QM_Itt",
                NominalValue = 500
            };

            var nut = new Tool
            {
                Model = nutModel,
                Name = "QM_Nut",
                NominalValue = 500
            };

            var stt = new Tool
            {
                Model = sttModel,
                Name = "QM_Stt",
                NominalValue = 500
            };

            var imp = new Tool
            {
                Model = impModel,
                Name = "QM_Itt",
                NominalValue = 500
            };

            context.Tools.AddRange(itt, nut, stt, imp);

            context.Users.Add(new User
            {
                Email = "super@domain.com",
                FirstName = "Tomas",
                LastName = "Solik",
                Username = "super",
                Password = "1"
            });

            //finally we save changes
            context.SaveChanges();
        }
    }
}
