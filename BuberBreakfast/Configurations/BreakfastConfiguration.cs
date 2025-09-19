using BuberBreakfast.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberBreakfast.Configurations
{
	public class BreakfastConfiguration : IEntityTypeConfiguration<Breakfast>
	{
		public void Configure(EntityTypeBuilder<Breakfast> builder)
		{
			builder.Property(b => b.Name).HasMaxLength(50);
		}
	}
}
