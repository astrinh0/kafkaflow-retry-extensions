﻿namespace KafkaFlow.Retry.SqlServer
{
    public static class RetryDurableDefinitionBuilderExtension
    {
        private const string schemaDefault = "dbo";

        public static RetryDurableDefinitionBuilder WithSqlServerDataProvider(
            this RetryDurableDefinitionBuilder retryDurableDefinitionBuilder,
            string connectionString,
            string databaseName,
            string schema)
        {
            retryDurableDefinitionBuilder.WithRepositoryProvider(
                new SqlServerDbDataProviderFactory()
                    .Create(
                        new SqlServerDbSettings(
                            connectionString,
                            databaseName,
                            schema)
                    )
                );

            return retryDurableDefinitionBuilder;
        }

        public static RetryDurableDefinitionBuilder WithSqlServerDataProvider(
           this RetryDurableDefinitionBuilder retryDurableDefinitionBuilder,
           string connectionString,
           string databaseName)
        {
            retryDurableDefinitionBuilder.WithRepositoryProvider(
                new SqlServerDbDataProviderFactory()
                    .Create(
                        new SqlServerDbSettings(
                            connectionString,
                            databaseName,
                            schemaDefault)
                    )
                );

            return retryDurableDefinitionBuilder;
        }
    }
}