namespace DataMigrations
{
    using System.Data.Entity;

    public interface IDateBaseMigrator
    {
        //MigrationReport ExcuteMigration();
        void ExcuteMigration();
    }
}
