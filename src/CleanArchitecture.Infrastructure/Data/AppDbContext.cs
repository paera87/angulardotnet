using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hogstorp.Core.Entities;
using Hogstorp.Core.Interfaces;
using Hogstorp.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Hogstorp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here
            modelBuilder.Entity<PlayerTraining>()
                .HasKey(playerTraining => new {playerTraining.PlayerId, playerTraining.TrainingId});
            modelBuilder.Entity<PlayerTraining>()
                .HasOne<Player>(s => s.Player)
                .WithMany(g => g.PlayerTrainings)
                .HasForeignKey(s => s.PlayerId);

            modelBuilder.Entity<PlayerTraining>()
                .HasOne<Training>(s => s.Training)
                .WithMany(g => g.PlayersTrainings)
                .HasForeignKey(s => s.TrainingId);


        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Training> Trainings{ get; set; }
        public DbSet<PlayerTraining> PlayerTrainings{ get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            int result = await base.SaveChangesAsync(cancellationToken);

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    _dispatcher.Dispatch(domainEvent);
                }
            }

            return result;
        }
    }
}