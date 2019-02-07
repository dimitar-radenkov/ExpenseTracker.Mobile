namespace ExpenseTracker.Mobile.Storage
{
    public interface IDbPath
    {
        string GetPath(string filename);
    }
}
