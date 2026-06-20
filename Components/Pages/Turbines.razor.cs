using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using WindServiceManager.Data;
using WindServiceManager.Models;

namespace WindServiceManager.Components.Pages;

public partial class Turbines
{
    [Inject]
    private AppDbContext Db { get; set; } = null!;

    private List<WindTurbine> turbines = new();
    private TurbineBatchForm form = new();
    private string? formMessage;

    protected override async Task OnInitializedAsync()
    {
        await LoadTurbines();
    }

    private async Task LoadTurbines()
    {
        turbines = await Db.WindTurbines.OrderBy(t => t.Name).ToListAsync();
    }

    private async Task AddTurbines()
    {
        formMessage = null;

        if (string.IsNullOrWhiteSpace(form.Prefix))
        {
            formMessage = "Podaj prefiks nazwy (np. WTG).";
            return;
        }

        if (form.Count < 1)
        {
            formMessage = "Ilość turbin musi być większa od zera.";
            return;
        }

        if (form.StartNumber < 1)
        {
            formMessage = "Numer początkowy musi być większy od zera.";
            return;
        }

        var padding = (form.StartNumber + form.Count - 1).ToString().Length;
        var newTurbines = new List<WindTurbine>();

        for (var i = 0; i < form.Count; i++)
        {
            var number = (form.StartNumber + i).ToString().PadLeft(Math.Max(padding, 2), '0');
            newTurbines.Add(new WindTurbine
            {
                Name = $"{form.Prefix.Trim()}-{number}",
                Location = form.Location.Trim(),
                Model = form.Model.Trim(),
                Status = TurbineStatus.Operational
            });
        }

        Db.WindTurbines.AddRange(newTurbines);
        await Db.SaveChangesAsync();

        formMessage = $"Dodano {newTurbines.Count} turbin: {newTurbines.First().Name} – {newTurbines.Last().Name}.";
        form.StartNumber += form.Count;

        await LoadTurbines();
    }

    private async Task DeleteTurbine(WindTurbine turbine)
    {
        Db.WindTurbines.Remove(turbine);
        await Db.SaveChangesAsync();
        await LoadTurbines();
    }

    private static string GetStatusLabel(TurbineStatus status) => status switch
    {
        TurbineStatus.Operational => "Sprawna",
        TurbineStatus.Failure => "Awaria",
        TurbineStatus.Maintenance => "Serwis",
        _ => status.ToString()
    };

    private static string GetStatusBadge(TurbineStatus status) => status switch
    {
        TurbineStatus.Operational => "text-bg-success",
        TurbineStatus.Failure => "text-bg-danger",
        TurbineStatus.Maintenance => "text-bg-warning text-dark",
        _ => "text-bg-secondary"
    };
}
