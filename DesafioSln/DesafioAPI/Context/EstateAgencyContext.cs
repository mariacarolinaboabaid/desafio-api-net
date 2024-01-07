using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioAPI.Context
{
    public class EstateAgencyContext : DbContext
    {
        // Construtor
        public EstateAgencyContext(DbContextOptions options) : base(options) { }

        // Declaração das tabelas do BD 
        public DbSet<User> Users { get; set; }
        public DbSet<RealState> Properties { get; set; }
        public DbSet<RealStateImage> Photos { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Declaração do relacionamento entre RealState e RealStateImage
            modelBuilder.Entity<RealStateImage>()
                .HasOne(x => x.RealState)
                .WithMany(y => y.RealStateImages)
                .HasForeignKey(fk => fk.RealStateId)
                .OnDelete(DeleteBehavior.Cascade);


            // Injeção de dados iniciais
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Alexandre Nolla",
                    Email = "alexandrenolla@gmail.com",
                    Telephone = "48999337729",
                    Password = "fullstack123"
                }
            );

            modelBuilder.Entity<RealState>().HasData(
                new RealState
                {
                    Id = 1,
                    Title = "Mansão à beira mar de Jurerê Internacional",
                    Value = 150000000.00,
                    Neighborhood = "Jurerê Internacional",
                    BedroomQuantity = 6,
                    BusinessType = "Aluguel",
                    Adress = "Rua dos Tambaquis, 100, Jurerê Internacional, Florianópolis, Santa Catarina, Brasil"
                },
                new RealState
                {
                    Id = 2,
                    Title = "Apartamento na Beira Mar de Florianópolis",
                    Value = 1500000.00,
                    Neighborhood = "Agronômica",
                    BedroomQuantity = 3,
                    BusinessType = "Venda",
                    Adress = "Avenida Governador Irineu Bornhausen, 3600, Agronômica, Florianópolis, Santa Catarina, Brasil",
                }
            );

            modelBuilder.Entity<RealStateImage>().HasData(
                new RealStateImage
                {
                    Id = 1,
                    ImageUrl = "https://resizedimgs.vivareal.com/fit-in/870x653/named.images.sp/2c98bca226e13c54573f682945d17186/%7Bdescription%7D.jpg",
                    RealStateId = 1
                },
                new RealStateImage
                {
                    Id = 2,
                    ImageUrl = "https://resizedimgs.vivareal.com/fit-in/870x653/named.images.sp/88ec4657fe2299025040c796b652e60d/%7Bdescription%7D.jpg",
                    RealStateId = 1
                },
                new RealStateImage
                {
                    Id = 3,
                    ImageUrl = "https://resizedimgs.vivareal.com/fit-in/870x653/named.images.sp/ce637ca7ec929cb81758021e64caafa2/%7Bdescription%7D.jpg",
                    RealStateId = 1
                },
                new RealStateImage
                {
                    Id = 4,
                    ImageUrl = "https://resizedimgs.vivareal.com/fit-in/870x653/named.images.sp/a4002f5b599a93edc48457f36d421557/%7Bdescription%7D.jpg",
                    RealStateId = 2
                },
                new RealStateImage
                {
                    Id = 5,
                    ImageUrl = "https://resizedimgs.vivareal.com/fit-in/870x653/named.images.sp/7b43c8d9330b4ac163f0f97498ca5fc6/%7Bdescription%7D.jpg",
                    RealStateId = 2
                },
                new RealStateImage
                {
                    Id = 6,
                    ImageUrl = "https://resizedimgs.vivareal.com/fit-in/870x653/named.images.sp/95ebb9c47c5562310fd3fc67a4489329/%7Bdescription%7D.jpg",
                    RealStateId = 2
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
