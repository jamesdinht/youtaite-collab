using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collab.API.Models.Config.Extensions
{
    /// <summary>
    /// A reusable class meant to add logging metadata to the database
    /// </summary>
    public static class DbLoggingConfiguration
    {
        /// <summary>
        /// Adds a creation date column to the database with the specified column name, "DateCreated" by default
        /// 
        /// The date column is automatically configured with ValueGeneratedOnAdd
        /// </summary>
        /// <typeparam name="DateTime">SQL column datatype</typeparam>
        /// <param name="columnName">Name of the column in the database</param>
        public static PropertyBuilder<DateTime> AddDateCreatedColumn<T>(this EntityTypeBuilder<T> builder, string columnName="DateCreated") where T : class
        {
            return builder.Property<DateTime>(columnName)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETDATE()");
        }

        /// <summary>
        /// Adds a last updated date column to the database with the specified column name, "DateLastUpdated" by default
        /// 
        /// The date column is automatically configured with ValueGeneratedOnAddOrUpdate
        /// </summary>
        /// <typeparam name="DateTime">SQL column datatype</typeparam>
        /// <param name="columnName">Name of the column in the database</param>
        public static PropertyBuilder<DateTime?> AddLastUpdatedColumn<T>(this EntityTypeBuilder<T> builder, string columnName="DateLastUpdated") where T : class
        {
            return builder.Property<DateTime?>(columnName)
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}