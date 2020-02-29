https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-controller?view=aspnetcore-3.1&tabs=visual-studio

maak model en maak een migration.

Add-Migration <InitialCreate> -Context ApplicationDbContext
Update-Database

maak controller en views.
In Solution Explorer, right-click Controllers > Add > New Scaffold item...
In the Add Scaffold dialog box, select MVC Controller - Empty

https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/complex-data-model?view=aspnetcore-3.1

Update-Database <previous-migration-name>
Remove-Migration
