using Dometrain.EFCore.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Dometrain.EFCore.API.Data.Interceptors;

public class SaveChangesInterceptor : ISaveChangesInterceptor
{
    public InterceptionResult<int> SavingChanges(
        DbContextEventData eventData, 
        InterceptionResult<int> result)
    {
        var context = eventData.Context as MoviesContext;

        if (context is null) return result;

        var tracker = context.ChangeTracker;

        var deleteEntries = tracker.Entries<Genre>()
            .Where(entry => entry.State == EntityState.Deleted);

        foreach (var deleteEntry in deleteEntries)
        {
            deleteEntry.Property<bool>("Deleted").CurrentValue = true;
            deleteEntry.State = EntityState.Modified;
        }

        return result;
    }

    public ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, 
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return ValueTask.FromResult(SavingChanges(eventData, result));
    }
}