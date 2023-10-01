namespace Dometrain.EFCore.MariaDB.Data;

public interface IMoviesContextManager
{
    MoviesContext GetContext();
    void StartUnitOfWork();
    bool IsUnitOfWorkStarted { get; }
    Task<int> SaveChangesAsync();
}

public class MoviesContextManager : IMoviesContextManager
{
    private readonly MoviesContext _context;

    public MoviesContextManager(MoviesContext context)
    {
        _context = context;
    }
    
    public MoviesContext GetContext()
    {
        return _context;
    }

    private bool _isUnitOfWorkStarted = false;
    public void StartUnitOfWork()
    {
        _isUnitOfWorkStarted = true;
    }
    public bool IsUnitOfWorkStarted => _isUnitOfWorkStarted;
    
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}