using JuliePro_Core;
using JuliePro_DataAccess.Data;
using JuliePro_Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace JuliePro_Test
{
    public class TrainerServiceTest
    {
        private DbContextOptions<JulieProDbContext> options;
        private TrainersService service;
        private JulieProDbContext dbContext;
        public TrainerServiceTest()
        {
            options = new DbContextOptionsBuilder<JulieProDbContext>()
                .UseInMemoryDatabase("mem").Options;
            dbContext = new JulieProDbContext(options);
            service = new TrainersService(dbContext);

        }

        [Fact]
        public async Task TrainerServiceAddTest()
        {
            // Arramge
            var trainer = new Trainer 
            {
                Id = 1,
                FirstName = "test",
                LastName = "test123",
            };

            // Act

            await service.AddAsync<Trainer>(trainer);

            //assert
            var count = (await dbContext.Trainers.ToListAsync()).Count;
            var trainerFromDb = await dbContext.Trainers.FirstOrDefaultAsync(x => x.Id == trainer.Id);
            Assert.Equal(1, count);
            Assert.NotNull(trainerFromDb);
            Assert.Equal(trainer.Name, trainerFromDb.Name);

            dbContext.Database.EnsureDeleted();
        }

        [Fact]
        public async Task TrainerServiceGetAllActiveTest()
        {
            // Arramge
            var trainer = new Trainer
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "bob",
                Active = true
            };
            var trainer1 = new Trainer
            {
                Id = 2,
                FirstName = "jack",
                LastName = "jack",
                Active = false
            };
            var trainer3 = new Trainer
            {
                Id = 3,
                FirstName = "albert",
                LastName = "albert",
                Active = true
            };

            await service.AddAsync<Trainer>(trainer);
            await service.AddAsync<Trainer>(trainer1);
            await service.AddAsync<Trainer>(trainer3);

            // Act

            var activeTrainers = await service.GetAllActive();

            //assert
            Assert.Equal(2, activeTrainers.Count());
            Assert.Contains(activeTrainers, x => x.FirstName == "Bob" || x.FirstName == "albert");
            Assert.DoesNotContain(activeTrainers, x => x.FirstName == "Jack");

            dbContext.Database.EnsureDeleted();
        }
    }
}
