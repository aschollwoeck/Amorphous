﻿// See https://aka.ms/new-console-template for more information
using TypeProofSql;
using TypeProofSql.SQLite;
using TypeProofSql.Generate;
using TypeProofSql.QueryBuilders;
using TypeProofSql.Statements;
using Dapper;
using TypeProofSql.Generate.Generators;
using CommandDotNet;
using TypeProofSql.Columns;
using TypeProofSql.Statements.SQLite;

public class Program
{
    public static int Main(string[] args)
    {
        var appSett = new AppSettings()
        {

        };
        return new AppRunner<Program>(appSett).Run(args);

        Console.WriteLine("Hello, World!");

        try
        {
            //SQLiteGenerator generator = new SQLiteGenerator(@"Data Source=C:\Users\Alexander\Desktop\Digillection\digillection.sqlite3;");
            //generator.Generate();
        }
        catch (Exception ex) { }

        

        return 0;
    }

    public enum DataBase
    {
        SQLite
    }

    // generate SQLite "Data Source=C:\Users\Alexander\Desktop\Digillection\digillection.sqlite3;" "C:\temp\sqlgen"

    [Command("scheme", Description = "Generates code based on database details to use with Typesafe library.")]
    public async Task Scheme(
        [Operand("database", Description = "Database provider - needs to be supported, e.g. SQLite.")]
        DataBase dataBase,
        [Operand("connectionString", Description = "Full qualified connection string for database access.")]
        string connectionString)
    {
        // Get generator based on database provider
        IGenerator generator;
        switch (dataBase)
        {
            case DataBase.SQLite:
                generator = new SQLiteGenerator(new GenerateConfiguration() { ConnectionString = connectionString });
                break;
            default:
                throw new NotImplementedException($"Database provider '{dataBase}' not yet implemented!");
        }
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
        IGenerator generator;
        switch (dataBase)
        {
            case DataBase.SQLite:
                generator = new SQLiteGenerator(new GenerateConfiguration() { ConnectionString =  connectionString });
                break;
            default:
                throw new NotImplementedException($"Database provider '{dataBase}' not yet implemented!");
        }

        // We first generate the code
        var generatedCode = await generator.Generate(nspace);

        // Then we create the directory - if necessary
        var directoryInfo = new DirectoryInfo(targetDir);
        if (directoryInfo.Exists == false)
        {
            directoryInfo.Create();
        }

        // No write generated code to files
        foreach (var genCode in generatedCode)
        {
            var fileName = Path.Combine(directoryInfo.FullName, $"Typesafe.{genCode.Key}.cs");
            await File.WriteAllTextAsync(fileName, genCode.Value);
        }
    }
}