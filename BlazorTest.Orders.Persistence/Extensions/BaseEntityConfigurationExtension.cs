namespace BlazorTest.Orders.Persistence.Extensions
{
    using BlazorTest.Orders.Domain.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public static class BaseEntityConfigurationExtension
    {
        public static EntityTypeBuilder<TEntity> MapBase<TEntity>(this EntityTypeBuilder<TEntity> builder, string tableName, string schemaName)
            where TEntity : class, IBaseEntity
        {
            builder.ToTable(tableName, schemaName);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("newsequentialid()");

            return builder;
        }
    }
}
