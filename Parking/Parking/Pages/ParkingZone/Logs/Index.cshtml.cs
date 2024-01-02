using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Parking.Data;
using Parking.Models;
using Parking.ViewModels;

namespace Parking.Pages.ParkingZone.Logs
{
    public class IndexModel : PageModel
    {
        private readonly ParkingContext _context;

        [BindProperty]
        public DateTime? StartDate { get; set; }
        [BindProperty]
        public DateTime? EndDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? SelectedZoneId { get; set; }
        [BindProperty]
        public string? Search { get; set; }
        [BindProperty]
        public int? ParkingSlotId { get; set; }

        [BindProperty]
        public int PageNumber { get; set; } = 1;
        [BindProperty]
        public int NextPageNumber { get; set; } = 0;
        [BindProperty]
        public int PrevPageNumber { get; set; } = 2;
        [BindProperty]
        public int PageSize { get; set; } = 50;
        [BindProperty]
        public int TotalCount { get; set; } = 0;

        public int NumberOfPages { get; set; } = 1;
        public bool IsNextPageDisabled { get; set; } = false;
        public bool IsPrevPageDisabled { get; set; } = false;

        [BindProperty]
        public int? SelectedZone { get; set; }

        public IndexModel(ParkingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<LogVM> Logs { get; set; }

        [BindProperty]
        public IList<ZoneVM> Zones { get; set; }

        public async Task<IActionResult> OnGetAsync(DateTime? startDate, DateTime? endDate, int? selectedZoneId)
        {
            var query = _context.Logs
                .Select(log => new LogVM
                {
                    Id = log.Id,
                    DeviceName = log.DeviceName,
                    CameraName = log.CameraName,
                    Address = log.Address,
                    ZoneId = log.ZoneId,
                    Person = log.Person,
                    Car = log.Car,
                    Truck = log.Truck,
                    Motorbike = log.Motorbike,
                    Misc = log.Misc,
                    Type = log.Type,
                    Parameters = log.Parameters,
                    Timestamp = log.Timestamp,
                });

            if (startDate.HasValue)
            {
                query = query.Where(log => log.Timestamp >= startDate);
            }

            if (endDate.HasValue)
            {
                query = query.Where(log => log.Timestamp <= endDate);
            }


            if (SelectedZoneId.HasValue && SelectedZoneId.Value != 0)
            {

                var selectedZoneExists = await _context.Zones.AnyAsync(zone => zone.Id == SelectedZoneId);


                if (selectedZoneExists)
                {
                    query = query.Where(log => log.ZoneId == SelectedZoneId);
                }
                else
                {
                    Logs = await query.ToListAsync();
                    Zones = await _context.Zones
                        .Select(zone => new ZoneVM
                        {
                            Id = zone.Id,
                            Name = zone.Name,
                        })
                        .ToListAsync();
                    return Page();
                }
            }

            Logs = await query.ToListAsync();


            Zones = await _context.Zones
                .Select(zone => new ZoneVM
                {
                    Id = zone.Id,
                    Name = zone.Name,
                })
                .ToListAsync();

            return Page();
        }
    }
}
