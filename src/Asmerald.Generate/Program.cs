// See https://aka.ms/new-console-template for more information
using Asmerald;
using Asmerald.SQLite;
using Asmerald.Generate;
using Asmerald.QueryBuilders;
using Asmerald.Statements;
using Dapper;
using Asmerald.Generate.Generators;
using CommandDotNet;
using Asmerald.Columns;
using Asmerald.Statements.SQLite;
using System.Numerics;
using System.Collections;
using ConsoleTables;
using System.Data;
using Microsoft.Data.Sqlite;
using Asmerald.Generate.Generators.Mapping;
using Asmerald.Generate.Generators.Database;
using System.Reflection.Emit;
using static Org.BouncyCastle.Math.EC.ECCurve;

public class Program
{
    public static int Main(string[] args)
    {
        var appSett = new AppSettings()
        {

        };

        return new AppRunner<Program>(appSett).Run(args);
    }

    /// <summary>
    /// Supported databases for code generation.
    /// </summary>
    public enum DataBase
    {
        SQLite, PostgreSQL, MySQL, MariaDB, MSSQL, Oracle
    }

    // generate SQLite "Data Source=C:\Users\Alexander\Desktop\Digillection\digillection.sqlite3;" "C:\temp\sqlgen"

    [Command("scheme", Description = "Generates code based on database details to use with Typesafe library.")]
    public void Scheme(
        [Operand("database", Description = "Database provider - needs to be supported, e.g. SQLite.")]
        DataBase dataBase,
        [Operand("connectionString", Description = "Full qualified connection string for database access.")]
        string connectionString)
    {
        // Get generator based on database provider
        var config = new GenerateConfiguration() { DataBase = dataBase, ConnectionString = connectionString };
        IGenerator generator = GetGenerator(config, dataBase);

        // Get to be created classes
        var (tables, sps) = generator.Generate();

        foreach (var sp in sps)
        {
            var code = new AsmeraldSPClassBuilder().Build("test", sp);
        }


        ConsoleTable ct = new ConsoleTable("Table");
        foreach (var table in tables)
        {
            ct.AddRow(table.Name);
        }

        ct.Write();

        ConsoleTable cc = new ConsoleTable("Table", "Column", "Type");
        string t = "";
        foreach (var table in tables)
        {
            foreach (var column in table.Columns)
            {
                if(t != table.Name)
                {
                    cc.AddRow(table.Name, column.Name, column.Type);
                }
                else
                {
                    cc.AddRow("", column.Name, column.Type);
                }
                t = table.Name;
            }
        }

        cc.Write();
    }

    [Command("generate", Description = "Generates code based on database details to use with Typesafe library.")]
    public async Task Generate(
        [Operand("database", Description = "Database provider - needs to be supported, e.g. SQLite.")]
        DataBase dataBase,
        [Operand("connectionString", Description = "Full qualified connection string for database access.")]
        string connectionString, 
        [Operand("targetDir", Description = "Directory name and path to store generated files in.")]
        string targetDir, 
        [Option(Description = "Optional - Namespace of generated classes.")]
        string nspace = "")
    {
        // Get generator based on database provider
        var config = new GenerateConfiguration() { DataBase = dataBase, Namespace = nspace, ConnectionString = connectionString };
        IGenerator generator = GetGenerator(config, dataBase);

        // Get to be created classes
        var (generateTables, sps) = generator.Generate();

        // Generate code
        AsmeraldTableClassBuilder classGenerator = new AsmeraldTableClassBuilder();
        Dictionary<string, string> dicRes = new Dictionary<string, string>();
        foreach (var tbl in generateTables)
        {
            var generatedCode = classGenerator.Build(config.Namespace, tbl);
            dicRes.Add(tbl.Name_class, generatedCode);
        }

        // Then we create the directory - if necessary
        var directoryInfo = new DirectoryInfo(targetDir);
        if (directoryInfo.Exists == false)
        {
            directoryInfo.Create();
        }

        // Now write generated code to files
        foreach (var genCode in dicRes)
        {
            var fileName = Path.Combine(directoryInfo.FullName, $"{nameof(Asmerald)}.{genCode.Key}.cs");
            await File.WriteAllTextAsync(fileName, genCode.Value);
        }
    }

    private IGenerator GetGenerator(GenerateConfiguration config, DataBase dataBase)
    {
        switch (dataBase)
        {
            case DataBase.SQLite:
                return new AsmeraldGenerator(config, new SQLiteDatabaseSchemeLoader(config), new SQLiteMapper());
            case DataBase.PostgreSQL:
                return new AsmeraldGenerator(config, new PostgreSQLDatabaseSchemeLoader(config), new StringMapper(Asmerald.Generate.Properties.Resources.postgresql_type_mapping));
            case DataBase.MySQL:
                return new AsmeraldGenerator(config, new MySQLDatabaseSchemeLoader(config), new StringMapper(Asmerald.Generate.Properties.Resources.mysql_type_mapping));
            case DataBase.MariaDB:
                return new AsmeraldGenerator(config, new MariaDBDatabaseSchemeLoader(config), new StringMapper(Asmerald.Generate.Properties.Resources.mariadb_type_mapping));
            case DataBase.MSSQL:
                return new AsmeraldGenerator(config, new MSSQLDatabaseSchemeLoader(config), new StringMapper(Asmerald.Generate.Properties.Resources.mssql_type_mapping));
            case DataBase.Oracle:
                return new AsmeraldGenerator(config, new OracleDatabaseSchemeLoader(config), new StringMapper(Asmerald.Generate.Properties.Resources.oracle_type_mapping));
            default:
                throw new NotImplementedException($"Database provider '{dataBase}' not yet implemented!");
        }
    }
}