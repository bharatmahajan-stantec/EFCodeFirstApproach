EF Code First Approach


Entity Framework (EF) Code First is a powerful approach to data access in .NET that emphasizes defining your domain model (entities) as C# classes first, and then using EF to generate the database schema based on those classes. This contrasts with Database First, where you start with an existing database.

Key Features of EF Code First

•	Model Definition: Developers define their data models using C# classes, which represent the entities in the application.
•	Migrations: EF Code First supports migrations, allowing developers to evolve the database schema over time as the model changes.
•	Fluent API and Data Annotations: Developers can configure the model using either data annotations or the Fluent API to specify relationships, constraints, and other configurations.


Pros and Cons of EF Code First

Pros

•	Developer Control: Developers have full control over the data model and can easily make changes to the classes without needing to modify the database directly.
•	Code-Centric: The approach is more aligned with modern development practices, allowing developers to work primarily in code rather than using visual designers.
•	Migrations: The built-in migrations feature allows for easy updates to the database schema as the application evolves, making it easier to manage changes over time.
•	Test-Driven Development (TDD): Code First is conducive to TDD, as developers can write tests against their models before the database is created.
•	Less Initial Setup: Developers can start coding without needing to create a database first, which can speed up the initial development process.

Cons

•	Learning Curve: Developers who are new to EF or ORM concepts may face a learning curve in understanding how to effectively use Code First.
•	Complex Migrations: While migrations are powerful, they can become complex and difficult to manage in large applications with many changes.
•	Performance Overhead: The abstraction layer provided by EF can introduce performance overhead compared to raw SQL queries, especially in performance-critical applications.
•	Limited Control Over Database Design: While Code First provides flexibility, it may not be suitable for scenarios where a specific database design is required from the outset.



Feature	Code First	Database First
Starting Point	C# code (entities)	Existing database
Database Schema	Generated from code	Existing
Control	Full control	Less control
Flexibility	Highly flexible, easy schema evolution	Less flexible, manual updates required
Development Speed (Initial)	Can be slower	Faster
Maintenance	Easier with migrations	More manual effort
Learning Curve	Steeper	Easier to get started
Best For	New projects, evolving schemas, DDD	Existing databases, rapid prototyping





When to Choose Code First

•	You are starting a new project.
•	You anticipate frequent changes to your database schema.
•	You are following Domain-Driven Design principles.
•	Your team is comfortable with C# and EF.

When to Choose Database First

•	You have an existing database that you need to work with.
•	You are working with a large, complex database.
•	You need to get started quickly.
•	Your team is more comfortable with SQL and database design.













Development Steps



1.	Create application from Visual Studio
2.	Add nuget package - EnittyFrameworkCore
3.	Create entity classes
4.	Create context class – DBContext
5.	Create/Update Database using EF command

Install SQLExpress

To view created database – View -> SQL Server Object Explorer

EF commands for migration and updating database


1.	 enable-migrations –EnableAutomaticMigration:$true –  This enables migration and creates configuration class where we can add properties related to migration for automatic migration and data loss if any.
2.	Add-Migration <MigrationName> - This creates a migration file for entity class changes from previous migration state file
3.	Update-Database – This will update database based on latest entity class changes


Scenarios

•	Update entity classes by editing some or adding new classes

Try to run project you will get this error message: "The model backing the <ContextName> context has changed since the database was created. Consider using Code First Migrations to update the database (http://go.microsoft.com/fwlink/?LinkId=238269).",


To resolve this 
run following commands Here are the steps to enable and apply migrations:

1.	Enable Migrations: Open the Package Manager Console in Visual Studio (Tools > NuGet Package Manager > Package Manager Console) and run the following command to enable migrations:

   Enable-Migrations
   
2.	Add a Migration: After enabling migrations, add a new migration to capture the changes in your model. Run the following command in the Package Manager Console:

   Add-Migration UpdateDatabaseSchema
  
This command will create a new migration file in the Migrations folder, which contains the necessary code to update the database schema.

 
3.	Update the Database: Apply the migration to update the database schema. Run the following command in the Package Manager Console:

   Update-Database
   
This command will apply the pending migrations to the database, updating its schema to match your current model.

•	Add code and then revert them

Add code in classes required
then run command
Add-Migration <MigrationName>
Update-Database


To revert back to specific migration

Update-Database -TargetMigration <MigrationName>

•	Adding new field which is non null field

Add required field to entity class
Run command
Add-Migration <Migration Name>

Modify the Migration File

After running the Add-Migration command, a new migration file will be created. Open this file and modify the Up method to set a default value for the added property.


e.g. public partial class AddColorToProduct : DbMigration
{
    public override void Up()
    {
        AddColumn("dbo.Products", "Color", c => c.String(nullable: false, defaultValue: "Unknown"));
    }

    public override void Down()
    {
        DropColumn("dbo.Products", "Color");
    }
}

Apply the Migration

Run the following command to apply the migration and update the database:

Update-Database

•	Migration to another database
In app config provide a separate connection string with new database and run command “Update-Database”. This will create a new database at provided path with latest schema of entity classes

•	Migration with data
Unfortunately, there is no EF command for this and this has to be done using generating scripts from source database and then running those scripts to target database.


