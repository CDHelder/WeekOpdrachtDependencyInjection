using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using WeekOpdrachtDependencyInjection.Core.Entities;

namespace WeekOpdrachtDependencyInjection.Data.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            var movieData = new List<Movie> {
                new Movie { Id = 1, Title = "Jaws", ReleaseDate = new DateTime(1975, 1, 1) },
                new Movie { Id = 2, Title = "Luca", ReleaseDate = new DateTime(2021, 1, 1) },
                new Movie { Id = 3, Title = "Kill Bill", ReleaseDate = new DateTime(2003, 1, 1) }};

            builder.ToTable("Movies");
            builder.HasData(movieData);
        }
    }
}
