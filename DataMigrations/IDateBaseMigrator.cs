namespace DataMigrations
{
    using System.Data.Entity;

    public interface IDateBaseMigrator
    {
        void ExcuteMigration();
    }
}
